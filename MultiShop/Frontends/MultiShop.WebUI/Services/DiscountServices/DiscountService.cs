﻿using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices;

public class DiscountService : IDiscountService
{
    private readonly HttpClient _httpClient;

    public DiscountService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetDiscountCodeDetailByCodeDto> GetDiscountCodeDetailByCode(string code)
    {
        var responseMessage = await _httpClient.GetAsync($"discounts/GetCodelDetailByCode?code={code}");
        var value = await responseMessage.Content.ReadFromJsonAsync<GetDiscountCodeDetailByCodeDto>();
        return value;
    }
}
