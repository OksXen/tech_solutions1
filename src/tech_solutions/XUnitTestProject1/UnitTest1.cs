using System;
using TechSolutionsLibs.Model;
using TechSolutionsLibs.Provider;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //arange
            EmployeeActivity employeeActivity = new EmployeeActivity()
            {
                FirstName = "xUnit Fname",
                LastName = "xUnit lname",
                EmailAddress = "xUnit email",
                ActivityName = "xUnit activityname",
                Comments = "xUnit comments",
            };


            ActivityDBContext activityDBContext = new ActivityDBContext(DbOptionsFactory.DbContextOptions);
            EmployeeActivityProvider employeeActivityProvider = new EmployeeActivityProvider(activityDBContext);
            var returnValue = employeeActivityProvider.AddEmployee(employeeActivity);


            Assert.NotEqual(returnValue, -1);
        }
    }
}
