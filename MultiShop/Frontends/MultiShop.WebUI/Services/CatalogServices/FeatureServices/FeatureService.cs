using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices;

public class FeatureService : IFeatureService
{
    private readonly HttpClient _httpClient;

    public FeatureService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
    {
        var responseMessage = await _httpClient.GetAsync("Features");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
        return values;
    }

    public async Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id)
    {
        var responseMessage = await _httpClient.GetAsync($"Features/{id}");
        var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdFeatureDto>();
        return value;
    }

    public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
    {
        await _httpClient.PostAsJsonAsync<CreateFeatureDto>("Features", createFeatureDto);
    }

    public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateFeatureDto>("Features", updateFeatureDto);
    }

    public async Task DeleteFeatureAsync(string id)
    {
        await _httpClient.DeleteAsync($"Features/{id}");
    }
}
