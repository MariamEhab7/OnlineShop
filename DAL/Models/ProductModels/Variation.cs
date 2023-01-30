using System.ComponentModel.DataAnnotations;

namespace DAL;

public class Variation
{
    public Guid VariationId { get; set; }

    [Required]
    public string VariationName { get; set; } = "";
}
