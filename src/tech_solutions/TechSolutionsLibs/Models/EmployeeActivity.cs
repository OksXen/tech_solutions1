using System.ComponentModel.DataAnnotations;

namespace TechSolutionsLibs.Models
{
    public partial  class EmployeeActivity : IEmployeeActivity
    {
        [Key]
        public int ActivityId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string ActivityName { get; set; }

        public string Comments { get; set; }
    }
}
