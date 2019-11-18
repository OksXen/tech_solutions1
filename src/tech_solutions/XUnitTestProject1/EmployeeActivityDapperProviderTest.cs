using System;
using System.Linq;
using TechSolutionsLibs.Models;
using TechSolutionsLibs.Repository;
using TechSolutionsLibs.Repository.Interface;
using Xunit;

namespace XUnitTestProject1
{
    public class EmployeeActivityDapperProviderTest
    {
        /// <summary>
        /// ensures add employee returns identity id
        /// </summary>
        [Fact]
        public async void AddEmployeeTest()
        {
            //arrange
            IDBSettings dBSettings = new DBSettings();
            
            EmployeeActivityByDapperRepository employeeActivityProvider = new EmployeeActivityByDapperRepository(dBSettings);

            var tics = DateTime.Now.Ticks;
            EmployeeActivity employeeActivity = new EmployeeActivity()
            {
                FirstName = string.Concat("dapper_", tics),
                LastName = string.Concat("LName_", tics),
                EmailAddress = string.Concat(tics, "@email.com"),
                ActivityName = string.Concat("Activity_Name_", tics),
                Comments = string.Concat("Comments_", tics)
            };

            //act
            var result = await employeeActivityProvider.AddEmployee(employeeActivity);

            //assert
            Assert.NotEmpty(dBSettings.ConnectionString);
            Assert.NotNull(employeeActivity);
            Assert.NotEqual<int>(0, result);
        }



        /// <summary>
        /// ensures get employ activities returns values and not null
        /// </summary>
        [Fact]
        public void GetEmployeeActivitiesTest()
        {
            //arrange
            IDBSettings dBSettings = new DBSettings();
            EmployeeActivityByDapperRepository employeeActivityProvider = new EmployeeActivityByDapperRepository(dBSettings);

            //act
            var result = employeeActivityProvider.GetEmployeeActivities().ToList();

            //assert            
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
