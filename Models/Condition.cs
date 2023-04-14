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
        public ConditionType Type { get; set; }
    }
}
