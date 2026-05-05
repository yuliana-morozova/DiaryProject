using System;
using System.ComponentModel.DataAnnotations;

namespace DiaryProject.Models
{
    public class DiaryEntry
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Заголовок є обов'язковим")]
        [Display(Name = "Заголовок")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Текст запису є обов'язковим")]
        [Display(Name = "Текст запису")]
        public string? Content { get; set; }

        [Display(Name = "Дата створення")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}