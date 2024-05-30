using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;

public class OfferDiscountService : IOfferDiscountService
{
    private readonly HttpClient _httpClient;

    public OfferDiscountService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
    {
        var responseMessage = await _httpClient.GetAsync("OfferDiscounts");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(jsonData);
        return values;
    }

    public async Task<GetByIdOfferDiscountDto> GetByIdOfferDiscountAsync(string id)
    {
        var responseMessage = await _httpClient.GetAsync($"OfferDiscounts/{id}");
        var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdOfferDiscountDto>();
        return value;
    }

    public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
    {
        await _httpClient.PostAsJsonAsync<CreateOfferDiscountDto>("OfferDiscounts", createOfferDiscountDto);
    }

    public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateOfferDiscountDto>("OfferDiscounts", updateOfferDiscountDto);
    }

    public async Task DeleteOfferDiscountAsync(string id)
    {
        await _httpClient.DeleteAsync($"OfferDiscounts/{id}");
    }
}
