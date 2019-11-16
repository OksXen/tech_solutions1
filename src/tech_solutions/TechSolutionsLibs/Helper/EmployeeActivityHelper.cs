using TechSolutionsLibs.Model;
using TechSolutionsLibs.Provider;
using System.Collections.Generic;

namespace TechSolutionsLibs.Helper
{
    public static class EmployeeActivityHelper
    {
        public static int AddEmployeeActivity(EmployeeActivity employeeActivity)
        {
            try
            {
                ActivityDBContext activityDBContext = new ActivityDBContext(DbOptionsFactory.DbContextOptions);
                EmployeeActivityProvider employeeActivityProvider = new EmployeeActivityProvider(activityDBContext);
                employeeActivityProvider.AddEmployee(employeeActivity);
                return 1;
            }
            catch
            {
                return 0;
            }
        }


        public static List<EmployeeActivity> GetEmployeeActivities()
        {
            try
            {
                ActivityDBContext activityDBContext = new ActivityDBContext(DbOptionsFactory.DbContextOptions);
                EmployeeActivityProvider employeeActivityProvider = new EmployeeActivityProvider(activityDBContext);
                return employeeActivityProvider.GetEmployeeActivities();                
            }
            catch
            {
                return null;
            }
        }
    }
}
