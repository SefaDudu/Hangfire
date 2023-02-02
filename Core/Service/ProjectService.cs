using DataAccess.Context;
using DataAccess.Model;
using DataAccess.VM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public class ProjectService : IProjectService
    {
        readonly ApiDbContext _apiDbContext;
        public ProjectService(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }
        public async Task<bool> ProjectUpload()
        {
            try
            {
                var getUploadList = _apiDbContext.Files.Where(x =>  x.Check == false).OrderBy(x => x.Date).ToList();
                if (getUploadList.Count > 0)
                {
                    foreach (var fileUpload in getUploadList)
                    {
                        var json = System.IO.File.ReadAllText(@$"Resources/Upload/{DateTime.Now.ToShortDateString()}/{fileUpload.FileName}");
                        var parsedModel = JsonConvert.DeserializeObject<Root>(json);
                        var newProject = new Project()
                        {
                            Name = parsedModel.test
                        };

                        fileUpload.Check = true;
                        _apiDbContext.Projects.Add(newProject);
                        _apiDbContext.Files.Update(fileUpload);
                        _apiDbContext.SaveChanges();
                    }
                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }
          
        }
    }
}
