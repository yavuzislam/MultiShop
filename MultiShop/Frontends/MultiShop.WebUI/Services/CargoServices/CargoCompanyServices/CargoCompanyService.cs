using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCompanyServices;

public class CargoCompanyService : ICargoCompanyService
{
    private readonly HttpClient _httpClient;

    public CargoCompanyService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<List<ResultCargoCompanyDto>> GetAllCargoCompanyAsync()
    {
        var responseMessage = await _httpClient.GetAsync("CargoCompanies");
        var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCargoCompanyDto>>();
        return values;
    }

    public async Task<GetByIdCargoCompanyDto> GetByIdCargoCompanyAsync(int id)
    {
        var responseMessage = await _httpClient.GetAsync($"CargoCompanies/{id}");
        var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCargoCompanyDto>();
        return value;
    }

    public async Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto)
    {
       await _httpClient.PostAsJsonAsync("CargoCompanies", createCargoCompanyDto);
    }
    public async Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto)
    {
        await _httpClient.PutAsJsonAsync("CargoCompanies", updateCargoCompanyDto);
    }

    public async Task DeleteCargoCompanyAsync(int id)
    {
        await _httpClient.DeleteAsync($"CargoCompanies/{id}");
    }

}
//http://localhost:5000/services/cargo/CargoCompanies/1 GetByIdCargoCompanyDto