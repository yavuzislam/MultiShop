﻿using MultiShop.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerServices;

public class CargoCustomerService : ICargoCustomerService
{
    private readonly HttpClient _httpClient;

    public CargoCustomerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetCargoCustomerByIdDto> GetCargoCustomerByIdAsync(string id)
    {
        var responseMessage = await _httpClient.GetAsync($"CargoCustomers/GetCargoCustomerById?id={id}");
        var values = await responseMessage.Content.ReadFromJsonAsync<GetCargoCustomerByIdDto>();
        return values;
    }
}
//CargoCustomers/GetCargoCustomerById?id=94770d80-383d-462e-ba14-3766295c1db1