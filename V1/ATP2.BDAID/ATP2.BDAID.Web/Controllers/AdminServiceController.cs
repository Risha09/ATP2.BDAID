using System.Web.Mvc;
using ATP2.BDAID.Entities;
using ATP2.BDAID.Framework.Constant;
using ATP2.BDAID.Model.Admin;
using ATP2.BDAID.Services.Admin;
using ATP2.BDAID.Web.Framework.Base;

namespace ATP2.BDAID.Web.Controllers
{
    public class AdminServiceController : BaseController
    {
        //
        // GET: /AdminService/
        public ActionResult List()
        {
            var model = ServiceTypeService.GetAll();

            if (TempData["Error"] != null)
            {
                ViewBag.Error = TempData["Error"];
            }

            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var result = ServiceTypeService.GetByID(id);
            var model = new ServiceModel()
            {
                Service = result.Data??new Service(),
                ServiceTypes = EnumCollection.GetServiceTypeEnum()
            };

            return View(model);
        }

        public ActionResult Reports()
        {
            var result = ServiceAuditService.GetAll();

            return View(result);
        }

        [HttpPost]
        public ActionResult Detail(Service service)
        {
            if (!ModelState.IsValid)
            {
                var model = new ServiceModel()
                {
                    Service = service,
                    ServiceTypes = EnumCollection.GetServiceTypeEnum()
                };

                return View(model);
            }
            var result = ServiceTypeService.Save(service);

            if (result.HasError)
            {
                ViewBag.Error = result.Message;
                var model = new ServiceModel()
                {
                    Service = service,
                    ServiceTypes = EnumCollection.GetServiceTypeEnum()
                };
                return View(model);
            }

            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            var result = ServiceTypeService.Delete(id);

            if (!result)
            {
                TempData["Error"] = "Something went wrong";
            }
             return RedirectToAction("List");
        }
	}
}