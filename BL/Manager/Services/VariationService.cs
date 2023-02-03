using AutoMapper;
using DAL;

namespace BL;

public class VariationService : IVariationService
{
    #region Dependancy Injection
    private readonly IMapper _mapper;
    private readonly IVariationValueRepo _valueRepo;
    private readonly IVariationRepo _variationRepo;

    public VariationService(IMapper mapper, IVariationValueRepo valueRepo, IVariationRepo variationRepo)
    {
        _mapper = mapper;
        _valueRepo = valueRepo;
        _variationRepo = variationRepo;
    }
    #endregion
    
    public async Task<VariationValReadDTO> AddVariationValue(VariationValAddDTO model)
    {
        var DbVal = _mapper.Map<VariationValues>(model);
        DbVal.ValuesId = Guid.NewGuid();

        var variations = DbVal.Variation;
        var assignCategory = _variationRepo.GetById(variations.VariationId);
        DbVal.Variation = assignCategory;

        _valueRepo.Add(DbVal);
        _valueRepo.SaveChanges();
        var readProduct = _mapper.Map<VariationValReadDTO>(DbVal);
        return readProduct;
    }

    public async Task<VariationValReadDTO> UpdateVariationValue(VariationValAddDTO model, Guid id)
    {
        var Old = _valueRepo.GetById(id);
        _mapper.Map(model, Old);
        _valueRepo.Update(Old);
        _valueRepo.SaveChanges();
        var result = _mapper.Map<VariationValReadDTO>(Old);
        return result;
    } 
    
    public void DeleteVariationValue(Guid id)
    {
        _valueRepo.DeleteById(id);
        _valueRepo.SaveChanges();
    }


    public async Task<Variation> AddVariation(VariationAddDTO model)
    {
        var DbVar = _mapper.Map<Variation>(model);
        DbVar.VariationId = Guid.NewGuid();

        _variationRepo.Add(DbVar);
        _variationRepo.SaveChanges();
        return DbVar;
    }

    public async Task<Variation> UpdateVariation(VariationAddDTO model, Guid id)
    {
        var Old = _variationRepo.GetById(id);
        _mapper.Map(model, Old);
        _variationRepo.Update(Old);
        _variationRepo.SaveChanges();
        var result = _mapper.Map<Variation>(Old);
        return result;
    }

    public void DeleteVariation(Guid id)
    {
        _variationRepo.DeleteById(id);
        _variationRepo.SaveChanges();
    }

}
