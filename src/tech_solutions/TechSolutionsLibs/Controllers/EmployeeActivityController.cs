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
        public IEnumerable<IEmployeeActivity> Get()
        {
            var array = new EmployeeActivity[0];
            var employeeActivities = _employeeActivityProvider.GetEmployeeActivities();

            if (!ReferenceEquals(employeeActivities, null) && employeeActivities.Count>0) 
            {
                array = new EmployeeActivity[employeeActivities.Count];
                employeeActivities.CopyTo(array, 0);
            } 
            return array;

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
