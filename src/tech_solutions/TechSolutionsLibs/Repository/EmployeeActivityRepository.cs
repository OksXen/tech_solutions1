using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TechSolutionsLibs.Helper;
using TechSolutionsLibs.Models;
using TechSolutionsLibs.Settings.Interface;
using TechSolutionsLibs.Settings.Interface;

namespace TechSolutionsLibs.Settings
{
    public class EmployeeActivityRepository : IEmployeeActivityRepository
    {


        IEmployeeActivityDBContext _iEmployeeActivityDBContext;
        IMemoryCache _memmoryCache;
        ICacheSettings _cacheSettings;

        public EmployeeActivityRepository(IEmployeeActivityDBContext employeeActivityDBContext, IMemoryCache memmoryCache, ICacheSettings cacheSettings)
        {
            _iEmployeeActivityDBContext = employeeActivityDBContext;
            _memmoryCache = memmoryCache;
            _cacheSettings = cacheSettings;
        }

        public async Task<int> AddEmployee(EmployeeActivity employeeActivity)
        {
            try
            {
                if (ReferenceEquals(employeeActivity, null)) throw new Exception("employeeActivity is null");

               await _iEmployeeActivityDBContext.EmployeeActivity.AddAsync(employeeActivity);
                _iEmployeeActivityDBContext.SaveChanges();

                if (!ReferenceEquals(employeeActivity, null) && employeeActivity.ActivityId > 0)
                {
                    _memmoryCache.Remove(CacheKeysHelper.Entry);
                    return employeeActivity.ActivityId;
                }

                return 0;
            }
            catch
            {
                return 0;
            }
        }


        public IEnumerable<EmployeeActivity> GetEmployeeActivities()
        {
            try
            {

                IEnumerable<EmployeeActivity> employeeActivities = null;

                if (_cacheSettings.Enable && _cacheSettings.ExpiresInSeconds>0)
                {
                    employeeActivities = _memmoryCache.GetOrCreate(CacheKeysHelper.Entry, entry =>
                    {                        
                        entry.SetSlidingExpiration(TimeSpan.FromSeconds(_cacheSettings.ExpiresInSeconds));
                        entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_cacheSettings.ExpiresInSeconds + 60);
                        return _iEmployeeActivityDBContext.EmployeeActivity.OrderByDescending(x => x.ActivityId).ToList();
                    });
                }
                else
                {
                    employeeActivities = _iEmployeeActivityDBContext.EmployeeActivity.OrderByDescending(x => x.ActivityId).ToList();
                }

                if (ReferenceEquals(employeeActivities, null)) throw new Exception("employeeActivities is null.");

                return employeeActivities;
            }
            catch(Exception ex)
            {
                return null;
            }
          

        }




       
    }
}
