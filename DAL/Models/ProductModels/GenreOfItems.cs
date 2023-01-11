using System.ComponentModel.DataAnnotations;

namespace DAL;

public class GenreOfItems
{
    [Key]
    public Guid GenreId { get; set; }
    [Required]
    public string GenreName { get; set; }
}
