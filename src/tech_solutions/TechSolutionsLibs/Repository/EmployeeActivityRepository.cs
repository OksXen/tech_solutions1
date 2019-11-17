using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechSolutionsLibs.Models;
using TechSolutionsLibs.Repository.Interface;

namespace TechSolutionsLibs.Repository
{
    public class EmployeeActivityRepository : IEmployeeActivityRepository
    {


        IEmployeeActivityDBContext _iEmployeeActivityDBContext;

        public EmployeeActivityRepository(IEmployeeActivityDBContext employeeActivityDBContext)
        {
            _iEmployeeActivityDBContext = employeeActivityDBContext;
        }

        public async Task<int> AddEmployee(EmployeeActivity employeeActivity)
        {
            try
            {
                if (ReferenceEquals(employeeActivity, null)) throw new Exception("employeeActivity is null");

               await _iEmployeeActivityDBContext.EmployeeActivity.AddAsync(employeeActivity);
                _iEmployeeActivityDBContext.SaveChanges();

                if (!ReferenceEquals(employeeActivity, null) && employeeActivity.ActivityId > 0) return employeeActivity.ActivityId;

                return 0;
            }
            catch
            {
                return 0;
            }
        }


        public IEnumerable<EmployeeActivity> GetEmployeeActivities()
        {
            try
            {
                var employeeActivities = _iEmployeeActivityDBContext.EmployeeActivity.OrderByDescending(x => x.ActivityId).ToList();


                if (ReferenceEquals(employeeActivities, null)) throw new Exception("employeeActivities is null.");

                return employeeActivities;
            }
            catch
            {
                return null;
            }
          

        }

       
    }
}
