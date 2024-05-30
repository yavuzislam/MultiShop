using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices;

public class BrandService : IBrandService
{
    private readonly HttpClient _httpClient;

    public BrandService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ResultBrandDto>> GetAllBrandAsync()
    {
        var responseMessage = await _httpClient.GetAsync("brands");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
        return values;
    }

    public async Task<GetByIdBrandDto> GetByIdBrandAsync(string id)
    {
        var responseMessage = await _httpClient.GetAsync($"brands/{id}");
        var value=await responseMessage.Content.ReadFromJsonAsync<GetByIdBrandDto>();
        return value;
    }

    public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
    {
        await _httpClient.PostAsJsonAsync("brands", createBrandDto);
    }

    public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
    {
        await _httpClient.PutAsJsonAsync("brands", updateBrandDto);
    }

    public async Task DeleteBrandAsync(string id)
    {
        await _httpClient.DeleteAsync($"brands/{id}");
    }
}
