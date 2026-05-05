using System;
using System.ComponentModel.DataAnnotations;
using DiaryProject.Validation; 

namespace DiaryProject.Models
{
    public class DiaryEntry
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Заголовок є обов'язковим")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Заголовок має бути від 3 до 100 символів")]
        [NoSpamWord("спам", ErrorMessage = "Заголовок не повинен містити слово 'спам'")] 
        [Display(Name = "Заголовок")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Текст запису є обов'язковим")]
        [Display(Name = "Текст запису")]
        public string? Content { get; set; }

        [Display(Name = "Дата створення")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}