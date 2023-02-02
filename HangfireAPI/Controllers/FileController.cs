using DataAccess.Context;
using DataAccess.VM;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HangfireAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : Controller
    {
        private readonly ApiDbContext _apiDbContext;
        public FileController(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] ParserFileUploadVm vm)
        {
            string path = "";

            try
            {
                path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "Resources", $"Upload", $"{DateTime.Now.ToShortDateString()}"));
                var guidFN = vm.ParserFile.FileName;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (var fileStream = new FileStream(Path.Combine(path, guidFN), FileMode.Create))
                {
                    await vm.ParserFile.CopyToAsync(fileStream);
                }

                //parser type, projectId ve gerekli her şey buraya kayıt edilecek.
                var newFile = new DataAccess.Model.File()
                {
                    Check = false,
                    FileName = guidFN,
                    Date=DateTime.Now
                };
                _apiDbContext.Add(newFile);


                _apiDbContext.SaveChanges();
                //var json = System.IO.File.ReadAllText(@$"Resources/Upload/{DateTime.Now.ToShortDateString()}/{path}");
                //var parsedModel = JsonConvert.DeserializeObject<ParserFileUploadVm>(json);
                return Ok($"{vm.ParserFile.FileName} dosya yüklenmek üzere işlem sırasına alınmıştır." );
            }
            catch (Exception)
            {
                return BadRequest("Dosya yükleme sırasında bir hata oluştu.");
            }



        }




    }
}
