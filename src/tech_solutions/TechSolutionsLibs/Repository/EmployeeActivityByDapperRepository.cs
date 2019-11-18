using Dapper;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechSolutionsLibs.Models;
using TechSolutionsLibs.Repository.Interface;



namespace TechSolutionsLibs.Repository
{
    public class EmployeeActivityByDapperRepository: IEmployeeActivityRepository
    {
        IDBSettings _dBSettings;

        public EmployeeActivityByDapperRepository(IDBSettings dBSettings)
        {
            _dBSettings = dBSettings;
        }

        public async Task<int> AddEmployee(EmployeeActivity employeeActivity)
        {
            try
            {

                if (ReferenceEquals(employeeActivity, null)) throw new Exception("employeeActivity is null");

                var connectionString = _dBSettings.ConnectionString;
                var sql = "INSERT INTO EmployeeActivity VALUES(@fName, @lname, @email, @aname, @comments);SELECT CAST(SCOPE_IDENTITY() as int) ";
                var id = 0;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var result = connection.Query<int>(sql, new { @fName= employeeActivity.FirstName, 
                        @lname= employeeActivity.LastName, 
                        @email= employeeActivity.EmailAddress, 
                        @aname= employeeActivity.ActivityName, @comments= employeeActivity.Comments
                    });                    
                  
                    if (result.Any()) id = (int)result.Single();
                    
                }

                return id;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }


        public IEnumerable<EmployeeActivity> GetEmployeeActivities()
        {
            try
            {

                var connectionString = _dBSettings.ConnectionString;
                IEnumerable<EmployeeActivity> employeeActivities;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    employeeActivities = connection.Query<EmployeeActivity>("select * from EmployeeActivity order by  activityid desc");
                }

                if (ReferenceEquals(employeeActivities, null)) throw new Exception("employeeActivities is null.");

                return employeeActivities;
            }
            catch (Exception ex)
            {
                return null;
            }


        }
    }
}
