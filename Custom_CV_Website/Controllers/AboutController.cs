using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EFAboutDal());

        [HttpGet] public IActionResult Index()
        {
            ViewBag.V1 = "Düzenleme";
            ViewBag.V2 = "Hakkımda";
            ViewBag.V3 = "Hakkımda Liste";

            var mevcutAbout = aboutManager.TGetByID(1);
            return View(mevcutAbout);
        }
        [HttpPost] public IActionResult Index(About about)
        {
            aboutManager.TUpdate(about);
            return RedirectToAction("Index", "Default");
        }
    }
}
