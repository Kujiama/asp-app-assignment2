using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public enum CategoryType
    {
        Electronics,
        Fashion,
        Home,
        Sports
    }

    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select a Category")]
        public CategoryType Type { get; set; }
    }
}
