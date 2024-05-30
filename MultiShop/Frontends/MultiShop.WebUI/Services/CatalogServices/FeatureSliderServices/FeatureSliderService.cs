using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;

public class FeatureSliderService : IFeatureSliderService
{
    private readonly HttpClient _httpClient;

    public FeatureSliderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
    {
        var responseMessage = await _httpClient.GetAsync("featureSliders");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
        return values;
    }

    public async Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
    {
        var responseMessage = await _httpClient.GetAsync($"featureSliders/{id}");
        var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdFeatureSliderDto>();
        return value;
    }

    public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
    {
        await _httpClient.PostAsJsonAsync<CreateFeatureSliderDto>("featureSliders", createFeatureSliderDto);
    }

    public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateFeatureSliderDto>("featureSliders", updateFeatureSliderDto);
    }

    public async Task DeleteFeatureSliderAsync(string id)
    {
        await _httpClient.DeleteAsync($"featureSliders/{id}");
    }
}
