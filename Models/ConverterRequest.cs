using System.ComponentModel.DataAnnotations;

namespace UnitConverter.Models
{
    public class ConverterRequest
    {
        [Required(ErrorMessage = "FromUnit is required.")]
        public string FromUnit { get; set; } = string.Empty;

        [Required(ErrorMessage = "ToUnit is required.")]
        public string ToUnit { get; set; } = string.Empty;

        [Required(ErrorMessage = "Value is required.")]
        public double Value { get; set; }
    }
}
