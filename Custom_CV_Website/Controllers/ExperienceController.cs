using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.Controllers
{
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EFExperienceDal());
        public IActionResult Index()
        {
            ViewBag.V1 = "Deneyim Listesi";
            ViewBag.V2 = "Deneyimler";
            ViewBag.V3 = "Deneyim Listesi";

            return View(experienceManager.TGetList());
        }
        [HttpGet]
        public IActionResult AddExperience()
        {
            ViewBag.V1 = "Deneyim";
            ViewBag.V2 = "Deneyimler";
            ViewBag.V3 = "Deneyim Listesi";

            return View();
        }
        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            experienceManager.TAdd(experience);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteExperience(int id)
        {
            experienceManager.TRemove(experienceManager.TGetByID(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditExperience(int id)
        {
            ViewBag.V1 = "Güncelleme";
            ViewBag.V2 = "Deneyimler";
            ViewBag.V3 = "Deneyim Güncelleme";

            return View(experienceManager.TGetByID(id));
        }
        [HttpPost]
        public IActionResult EditExperience(Experience experience)
        {
            experienceManager.TUpdate(experience);
            return RedirectToAction("Index");
        }
    }
}
