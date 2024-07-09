﻿using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUI.Services.MessageServices;

public interface IMessageService
{
    Task<List<ResultInboxMessageDto>> GetInboxMessagesAsync(string id);
    Task<List<ResultSendboxMessageDto>> GetSendboxMessagesAsync(string id);
}
