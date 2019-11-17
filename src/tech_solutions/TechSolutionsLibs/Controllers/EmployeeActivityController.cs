using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TechSolutionsLibs.Helper;
using TechSolutionsLibs.Model;

namespace TechSolutionsLibs.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EmployeeActivityController
    {
        public EmployeeActivityController()
        {
            
        }

        [HttpGet]
        public IEnumerable<EmployeeActivity> Get()
        {

            return EmployeeActivityHelper.GetEmployeeActivities().ToArray();

            
        }

        [HttpPost]
        [Route("AddEmployeeActivityByForm")]        
        public int AddEmployeeActivityByForm([FromForm] EmployeeActivity employeeActivity)
        {
            return EmployeeActivityHelper.AddEmployeeActivity(employeeActivity);
        }
        
        [HttpPost]
        [Route("AddEmployeeActivityByBody")]        
        public int AddEmployeeActivityByBody([FromBody] EmployeeActivity employeeActivity)
        {
            return EmployeeActivityHelper.AddEmployeeActivity(employeeActivity);
        }
    }
}
