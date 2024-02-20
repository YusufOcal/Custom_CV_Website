using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.Controllers
{
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EFServiceDal());
        public IActionResult Index()
        {
            ViewBag.V1 = "Hizmet Listesi";
            ViewBag.V2 = "Hizmetler";
            ViewBag.V3 = "Hizmet Liste";

            var mevcutService = serviceManager.TGetList();
            return View(mevcutService);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            ViewBag.V1 = "Hizmet";
            ViewBag.V2 = "Hizmetler";
            ViewBag.V3 = "Hizmet Listesi";

            return View();
        }
        [HttpPost]
        public IActionResult AddService(Service service)
        {
            serviceManager.TAdd(service);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteService(int id)
        {
            serviceManager.TRemove(serviceManager.TGetByID(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditService(int id)
        {
            ViewBag.V1 = "Güncelleme";
            ViewBag.V2 = "Hizmetler";
            ViewBag.V3 = "Hizmet Güncelleme";

            var mevcutServices = serviceManager.TGetByID(id);
            return View(mevcutServices);
        }
        [HttpPost]
        public IActionResult EditService(Service service)
        {
            serviceManager.TUpdate(service);
            return RedirectToAction("Index");
        }
    }
}
