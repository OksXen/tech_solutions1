using TechSolutionsLibs.Model;
using Microsoft.EntityFrameworkCore;

namespace TechSolutionsLibs.Provider
{
    public interface IEmployeeActivityDBContext
    {
        DbSet<EmployeeActivity> EmployeeActivity { get; set; }
        void SaveChanges();
    }
}
