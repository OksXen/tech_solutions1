using Microsoft.AspNetCore.Mvc;
using TechSolutionsLibs.Models;
using TechSolutionsLibs.Settings.Interface;

namespace TechSolutionsLibs.Controllers
{
    public class EmployeeActivityController : Controller
    {
        
        IEmployeeActivityRepository _employeeActivityProvider;


        public EmployeeActivityController(IEmployeeActivityRepository employeeActivityProvider)
        {
            _employeeActivityProvider = employeeActivityProvider;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult AddEmployeeActivity(EmployeeActivityViewModel employeeActivityViewModel)
        {
            if (ModelState.IsValid)
            {
                var employeeActivity = new EmployeeActivity()
                {
                    FirstName = employeeActivityViewModel.FirstName,
                    LastName = employeeActivityViewModel.LastName,
                    EmailAddress = employeeActivityViewModel.EmailAddress,
                    ActivityName = employeeActivityViewModel.ActivityName,
                    Comments = employeeActivityViewModel.Comments
                };

                _employeeActivityProvider.AddEmployee(employeeActivity);
                return RedirectToAction("InterestedPersonListings");                
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public IActionResult InterestedPersonListings()
        {
            var employeeActivities = _employeeActivityProvider.GetEmployeeActivities();
            ViewData["employeeActivities"] = employeeActivities;
            return View();
        }
    }
}
