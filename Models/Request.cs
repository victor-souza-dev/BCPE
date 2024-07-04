using System.ComponentModel.DataAnnotations;

namespace ExtractCssValuesToJson.Models {
    public class Request: IValidatableObject {
        [Required(ErrorMessage = "You must upload at least one file.")]
        public List<IFormFile> Archives { get; set; }

        [Required(ErrorMessage = "Configs is required.")]
        [MinLength(1, ErrorMessage = "At least one configuration must be provided.")]
        public List<FormatConfigCss> Configs { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            if (Archives.Count > 1000) {
                yield return new ValidationResult(
                    "The number of files must be between 1 and 1000.",
                    new[] { nameof(Archives) });
            }
        }
    }

    public class FormatConfigCss {
        [Required(ErrorMessage = "ClassName is required.")]
        [MinLength(1, ErrorMessage = "ClassName must be at least 1 character long.")]
        [MaxLength(100, ErrorMessage = "ClassName cannot be longer than 100 characters.")]
        public string ClassName { get; set; }

        [Required(ErrorMessage = "KeyValue list is required.")]
        [MinLength(1, ErrorMessage = "At least one KeyValue must be provided.")]
        public List<KeyValueCss> KeyValue { get; set; }
    }

    public class KeyValueCss {
        [Required(ErrorMessage = "Property is required.")]
        [MinLength(1, ErrorMessage = "Property must be at least 1 character long.")]
        [MaxLength(50, ErrorMessage = "Property cannot be longer than 50 characters.")]
        public string Property { get; set; }

        [Required(ErrorMessage = "ResultName is required.")]
        [MinLength(1, ErrorMessage = "ResultName must be at least 1 character long.")]
        [MaxLength(50, ErrorMessage = "ResultName cannot be longer than 50 characters.")]
        public string ResultName { get; set; }
    }
}
