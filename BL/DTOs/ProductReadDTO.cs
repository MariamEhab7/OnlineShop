using DAL;
using Microsoft.AspNetCore.Http;

namespace BL;

public class ProductReadDTO
{
    public string? ProductName { get; set; }
    public string ProductImage { get; set; }


    public Category? Category { get; set; }
    public Genre? Genre { get; set; }
}
