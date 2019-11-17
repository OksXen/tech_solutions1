using System;
using System.Collections.Generic;
using System.Text;

namespace TechSolutionsLibs.Model
{
   public interface IActivity
   {
        public int ActivityId { get; set; }        
        public string ActivityName { get; set; }
        public string Comments { get; set; }
   }
}
