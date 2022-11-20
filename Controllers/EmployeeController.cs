using Microsoft.AspNetCore.Mvc;
using PCSProject.Domain;
using PCSProject.Models;
using PCSProject.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCSProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeRequest request)
        {
            if (request.Employee_Id == 0)
            {
                var result = await _employeeService.Create(request);
                ViewData["message"] = result;
                return Redirect("Employee/Create");
            }
            else
            {
                var result = await _employeeService.Update(request);
                ViewData["message"] = result;
                return Redirect("Employee/Create");
            }
        }

        [HttpPost]
        public async Task<JsonResult> EmployeeListById(int EmployeeId)
        {
            var result = await _employeeService.EmpQualificationList(EmployeeId);
            return Json(result);
        }
    }
}
