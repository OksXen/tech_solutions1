using System.ComponentModel.DataAnnotations;

namespace TechSolutionsLibs.Models
{
    public partial  class EmployeeActivityViewModel:IEmployeeActivity
    {
        [Key]
        public int ActivityId { get; set; }


        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage ="Please select activity")]
        [Display(Name = "Activity Name")]
        public string ActivityName { get; set; }

  
        [Required]
        [Display(Name = "Comments")]
        public string Comments { get; set; }
    }
}
