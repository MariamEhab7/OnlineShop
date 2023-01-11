using System.ComponentModel.DataAnnotations;

namespace DAL;

public class Category
{
    public Guid CategoryId { get; set; }
    [Required]
    public string CategoryName { get; set; }
}
