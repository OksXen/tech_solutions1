using TechSolutionsLibs.Helper;
using TechSolutionsLibs.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

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
