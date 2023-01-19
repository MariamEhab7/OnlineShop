using DAL;

namespace BL;

public interface IVariationService
{
    Task<VariationValReadDTO> AddVariationValue(VariationValAddDTO model);
    Task<VariationValReadDTO> UpdateVariationValue(VariationValAddDTO model, Guid id);
    void DeleteVariationValue(Guid id);


    Task<Variation> AddVariation(VariationAddDTO model);
    Task<Variation> UpdateVariation(VariationAddDTO model, Guid id);
    void DeleteVariation(Guid id);
}
