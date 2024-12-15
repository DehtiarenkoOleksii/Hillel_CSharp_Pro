using Microsoft.AspNetCore.Mvc;
using HW11_Notes_Contacts_MVC.Data;
using HW11_Notes_Contacts_MVC.Models;
using System.Linq;

namespace HW11_Notes_Contacts_MVC.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contacts = _context.Contacts.ToList();
            return View(contacts);
        }

        public IActionResult Details(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null) return NotFound();
            return View(contact);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }

            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null) return NotFound();
            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }

            var existingContact = _context.Contacts.Find(contact.Id);
            if (existingContact == null) return NotFound();

            existingContact.Name = contact.Name;
            existingContact.Phone = contact.Phone;
            existingContact.AlternativePhone = contact.AlternativePhone;
            existingContact.Email = contact.Email;
            existingContact.Description = contact.Description;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null) return NotFound();
            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null) return NotFound();

            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
