using Microsoft.AspNetCore.Mvc;

namespace KomisSamochodowy.Controllers
{
    public class PermissionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
