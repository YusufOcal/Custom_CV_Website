using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.V1 = "Dashboard";
            ViewBag.V2 = "Dashboard";
            ViewBag.V3 = "Dashboard Listesi";

            return View();
        }
    }
}
