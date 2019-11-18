using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;
using TechSolutionsLibs.Controllers;
using TechSolutionsLibs.Models;
using TechSolutionsLibs.Settings;
using Xunit;
using XUnitTestProject1.Helper;

namespace XUnitTestProject1
{
    public class EmployeeActivityApiByDapperControllerTest
    {
        [Fact]
        public void GetTest()
        {
            //arrange
            DBSettings dBSettings = new DBSettings();
            IMemoryCache memoryCache = MemoryCacheHelper.GetMemoryCache();
            CacheSettings cacheSettings = new CacheSettings();
            EmployeeActivityByDapperRepository employeeActivityRepository = new EmployeeActivityByDapperRepository(dBSettings, memoryCache, cacheSettings);
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
            IMemoryCache memoryCache = MemoryCacheHelper.GetMemoryCache();
            CacheSettings cacheSettings = new CacheSettings();
            EmployeeActivityByDapperRepository employeeActivityRepository = new EmployeeActivityByDapperRepository(dBSettings, memoryCache, cacheSettings);
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
