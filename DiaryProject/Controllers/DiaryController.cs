using Microsoft.AspNetCore.Mvc;
using DiaryProject.Data;

namespace DiaryProject.Controllers
{
    public class DiaryController : Controller
    {
        public IActionResult Index()
        {
            var entries = DiaryStorage.GetAllEntries();

            return View(entries);
        }
    }
}