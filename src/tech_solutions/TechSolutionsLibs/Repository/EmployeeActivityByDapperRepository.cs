using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechSolutionsLibs.Helper;
using TechSolutionsLibs.Models;
using TechSolutionsLibs.Settings.Interface;



namespace TechSolutionsLibs.Settings
{
    public class EmployeeActivityByDapperRepository: IEmployeeActivityByDapperRepository
    {
        IDBSettings _dBSettings;
        IMemoryCache _memmoryCache;
        ICacheSettings _cacheSettings;

        public EmployeeActivityByDapperRepository(IDBSettings dBSettings, IMemoryCache memmoryCache, ICacheSettings cacheSettings)
        {
            _dBSettings = dBSettings;
            _memmoryCache = memmoryCache;
            _cacheSettings = cacheSettings;
        }

        public int AddEmployee(EmployeeActivity employeeActivity)
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

                if (id > 0)
                {
                    _memmoryCache.Remove(CacheKeysHelper.Entry);
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



                if (_cacheSettings.Enable && _cacheSettings.ExpiresInSeconds > 0)
                {
                    employeeActivities = _memmoryCache.GetOrCreate(CacheKeysHelper.Entry, entry =>
                    {
                        entry.SetSlidingExpiration(TimeSpan.FromSeconds(_cacheSettings.ExpiresInSeconds));
                        entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_cacheSettings.ExpiresInSeconds + 60);
                        IEnumerable<EmployeeActivity> activities; 
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            activities = connection.Query<EmployeeActivity>("select * from EmployeeActivity order by  activityid desc");
                        }

                        return activities;
                    });
                }
                else
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        employeeActivities = connection.Query<EmployeeActivity>("select * from EmployeeActivity order by  activityid desc");
                    }
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
