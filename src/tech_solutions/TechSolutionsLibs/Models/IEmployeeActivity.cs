namespace TechSolutionsLibs.Models
{
    public interface IEmployeeActivity 
    {
        int ActivityId { get; set; }

        string FirstName { get; set; }
        string LastName { get; set; }

        string EmailAddress { get; set; }

        string ActivityName { get; set; }

        string Comments { get; set; }
    }
}
