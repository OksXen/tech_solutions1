using System;
using TechSolutionsLibs.Model;
using TechSolutionsLibs.Provider;
using Xunit;

namespace XUnitTestProject1
{
    public class EmployeeActivityProviderTest
    {
        /// <summary>
        /// ensures add employee returns identity id
        /// </summary>
        [Fact]
        public void AddEmployeeTest()
        {
            //arrange
            IDBSettings dBSettings = new DBSettings();
            IEmployeeActivityDBContext employeeActivityDBContext = new EmployeeActivityDBContext(dBSettings);
            IEmployeeActivityProvider employeeActivityProvider = new EmployeeActivityProvider(employeeActivityDBContext);

            var tics = DateTime.Now.Ticks;
            EmployeeActivity employeeActivity = new EmployeeActivity()
            {
                FirstName = string.Concat("FName_", tics),
                LastName = string.Concat("LName_", tics),
                EmailAddress = string.Concat(tics, "@email.com"),
                ActivityName = string.Concat("Activity_Name_", tics),
                Comments = string.Concat("Comments_", tics)
            };

            //act
            var result = employeeActivityProvider.AddEmployee(employeeActivity);

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
            IEmployeeActivityDBContext employeeActivityDBContext = new EmployeeActivityDBContext(dBSettings);
            IEmployeeActivityProvider employeeActivityProvider = new EmployeeActivityProvider(employeeActivityDBContext);

            //act
            var result = employeeActivityProvider.GetEmployeeActivities();

            //assert            
            Assert.NotNull(result);
            Assert.NotEqual(0, result.Count);
        }
    }
}
