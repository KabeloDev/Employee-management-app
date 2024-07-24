using Employee_DomainLayer.Models;
using Employee_ServiceLayer.ICustomServices;
using Microsoft.AspNetCore.Mvc;

namespace EmployeManagement_WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ICustomService<Employee> _employeeService;

        public EmployeeController(ICustomService<Employee> employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            return View(_employeeService.GetAll());
        }

        [HttpGet]
        public IActionResult Details (int Id)
        {
            var employee = _employeeService.Get(Id);
            return View(employee);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Employee employee = new Employee();
            return View(employee);
        }

        [HttpPost]
        public IActionResult Create (Employee employee)
        {
            _employeeService.Create(employee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            var employee = _employeeService.Get(Id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            _employeeService.Update(employee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var employee = _employeeService.Get(Id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            _employeeService.Delete(employee);
            return RedirectToAction("Index");
        }
    }
}
