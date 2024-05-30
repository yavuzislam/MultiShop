﻿using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;

public class SpecialOfferService : ISpecialOfferService
{
    private readonly HttpClient _httpClient;

    public SpecialOfferService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
    {
        var responseMessage = await _httpClient.GetAsync("specialoffers");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
        return values;
    }

    public async Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
    {
        var responseMessage = await _httpClient.GetAsync($"specialoffers/{id}");
        var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdSpecialOfferDto>();
        return value;
    }

    public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
    {
        await _httpClient.PostAsJsonAsync<CreateSpecialOfferDto>("specialoffers", createSpecialOfferDto);
    }

    public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateSpecialOfferDto>("specialoffers", updateSpecialOfferDto);
    }

    public async Task DeleteSpecialOfferAsync(string id)
    {
        await _httpClient.DeleteAsync($"specialoffers/{id}");
    }


}
