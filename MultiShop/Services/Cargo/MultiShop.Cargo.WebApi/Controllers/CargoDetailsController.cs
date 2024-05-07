using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoDetailsController : ControllerBase
{
    private readonly ICargoDetailService _cargoDetailService;

    public CargoDetailsController(ICargoDetailService cargoDetailService)
    {
        _cargoDetailService = cargoDetailService;
    }

    [HttpGet]
    public IActionResult CargoDetailList()
    {
        var values = _cargoDetailService.TGetAll();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public IActionResult GetCargoDetailById(int id)
    {
        var value = _cargoDetailService.TGetById(id);
        return Ok(value);
    }

    [HttpPost]
    public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
    {
        _cargoDetailService.TInsert(new CargoDetail
        {
            SenderCustomer = createCargoDetailDto.SenderCustomer,
            ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
            Barcode = createCargoDetailDto.Barcode,
            CargoCompanyID = createCargoDetailDto.CargoCompanyID
        });
        return Ok("Cargo Detail successfully added.");
    }

    [HttpPut]
    public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
    {
        _cargoDetailService.TUpdate(new CargoDetail
        {
            CargoDetailID = updateCargoDetailDto.CargoDetailID,
            SenderCustomer = updateCargoDetailDto.SenderCustomer,
            ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
            Barcode = updateCargoDetailDto.Barcode,
            CargoCompanyID = updateCargoDetailDto.CargoCompanyID
        });
        return Ok("Cargo Detail successfully updated.");
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveCargoDetail(int id)
    {
        _cargoDetailService.TDelete(id);
        return Ok("Cargo Detail successfully deleted.");
    }
}
