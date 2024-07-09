﻿using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUI.Services.MessageServices;

public class MessageService : IMessageService
{
    private readonly HttpClient _httpClient;

    public MessageService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ResultInboxMessageDto>> GetInboxMessagesAsync(string id)
    {
        var responseMessage = await _httpClient.GetAsync($"UserMessages/GetInboxMessage?id={id}");
        var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultInboxMessageDto>>();
        return values;
    }

    public async Task<List<ResultSendboxMessageDto>> GetSendboxMessagesAsync(string id)
    {
        var responseMessage = await _httpClient.GetAsync($"UserMessages/GetSendboxMessage?id={id}");
        var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultSendboxMessageDto>>();
        return values;
    }
}
//$"orderings/GetOrderingByUserId?id={id}"
//http://localhost:5000/services/order/orderings
//http://localhost:5000/services/message/UserMessages/GetInboxMessage?id=w
