﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TechSolutionsLibs.Models;

namespace TechSolutionsLibs.Repository.Interface
{
    public interface IEmployeeActivityRepository
    {

        Task<int> AddEmployee(EmployeeActivity employeeActivity);

        IEnumerable<EmployeeActivity> GetEmployeeActivities();
    }
}