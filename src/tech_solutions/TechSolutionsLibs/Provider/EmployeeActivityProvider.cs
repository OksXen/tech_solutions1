using TechSolutionsLibs.Model;
using System.Collections.Generic;
using System.Linq;

namespace TechSolutionsLibs.Provider
{
    public class EmployeeActivityProvider
    {
        ActivityDBContext activityDBContext;

        public EmployeeActivityProvider(ActivityDBContext dBContext)
        {
            activityDBContext = dBContext;
        }

        public int AddEmployee(EmployeeActivity employeeActivity)
        {
            try
            {
                activityDBContext.EmployeeActivity.Add(employeeActivity);
                activityDBContext.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public List<EmployeeActivity> GetEmployeeActivities()
        {
            try
            {
                return activityDBContext.EmployeeActivity.ToList();
                                
            }
            catch
            {
                throw;
            }
        }
    }
}
