using System.ComponentModel.DataAnnotations;

namespace DAL;

public class VariationValues
{
    public VariationValues()
    {
        Items = new HashSet<Items>();
    }
    [Key]
    public Guid ValuesId { get; set; }
    [Required]
    public string Values { get; set; }

    public Variation Variation { get; set; }
    public ICollection<Items> Items { get; set; }

}
