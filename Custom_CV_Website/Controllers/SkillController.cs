using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.Controllers
{
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EFSkillDal());
        public IActionResult Index()
        {
            ViewBag.V1 = "Yetenek Listesi";
            ViewBag.V2 = "Yetenekler";
            ViewBag.V3 = "Yetenek Listesi";

            var list = skillManager.TGetList();

            return View(list);
        }
        [HttpGet]
        public IActionResult AddSkill() 
        {
            ViewBag.V1 = "Yetenek";
            ViewBag.V2 = "Yetenekler";
            ViewBag.V3 = "Yetenek Listesi";

            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            skillManager.TAdd(skill);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSkill(int id)
        {
            skillManager.TRemove(skillManager.TGetByID(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditSkill(int id) 
        {
            ViewBag.V1 = "Güncelleme";
            ViewBag.V2 = "Yetenekler";
            ViewBag.V3 = "Yetenek Güncelleme";

            var mevcutSkills = skillManager.TGetByID(id);
            return View(mevcutSkills);
        }
        [HttpPost]
        public IActionResult EditSkill(Skill skill)
        {
            skillManager.TUpdate(skill);
            return RedirectToAction("Index");
        }
    }
}
