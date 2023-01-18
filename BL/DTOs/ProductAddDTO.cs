using DAL;

namespace BL;

public class ProductAddDTO
{
    public string ProductName { get; set; }

    public Category Category { get; set; }
    public GenreOfItems GenreOfItems { get; set; }
}
