using Microsoft.AspNetCore.Mvc;
using DIDemo2.Models;
using Microsoft.VisualBasic;

namespace DIDemo2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployRepository _Repository;
        public EmployeeController(ILogger<EmployeeController> logger, IEmployRepository Repository)
        {
            _logger = logger;
            _Repository = Repository;
        }
        public IActionResult AllEmployess()
        {
            List<Employee> emps = (List<Employee>)_Repository.GetAllEmployees();
            return View(emps);
        }
        public IActionResult DeleteEmployee(int id)
        {
            _Repository.DeleteEmployee(id);
            return RedirectToAction("AllEmployess");
        }
        public IActionResult AddEmployee()
        {
          


            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee emp)
        {
           int res= _Repository.AddEmployee(emp);
            if (res != 0)
                ViewBag.msg = "Record Inserted..";
            else
                ViewBag.msg = "Record not Inserted..";



            return View();
        }
        public IActionResult EditEmployee(int id)
        {

            var emp=_Repository.GetEmployeeById(id);

            return View(emp);
        }
        [HttpPost]
        public IActionResult EditEmployee(Employee emp)
        {

             _Repository.UpdateEmployee(emp);

            return RedirectToAction("AllEmployess");
        }
        public IActionResult GetEmployeeById(int id)
        {

            var emp = _Repository.GetEmployeeById(id);

            return View(emp);
        }
        
    }
}
