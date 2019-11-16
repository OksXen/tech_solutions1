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
        [Route("AddEmployeeActivity")]
        public int AddEmployeeActivity([FromBody] EmployeeActivity employeeActivity)
        {
            return EmployeeActivityHelper.AddEmployeeActivity(employeeActivity);
        }
    }
}
