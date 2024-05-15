﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Services.BrandServices;

namespace MultiShop.Catalog.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class BrandsController : ControllerBase
{
    private readonly IBrandService _brandService;

    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpGet]
    public async Task<IActionResult> BrandList()
    {
        var values = await _brandService.GetAllBrandAsync();
        return Ok(values);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdBrand(string id)
    {
        var values = await _brandService.GetByIdBrandAsync(id);
        return Ok(values);
    }


    [HttpPost]
    public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
    {
        await _brandService.CreateBrandAsync(createBrandDto);
        return Ok("Brand successfully added.");
    }


    [HttpPut]
    public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
    {
        await _brandService.UpdateBrandAsync(updateBrandDto);
        return Ok("Brand successfully updated.");
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBrand(string id)
    {
        await _brandService.DeleteBrandAsync(id);
        return Ok("Brand successfully deleted.");
    }
}
