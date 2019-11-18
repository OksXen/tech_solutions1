using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechSolutionsLibs.Models;
using TechSolutionsLibs.Settings;
using TechSolutionsLibs.Settings.Interface;
using Xunit;

namespace XUnitTestProject1
{
    public class EmployeeActivityDBContextTest
    {
       
        /// <summary>
        /// Ensures Employeeactivity data set is not null
        /// </summary>
        [Fact]
        public void EmployeeActivityDataSetIsNotNull()
        {
            //arrange
            IDBSettings dBSettings = new DBSettings();
            IEmployeeActivityDBContext employeeActivityDBContext = new EmployeeActivityDBContext(dBSettings);

            //act
            var employeeActivity =  employeeActivityDBContext.EmployeeActivity;


            //assert
            Assert.NotEmpty(dBSettings.ConnectionString);
            Assert.NotNull(employeeActivity);

        }



        /// <summary>
        /// ensures employee acitivity object is being saved
        /// </summary>
        [Fact]
        public void SaveChangesUnitTest()
        {
            //arrange
            IDBSettings dBSettings = new DBSettings();
            IEmployeeActivityDBContext employeeActivityDBContext = new EmployeeActivityDBContext(dBSettings);
            var tics = DateTime.Now.Ticks;
            EmployeeActivity employeeActivity = new EmployeeActivity()
            {
                FirstName = string.Concat("FName_",tics),
                LastName = string.Concat("LName_", tics),
                EmailAddress = string.Concat(tics, "@email.com"),
                ActivityName = string.Concat("Activity_Name_", tics),
                Comments = string.Concat("Comments_", tics)
            };

            //act
            var employeeActivityDbSet = employeeActivityDBContext.EmployeeActivity;
            employeeActivityDbSet.Add(employeeActivity);
            employeeActivityDBContext.SaveChanges();
            var result = employeeActivityDbSet.Where(x=> x.FirstName.Equals(employeeActivity.FirstName)).FirstOrDefault();

            //assert
            Assert.NotEmpty(dBSettings.ConnectionString);
            Assert.NotNull(employeeActivity);
            Assert.Equal(result, employeeActivity);

        }
    }
}
