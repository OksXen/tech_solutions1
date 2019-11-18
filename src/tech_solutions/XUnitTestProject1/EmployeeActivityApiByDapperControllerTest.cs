using System;
using System.Collections.Generic;
using System.Linq;
using TechSolutionsLibs.Controllers;
using TechSolutionsLibs.Models;
using TechSolutionsLibs.Repository;
using Xunit;

namespace XUnitTestProject1
{
    public class EmployeeActivityApiByDapperControllerTest
    {
        [Fact]
        public void GetTest()
        {
            //arrange
            DBSettings dBSettings = new DBSettings();            
            EmployeeActivityByDapperRepository employeeActivityRepository = new EmployeeActivityByDapperRepository(dBSettings);
            EmployeeActivityApiByDapperController employeeActivityController = new EmployeeActivityApiByDapperController(employeeActivityRepository);


            //act
            var result = employeeActivityController.Get();

            result.Any();
            //assert
            Assert.NotNull(result);
            Assert.True(result.Any());

        }

        [Fact]
        public async void AddEmployeeActivityByFormTest()
        {
            //arrange
            DBSettings dBSettings = new DBSettings();
            EmployeeActivityByDapperRepository employeeActivityRepository = new EmployeeActivityByDapperRepository(dBSettings);
            EmployeeActivityApiByDapperController employeeActivityController = new EmployeeActivityApiByDapperController(employeeActivityRepository);

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
            var result = await employeeActivityController.AddEmployeeActivityByBody(employeeActivity);


            //assert
            Assert.NotEqual<int>(0, result);
            

        }


    }
}
