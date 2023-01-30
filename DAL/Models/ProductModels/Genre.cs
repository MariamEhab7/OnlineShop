using System.ComponentModel.DataAnnotations;

namespace DAL;

public class Genre
{
    public Guid GenreId { get; set; }
   
    public string GenreName { get; set; } = "";
}
