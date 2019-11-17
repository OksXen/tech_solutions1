using TechSolutionsLibs.Model;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TechSolutionsLibs.Provider
{
    public class EmployeeActivityProvider : IEmployeeActivityProvider
    {


        IEmployeeActivityDBContext _iEmployeeActivityDBContext;

        public EmployeeActivityProvider(IEmployeeActivityDBContext employeeActivityDBContext)
        {
            _iEmployeeActivityDBContext = employeeActivityDBContext;
        }

        public int AddEmployee(EmployeeActivity employeeActivity)
        {
            try
            {
                if (ReferenceEquals(employeeActivity, null)) throw new Exception("employeeActivity is null");

                _iEmployeeActivityDBContext.EmployeeActivity.Add(employeeActivity);
                _iEmployeeActivityDBContext.SaveChanges();

                if (!ReferenceEquals(employeeActivity, null) && employeeActivity.ActivityId > 0) return employeeActivity.ActivityId;

                return 0;
            }
            catch
            {
                return 0;
            }
        }


        public IList<EmployeeActivity> GetEmployeeActivities()
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
