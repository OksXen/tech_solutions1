using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechSolutionsLibs.Models;
using TechSolutionsLibs.Settings.Interface;

namespace TechSolutionsLibs.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EmployeeActivityApiController
    {
        IEmployeeActivityRepository _employeeActivityProvider;        

        public EmployeeActivityApiController(IEmployeeActivityRepository employeeActivityProvider)
        {
            _employeeActivityProvider = employeeActivityProvider;
            
        }

        [HttpGet]
        public IEnumerable<EmployeeActivity> Get()
        {
            var array = new EmployeeActivity[0];            
            var employeeActivities = _employeeActivityProvider.GetEmployeeActivities().ToList();

            if (!ReferenceEquals(employeeActivities, null) && employeeActivities.Count > 0)
            {
                array = new EmployeeActivity[employeeActivities.Count];
                employeeActivities.CopyTo(array, 0);
            }
            return employeeActivities.ToArray();

        }

        [HttpPost]
        [Route("AddEmployeeActivityByForm")]        
        public async Task<int> AddEmployeeActivityByForm([FromForm] EmployeeActivity employeeActivity)
        {
            return await _employeeActivityProvider.AddEmployee(employeeActivity);            
        }
        
        [HttpPost]
        [Route("AddEmployeeActivityByBody")]        
        public async Task<int> AddEmployeeActivityByBody([FromBody] EmployeeActivity employeeActivity)
        {
            return await _employeeActivityProvider.AddEmployee(employeeActivity);            
        }
    }
}
