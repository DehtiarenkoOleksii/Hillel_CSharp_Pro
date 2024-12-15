using System.ComponentModel.DataAnnotations;

namespace HW11_Notes_Contacts_MVC.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Limit 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        public string Phone { get; set; } = string.Empty;

        // Optional
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        public string? AlternativePhone { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(200, ErrorMessage = "Limit 50 characters")]
        public string Description { get; set; } = string.Empty;
    }
}
