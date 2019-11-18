using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using TechSolutionsLibs.Controllers;
using TechSolutionsLibs.Models;
using TechSolutionsLibs.Settings;
using Xunit;
using XUnitTestProject1.Helper;

namespace XUnitTestProject1
{



    public class EmployeeActivityApiControllerTest
    {

        

        [Fact]
        public void GetTest()
        {
            //arrange
            DBSettings dBSettings = new DBSettings();
            IMemoryCache memoryCache = MemoryCacheHelper.GetMemoryCache();
            CacheSettings cacheSettings = new CacheSettings();
            EmployeeActivityDBContext employeeActivityDBContext = new EmployeeActivityDBContext(dBSettings);
            EmployeeActivityRepository employeeActivityRepository = new EmployeeActivityRepository(employeeActivityDBContext, memoryCache, cacheSettings);
            EmployeeActivityApiController employeeActivityController = new EmployeeActivityApiController(employeeActivityRepository);


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
            IMemoryCache memoryCache = MemoryCacheHelper.GetMemoryCache();
            CacheSettings cacheSettings = new CacheSettings();
            EmployeeActivityDBContext employeeActivityDBContext = new EmployeeActivityDBContext(dBSettings);
            EmployeeActivityRepository employeeActivityRepository = new EmployeeActivityRepository(employeeActivityDBContext, memoryCache, cacheSettings);
            EmployeeActivityApiController employeeActivityController = new EmployeeActivityApiController(employeeActivityRepository);
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
