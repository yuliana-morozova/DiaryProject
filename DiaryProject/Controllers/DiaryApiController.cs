using Microsoft.AspNetCore.Mvc;
using DiaryProject.Data;
using DiaryProject.Models;

namespace DiaryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiaryApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(DiaryStorage.GetAllEntries());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entry = DiaryStorage.GetEntryById(id);
            if (entry == null) return NotFound("Запис не знайдено");

            return Ok(entry);
        }

        [HttpPost]
        public IActionResult Create(DiaryEntry newEntry)
        {
            DiaryStorage.AddEntry(newEntry);
            return CreatedAtAction(nameof(GetById), new { id = newEntry.Id }, newEntry);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, DiaryEntry updatedEntry)
        {
            var existing = DiaryStorage.GetEntryById(id);
            if (existing == null) return NotFound("Запис не знайдено");

            updatedEntry.Id = id; 
            DiaryStorage.UpdateEntry(updatedEntry);
            return Ok(updatedEntry);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = DiaryStorage.GetEntryById(id);
            if (existing == null) return NotFound("Запис не знайдено");

            DiaryStorage.DeleteEntry(id);
            return NoContent();
        }
    }
}