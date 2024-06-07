using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices;

public interface IProductImageService
{
    Task<List<ResultProductImageDto>> GetAllProductImagesAsync();
    Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
    Task<GetByIdProductImageDto> GetByProductIdProductImageAsync(string id);
    Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
    Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
    Task DeleteProductImageAsync(string id);
}
