using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TechSolutionsLibs.Model;
using TechSolutionsLibs.Provider;

namespace TechSolutionsLibs.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EmployeeActivityController
    {
        IEmployeeActivityProvider _employeeActivityProvider;

        public EmployeeActivityController(IEmployeeActivityProvider employeeActivityProvider)
        {
            _employeeActivityProvider = employeeActivityProvider;
        }

        [HttpGet]
        public IEnumerable<EmployeeActivity> Get()
        {

            return _employeeActivityProvider.GetEmployeeActivities().ToArray();           
        }

        [HttpPost]
        [Route("AddEmployeeActivityByForm")]        
        public int AddEmployeeActivityByForm([FromForm] EmployeeActivity employeeActivity)
        {
            return _employeeActivityProvider.AddEmployee(employeeActivity);            
        }
        
        [HttpPost]
        [Route("AddEmployeeActivityByBody")]        
        public int AddEmployeeActivityByBody([FromBody] EmployeeActivity employeeActivity)
        {
            return _employeeActivityProvider.AddEmployee(employeeActivity);            
        }
    }
}
