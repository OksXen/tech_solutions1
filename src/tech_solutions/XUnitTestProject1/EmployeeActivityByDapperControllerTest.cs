using Microsoft.AspNetCore.Mvc;
using System;
using TechSolutionsLibs.Controllers;
using TechSolutionsLibs.Models;
using TechSolutionsLibs.Repository;
using Xunit;

namespace XUnitTestProject1
{
    public class EmployeeActivityByDapperControllerTest
    {
        [Fact]
        public void IndexTest()
        {
            //arrange
            DBSettings dBSettings = new DBSettings();
            
            EmployeeActivityByDapperRepository employeeActivityRepository = new EmployeeActivityByDapperRepository(dBSettings);
            EmployeeActivityByDapperController employeeActivityController = new EmployeeActivityByDapperController(employeeActivityRepository);


            //act
            var result = employeeActivityController.Index();


            //assert
            var viewResult = Assert.IsType<ViewResult>(result);

        }
        //AddEmployeeActivity(EmployeeActivityViewModel employeeActivityViewModel)
        [Fact]
        public void AddEmployeeActivityTest()
        {
            //arrange
            DBSettings dBSettings = new DBSettings();
            EmployeeActivityByDapperRepository employeeActivityRepository = new EmployeeActivityByDapperRepository(dBSettings);
            EmployeeActivityByDapperController employeeActivityController = new EmployeeActivityByDapperController(employeeActivityRepository);

            var tics = DateTime.Now.Ticks;
            EmployeeActivityViewModel employeeActivity = new EmployeeActivityViewModel()
            {
                FirstName = string.Concat("FName_", tics),
                LastName = string.Concat("LName_", tics),
                EmailAddress = string.Concat(tics, "@email.com"),
                ActivityName = string.Concat("Activity_Name_", tics),
                Comments = string.Concat("Comments_", tics)
            };

            //act
            var result = employeeActivityController.AddEmployeeActivity(employeeActivity);


            //assert
            var viewResult = Assert.IsType<RedirectToActionResult>(result);


        }
    }
}
