using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsManagementApp.Modals
{
   
    public class Contact
    {
        static int newRowId = 1;
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = newRowId++;
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public required string Email { get; set; }
        //public Contact()
        //{
        //    Id = newRowId++;
        //}
    }
}
