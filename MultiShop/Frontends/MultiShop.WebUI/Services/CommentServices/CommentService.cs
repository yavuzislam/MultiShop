﻿using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CommentServices;

public class CommentService : ICommentService
{
    private readonly HttpClient _httpClient;

    public CommentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<List<ResultCommentDto>> GetAllCommentAsync()
    {
        var responseMessage = await _httpClient.GetAsync("comments");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
        return values;
    }
    public async Task<GetByIdCommentDto> GetByIdCommentAsync(string id)
    {
        var responseMessage = await _httpClient.GetAsync($"comments/{id}");
        var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCommentDto>();
        return value;
    }
    public async Task<List<ResultCommentDto>> CommentListByProductId(string id)
    {
        var responseMessage = await _httpClient.GetAsync($"comments/CommentListByProductId/{id}");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
        return values;
    }
    public async Task CreateCommentAsync(CreateCommentDto createCommentDto)
    {
        await _httpClient.PostAsJsonAsync<CreateCommentDto>("comments", createCommentDto);
    }
    public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateCommentDto>("comments", updateCommentDto);
    }
    public async Task DeleteCommentAsync(string id)
    {
        await _httpClient.DeleteAsync($"comments/{id}");
    }
}
