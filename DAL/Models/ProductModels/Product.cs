using System.ComponentModel.DataAnnotations;
namespace DAL;

public class Product
{
    public Guid ProductId { get; set; }
    [Required]
    public string ProductName { get; set; }

    public Category Category { get; set; }
    public GenreOfItems GenreOfItems { get; set; }
}
