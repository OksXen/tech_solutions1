using TechSolutionsLibs.Model;
using System.Collections.Generic;
using System.Linq;

namespace TechSolutionsLibs.Provider
{
    public class EmployeeActivityProvider : IEmployeeActivityProvider
    {
        //ActivityDBContext activityDBContext;

        //public EmployeeActivityProvider(ActivityDBContext dBContext)
        //{
        //    activityDBContext = dBContext;
        //}

        IEmployeeActivityDBContext _iEmployeeActivityDBContext;

        public EmployeeActivityProvider(IEmployeeActivityDBContext employeeActivityDBContext)
        {
            _iEmployeeActivityDBContext = employeeActivityDBContext;
        }

        public int AddEmployee(EmployeeActivity employeeActivity)
        {
            try
            {
                //activityDBContext.EmployeeActivity.Add(employeeActivity);
                //activityDBContext.SaveChanges();
                _iEmployeeActivityDBContext.EmployeeActivity.Add(employeeActivity);
                _iEmployeeActivityDBContext.SaveChanges();
                _iEmployeeActivityDBContext.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public List<EmployeeActivity> GetEmployeeActivities()
        {
            try
            {
                //return activityDBContext.EmployeeActivity.OrderByDescending(x=> x.ActivityId).ToList();
                return _iEmployeeActivityDBContext.EmployeeActivity.OrderByDescending(x => x.ActivityId).ToList();

            }
            catch
            {
                return null;
            }
        }
    }
}
