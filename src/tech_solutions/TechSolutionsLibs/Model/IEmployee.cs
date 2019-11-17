using System;
using System.Collections.Generic;
using System.Text;

namespace TechSolutionsLibs.Model
{
    public interface IEmployee
    {        
        string FirstName { get; set; }
        string LastName { get; set; }
        string EmailAddress { get; set; }        
    }
}
