using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechSolutionsLibs.Models;
using TechSolutionsLibs.Repository.Interface;

namespace TechSolutionsLibs.Controllers
{
    public class EmployeeActivityController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        IEmployeeActivityRepository _employeeActivityProvider;

        //public AddEmployeeActivityController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public EmployeeActivityController(IEmployeeActivityRepository employeeActivityProvider)
        {
            _employeeActivityProvider = employeeActivityProvider;
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}
