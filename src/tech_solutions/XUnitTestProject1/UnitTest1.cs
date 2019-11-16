using System;
using System.Collections.Generic;
using TechSolutionsLibs.Model;
using TechSolutionsLibs.Provider;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void AddEmployeeTest()
        {
            //arange
            EmployeeActivity employeeActivity = new EmployeeActivity()
            {
                FirstName = "tech solution Fname",
                LastName = "tech solution lname",
                EmailAddress = "tech solution email",
                ActivityName = "tech solution activityname",
                Comments = "tech solution comments",
            };

            //act
            ActivityDBContext activityDBContext = new ActivityDBContext(DbOptionsFactory.DbContextOptions);
            EmployeeActivityProvider employeeActivityProvider = new EmployeeActivityProvider(activityDBContext);
            var returnValue = employeeActivityProvider.AddEmployee(employeeActivity);

            //asert
            Assert.NotEqual(returnValue, -1);
        }

        [Fact]
        public void GetEmployeesTest()
        {
            //act
            //arange
            ActivityDBContext activityDBContext = new ActivityDBContext(DbOptionsFactory.DbContextOptions);
            EmployeeActivityProvider employeeActivityProvider = new EmployeeActivityProvider(activityDBContext);
            var returnValue = employeeActivityProvider.GetEmployeeActivities();

            //assert
            Assert.NotNull(returnValue);
        }
    }
}
