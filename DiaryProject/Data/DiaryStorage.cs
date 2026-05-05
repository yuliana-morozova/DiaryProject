using DiaryProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace DiaryProject.Data
{
    public static class DiaryStorage
    {
        private static List<DiaryEntry> _entries = new List<DiaryEntry>
        {
            new DiaryEntry { Id = 1, Title = "Перший запис", Content = "Перша лб" }
        };

        public static List<DiaryEntry> GetAllEntries() => _entries.OrderByDescending(e => e.CreatedAt).ToList();

        public static DiaryEntry? GetEntryById(int id) => _entries.FirstOrDefault(e => e.Id == id);

        public static void AddEntry(DiaryEntry entry)
        {
            entry.Id = _entries.Any() ? _entries.Max(e => e.Id) + 1 : 1;
            entry.CreatedAt = System.DateTime.Now;
            _entries.Add(entry);
        }

        public static void UpdateEntry(DiaryEntry updatedEntry)
        {
            var existing = GetEntryById(updatedEntry.Id);
            if (existing != null)
            {
                existing.Title = updatedEntry.Title;
                existing.Content = updatedEntry.Content;
            }
        }

        public static void DeleteEntry(int id)
        {
            var existing = GetEntryById(id);
            if (existing != null)
            {
                _entries.Remove(existing);
            }
        }
    }
}