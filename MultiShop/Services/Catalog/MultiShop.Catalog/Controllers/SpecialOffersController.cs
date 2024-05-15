using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Services.SpecialOfferServices;

namespace MultiShop.Catalog.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class SpecialOffersController : ControllerBase
{
    private readonly ISpecialOfferService _specialOfferService;

    public SpecialOffersController(ISpecialOfferService specialOfferService)
    {
        _specialOfferService = specialOfferService;
    }

    [HttpGet]
    public async Task<IActionResult> SpecialOfferList()
    {
        var values = await _specialOfferService.GetAllSpecialOfferAsync();
        return Ok(values);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdSpecialOffer(string id)
    {
        var values = await _specialOfferService.GetByIdSpecialOfferAsync(id);
        return Ok(values);
    }


    [HttpPost]
    public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
    {
        await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
        return Ok("Special Offer successfully added.");
    }


    [HttpPut]
    public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
    {
        await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
        return Ok("Special Offer successfully updated.");
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSpecialOffer(string id)
    {
        await _specialOfferService.DeleteSpecialOfferAsync(id);
        return Ok("Special Offer successfully deleted.");
    }
}
