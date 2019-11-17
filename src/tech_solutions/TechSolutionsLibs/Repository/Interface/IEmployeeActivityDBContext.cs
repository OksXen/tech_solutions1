using TechSolutionsLibs.Model;
using Microsoft.EntityFrameworkCore;

namespace TechSolutionsLibs.Repository.Interface
{
    public interface IEmployeeActivityDBContext
    {
        DbSet<EmployeeActivity> EmployeeActivity { get; set; }
        void SaveChanges();
    }
}
