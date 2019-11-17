using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechSolutionsLibs.Model;
using TechSolutionsLibs.Repository.Interface;

namespace TechSolutionsLibs.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EmployeeActivityController
    {
        IEmployeeActivityRepository _employeeActivityProvider;

        public EmployeeActivityController(IEmployeeActivityRepository employeeActivityProvider)
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
