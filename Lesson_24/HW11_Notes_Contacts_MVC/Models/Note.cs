using System;
using System.ComponentModel.DataAnnotations;

namespace HW11_Notes_Contacts_MVC.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "limit 100 characters")]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [StringLength(200, ErrorMessage = "limit 200 characters")]
        public string Tags { get; set; } = string.Empty;
    }
}
