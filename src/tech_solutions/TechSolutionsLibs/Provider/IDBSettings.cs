using System;
using System.Collections.Generic;
using System.Text;

namespace TechSolutionsLibs.Provider
{
    public interface IDBSettings
    {
        string ConnectionString { get; set; }
    }
}
