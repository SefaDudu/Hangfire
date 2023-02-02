using Microsoft.AspNetCore.Mvc;

namespace Hangfire.Controllers
{
    public class FileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
