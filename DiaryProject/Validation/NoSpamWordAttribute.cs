using System.ComponentModel.DataAnnotations;

namespace DiaryProject.Validation
{
    public class NoSpamWordAttribute : ValidationAttribute
    {
        private readonly string _badWord;

        public NoSpamWordAttribute(string badWord)
        {
            _badWord = badWord.ToLower();
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string text = value.ToString()!.ToLower();
                if (text.Contains(_badWord))
                {
                    return new ValidationResult(ErrorMessage ?? $"Використання слова '{_badWord}' заборонено!");
                }
            }
            return ValidationResult.Success; 
        }
    }
}