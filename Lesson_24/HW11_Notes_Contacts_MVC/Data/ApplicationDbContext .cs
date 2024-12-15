using Microsoft.EntityFrameworkCore;
using HW11_Notes_Contacts_MVC.Models;

namespace HW11_Notes_Contacts_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; } = null!;
        public DbSet<Contact> Contacts { get; set; } = null!;
    }
}
