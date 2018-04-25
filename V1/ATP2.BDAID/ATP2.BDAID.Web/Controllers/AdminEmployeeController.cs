using System;
using System.Web.Mvc;
using ATP2.BDAID.Entities;
using ATP2.BDAID.Framework.Constant;
using ATP2.BDAID.Framework.Helper;
using ATP2.BDAID.Model.Admin;
using ATP2.BDAID.Services.Admin;
using ATP2.BDAID.Web.Framework.Base;

namespace ATP2.BDAID.Web.Controllers
{
    public class AdminEmployeeController : BaseController
    {
        //
        // GET: /AdminEmployee/
        public ActionResult List(string key="")
        {
            var model = EmployeeService.GetAll(key);

            if (TempData["Error"] != null)
            {
                ViewBag.Error = TempData["Error"];
            }

            if (TempData["Success"] != null)
            {
                ViewBag.Success = TempData["Success"];
            }

            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var result = EmployeeService.GetByID(id);
            var model = new EmployeeModel()
            {
                Employee = result.Data??new Employee(){UserInfo = new UserInfo(){Password = "1"}},
                Statuses = EnumCollection.GetUserStatusEnum()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Detail(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                var model = new EmployeeModel()
                {
                    Employee = employee,
                    Statuses = EnumCollection.GetUserStatusEnum()
                };

                return View(model);
            }

            bool isPass = false;
            employee.UserInfo.UserTypeID = (int) EnumCollection.UserTypeEnum.Employee;
            if (employee.UserInfo.Password=="1")
            {
                employee.UserInfo.Password = new Random().Next(11111, 99999).ToString();
                isPass = true;
            }

            var result = EmployeeService.Save(employee);

            if (result.HasError)
            {
                ViewBag.Error = result.Message;
                var model = new EmployeeModel()
                {
                    Employee = employee,
                    Statuses = EnumCollection.GetUserStatusEnum()
                };
                return View(model);
            }

            if (isPass)
            {
                TempData["Success"] = result.Data.UserInfo.Email + ",Your Password is " + result.Data.UserInfo.Password;
            }

            return RedirectToAction("List");
        }
	}
}