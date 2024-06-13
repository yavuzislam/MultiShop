using MultiShop.DtoLayer.BasketDtos;

namespace MultiShop.WebUI.Services.BasketServices;

public class BasketService : IBasketService
{
    private readonly HttpClient _httpClient;

    public BasketService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task AddBasketItem(BasketItemDto basketItemDto)
    {
        var values = await GetBasket();
        if (values != null)
        {
            if (!values.BasketItems.Any(x => x.ProductID == basketItemDto.ProductID))
            {
                values.BasketItems.Add(basketItemDto);
            }
            else
            {
                //values = new BasketTotalDto();
                //values.BasketItems.Add(basketItemDto);
                basketItemDto.Quantity++;
            }
        }
        await SaveBasket(values);
    }

    public async Task DeleteBasket(string userID)
    {
        await _httpClient.DeleteAsync($"Baskets/{userID}");
    }

    public async Task<BasketTotalDto> GetBasket()
    {
        var responseMessage = await _httpClient.GetAsync("Baskets");
        var values = await responseMessage.Content.ReadFromJsonAsync<BasketTotalDto>();
        return values;
    }

    public async Task<bool> RemoveBasketItem(string productID)
    {
        var values = await GetBasket();
        var deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductID == productID);
        if (deletedItem.Quantity > 1)
        {
            deletedItem.Quantity--;
            await SaveBasket(values);
            return true;
        }
        var result = values.BasketItems.Remove(deletedItem);
        await SaveBasket(values);
        return result;
    }

    public async Task SaveBasket(BasketTotalDto basketTotalDto)
    {
        await _httpClient.PostAsJsonAsync<BasketTotalDto>("Baskets", basketTotalDto);
    }
}
