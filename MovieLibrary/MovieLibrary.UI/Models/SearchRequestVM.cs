using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.UI.Models
{
    public class SearchRequestVM : IValidatableObject
    {
        public string SearchQuery { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(SearchQuery))
            {
                errors.Add(new ValidationResult("Title required"));
            }

            return errors;
        }
    }
}