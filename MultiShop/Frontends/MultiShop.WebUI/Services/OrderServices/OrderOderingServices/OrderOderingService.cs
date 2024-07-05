﻿using MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.OrderServices.OrderOderingServices;

public class OrderOderingService : IOrderOderingService
{
    private readonly HttpClient _httpClient;

    public OrderOderingService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserIdAsync(string id)
    {
        var responseMessage = await _httpClient.GetAsync($"orderings/GetOrderingByUserId?id={id}");
        var values= await responseMessage.Content.ReadFromJsonAsync<List<ResultOrderingByUserIdDto>>();
        return values;
    }
}
