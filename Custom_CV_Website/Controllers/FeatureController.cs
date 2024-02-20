using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.Controllers
{
    public class FeatureController : Controller
    {
        FeatureManager featureManager = new FeatureManager(new EFFeatureDal());

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.V1 = "Düzenleme";
            ViewBag.V2 = "Öne Çıkanlar";
            ViewBag.V3 = "Öne Çıkanlar Liste";

            var mevcutFeature = featureManager.TGetByID(1);
            return View(mevcutFeature);
        }
        [HttpPost]
        public IActionResult Index(Feature feature)
        {
            featureManager.TUpdate(feature);
            return RedirectToAction("Index","Default");
        }

    }
}
