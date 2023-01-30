using System.ComponentModel.DataAnnotations;

namespace DAL;

public class Category
{
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; } = "";
}
