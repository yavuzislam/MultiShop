using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoCustomersController : ControllerBase
{
    private readonly ICargoCustomerService _cargoCustomerService;

    public CargoCustomersController(ICargoCustomerService cargoCustomerService)
    {
        _cargoCustomerService = cargoCustomerService;
    }

    [HttpGet]
    public IActionResult CargoCustomerList()
    {
        var values = _cargoCustomerService.TGetAll();
        return Ok(values);
    }


    [HttpGet("{id}")]
    public IActionResult GetCargoCustomerById(int id)
    {
        var value = _cargoCustomerService.TGetById(id);
        return Ok(value);
    }


    [HttpPost]
    public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
    {
        _cargoCustomerService.TInsert(new CargoCustomer
        {
            Name = createCargoCustomerDto.Name,
            Surname = createCargoCustomerDto.Surname,
            Email = createCargoCustomerDto.Email,
            Phone = createCargoCustomerDto.Phone,
            District = createCargoCustomerDto.District,
            City = createCargoCustomerDto.City,
            Address = createCargoCustomerDto.Address
        });
        return Ok("Cargo Customer successfully added.");
    }


    [HttpPut]
    public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
    {
        _cargoCustomerService.TUpdate(new CargoCustomer
        {
            CargoCustomerID = updateCargoCustomerDto.CargoCustomerID,
            Name = updateCargoCustomerDto.Name,
            Surname = updateCargoCustomerDto.Surname,
            Email = updateCargoCustomerDto.Email,
            Phone = updateCargoCustomerDto.Phone,
            District = updateCargoCustomerDto.District,
            City = updateCargoCustomerDto.City,
            Address = updateCargoCustomerDto.Address
        });
        return Ok("Cargo Customer successfully updated.");
    }


    [HttpDelete("{id}")]
    public IActionResult RemoveCargoCustomer(int id)
    {
        _cargoCustomerService.TDelete(id);
        return Ok("Cargo Customer successfully deleted.");
    }
}
