using System.Collections.Generic;
using TechSolutionsLibs.Model;

namespace TechSolutionsLibs.Provider
{
    public interface IEmployeeActivityProvider
    {

        int AddEmployee(EmployeeActivity employeeActivity);

        IList<EmployeeActivity> GetEmployeeActivities();
    }
}
