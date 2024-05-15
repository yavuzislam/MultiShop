﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Services.FeatureServices;

namespace MultiShop.Catalog.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class FeaturesController : ControllerBase
{
    private readonly IFeatureService _featureService;

    public FeaturesController(IFeatureService featureService)
    {
        _featureService = featureService;
    }

    [HttpGet]
    public async Task<IActionResult> FeatureList()
    {
        var values = await _featureService.GetAllFeatureAsync();
        return Ok(values);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdFeature(string id)
    {
        var values = await _featureService.GetByIdFeatureAsync(id);
        return Ok(values);
    }


    [HttpPost]
    public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
    {
        await _featureService.CreateFeatureAsync(createFeatureDto);
        return Ok("Feature successfully added.");
    }


    [HttpPut]
    public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
    {
        await _featureService.UpdateFeatureAsync(updateFeatureDto);
        return Ok("Feature successfully updated.");
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFeature(string id)
    {
        await _featureService.DeleteFeatureAsync(id);
        return Ok("Feature successfully deleted.");
    }
}
