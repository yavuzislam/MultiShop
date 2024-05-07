using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoCompaniesController : ControllerBase
{
    private readonly ICargoCompanyService _cargoCompanyService;

    public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
    {
        _cargoCompanyService = cargoCompanyService;
    }

    [HttpGet]
    public IActionResult CargoCompanyList()
    {
        var values = _cargoCompanyService.TGetAll();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public IActionResult GetCargoCompanyById(int id)
    {
        var value = _cargoCompanyService.TGetById(id);
        return Ok(value);
    }

    [HttpPost]
    public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
    {
        _cargoCompanyService.TInsert(new CargoCompany
        {
            CargoCompanyName = createCargoCompanyDto.CargoCompanyName
        });
        return Ok("Cargo Company successfully added.");
    }

    [HttpPut]
    public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
    {
        _cargoCompanyService.TUpdate(new CargoCompany
        {
            CargoCompanyID = updateCargoCompanyDto.CargoCompanyID,
            CargoCompanyName = updateCargoCompanyDto.CargoCompanyName
        });
        return Ok("Cargo Company successfully updated.");
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveCargoCompany(int id)
    {
        _cargoCompanyService.TDelete(id);
        return Ok("Cargo Company successfully deleted.");
    }
}
