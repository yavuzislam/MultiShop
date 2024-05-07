using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoOperationsController : ControllerBase
{
    private readonly ICargoOperationService _cargoOperationService;

    public CargoOperationsController(ICargoOperationService cargoOperationService)
    {
        _cargoOperationService = cargoOperationService;
    }

    [HttpGet]
    public IActionResult CargoOperationList()
    {
        var values = _cargoOperationService.TGetAll();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public IActionResult GetCargoOperationById(int id)
    {
        var value = _cargoOperationService.TGetById(id);
        return Ok(value);
    }

    [HttpPost]
    public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
    {
        _cargoOperationService.TInsert(new CargoOperation
        {
            Barcode = createCargoOperationDto.Barcode,
            Description = createCargoOperationDto.Description,
            OperationDate = createCargoOperationDto.OperationDate
        });
        return Ok("Cargo Operation successfully added.");
    }

    [HttpPut]
    public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
    {
        _cargoOperationService.TUpdate(new CargoOperation
        {
            CargoOperationID = updateCargoOperationDto.CargoOperationID,
            Barcode = updateCargoOperationDto.Barcode,
            Description = updateCargoOperationDto.Description,
            OperationDate = updateCargoOperationDto.OperationDate
        });
        return Ok("Cargo Operation successfully updated.");
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveCargoOperation(int id)
    {
        _cargoOperationService.TDelete(id);
        return Ok("Cargo Operation successfully deleted.");
    }
}
