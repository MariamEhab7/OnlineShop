using DAL;

namespace BL;
public class VariationValReadDTO
{
    public VariationValReadDTO()
    {
        Items = new HashSet<ItemReadDTO>();
    }

    public string? Values { get; set; }
    public Variation? Variation { get; set; }
    public ICollection<ItemReadDTO> Items { get; set; }
}