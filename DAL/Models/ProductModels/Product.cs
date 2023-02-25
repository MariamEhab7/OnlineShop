using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL;

public class Product
{
    [Key]
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = "";

    public string ProductImage { get; set; } = "";

    [ForeignKey("CategoryId")]
    public Category? Category { get; set; }

    [ForeignKey("GenreId")]
    public Genre? Genre{ get; set; }
}
