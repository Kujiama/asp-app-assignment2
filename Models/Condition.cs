using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public enum ConditionType
    {
        BrandNew,
        Used,
        Refurbished,
        OpenBox
    }

    public class Condition
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select a Condition")]
        public ConditionType Type { get; set; }
    }
}
