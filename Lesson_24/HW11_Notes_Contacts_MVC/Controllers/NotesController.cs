using Microsoft.AspNetCore.Mvc;
using HW11_Notes_Contacts_MVC.Data;
using HW11_Notes_Contacts_MVC.Models;
using System.Linq;

namespace HW11_Notes_Contacts_MVC.Controllers
{
    public class NotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var notes = _context.Notes.ToList();
            return View(notes);
        }

        public IActionResult Details(int id)
        {
            var note = _context.Notes.Find(id);
            if (note == null) return NotFound();
            return View(note);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Note note, string tagsInput)
        {
            note.Tags = tagsInput;
            _context.Notes.Add(note);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var note = _context.Notes.Find(id);
            if (note == null) return NotFound();


            return View(note);
        }

        [HttpPost]
        public IActionResult Edit(Note note, string tagsInput)
        {
            var existingNote = _context.Notes.Find(note.Id);
            if (existingNote == null) return NotFound();

            existingNote.Title = note.Title;
            existingNote.Content = note.Content;
            existingNote.Tags = tagsInput;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var note = _context.Notes.Find(id);
            if (note == null) return NotFound();

            return View(note);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var note = _context.Notes.Find(id);
            if (note == null) return NotFound();

            _context.Notes.Remove(note);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
