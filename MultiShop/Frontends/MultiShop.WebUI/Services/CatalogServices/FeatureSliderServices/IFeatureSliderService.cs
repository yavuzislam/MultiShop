using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;

public interface IFeatureSliderService
{
    Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();
    Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id);
    Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
    Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
    Task DeleteFeatureSliderAsync(string id);
}
