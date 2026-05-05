using Microsoft.AspNetCore.Mvc;
using DiaryProject.Data;
using DiaryProject.Models;

namespace DiaryProject.Controllers
{
    public class DiaryController : Controller
    {
        public IActionResult Index()
        {
            var entries = DiaryStorage.GetAllEntries();
            return View(entries);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        public IActionResult Create(DiaryEntry entry)
        {
            if (ModelState.IsValid) 
            {
                DiaryStorage.AddEntry(entry);
                return RedirectToAction("Index");
            }
            return View(entry); 
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var entry = DiaryStorage.GetEntryById(id);
            if (entry == null) return NotFound();

            return View(entry);
        }

        [HttpPost]
        public IActionResult Edit(DiaryEntry entry)
        {
            if (ModelState.IsValid)
            {
                DiaryStorage.UpdateEntry(entry);
                return RedirectToAction("Index");
            }
            return View(entry);
        }

        public IActionResult Delete(int id)
        {
            DiaryStorage.DeleteEntry(id);
            return RedirectToAction("Index");
        }
    }
}