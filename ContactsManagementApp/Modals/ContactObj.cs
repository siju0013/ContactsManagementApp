using System.ComponentModel.DataAnnotations;

namespace ContactsManagementApp.Modals
{
    public class ContactObj
    {
        [Required]
        public  string FirstName { get; set; }
        [Required]
        public  string LastName { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
    }
}
