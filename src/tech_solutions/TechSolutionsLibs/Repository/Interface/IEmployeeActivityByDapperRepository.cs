using System.Collections.Generic;
using TechSolutionsLibs.Models;

namespace TechSolutionsLibs.Settings.Interface
{
    public interface IEmployeeActivityByDapperRepository
    {

        int AddEmployee(EmployeeActivity employeeActivity);

        IEnumerable<EmployeeActivity> GetEmployeeActivities();
    }
}
