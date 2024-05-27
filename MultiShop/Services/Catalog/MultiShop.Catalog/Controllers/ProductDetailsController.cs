﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProductDetailsController : ControllerBase
{
    private readonly IProductDetailService _productDetailService;

    public ProductDetailsController(IProductDetailService productDetailService)
    {
        _productDetailService = productDetailService;
    }

    [HttpGet]
    public async Task<IActionResult> ProductDetailList()
    {
        var values = await _productDetailService.GetAllProductDetailsAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdProduct(string id)
    {
        var values = await _productDetailService.GetByIdProductDetailAsync(id);
        return Ok(values);
    }

    [HttpGet("GetProductDetailByProductId")]
    public async Task<IActionResult> GetProductDetailByProductId(string id)
    {
        var values = await _productDetailService.GetByProductIdProductDetailAsync(id);
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
    {
        await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
        return Ok("Product detail successfully added.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
    {
        await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
        return Ok("Product detail successfully updated.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductDetail(string id)
    {
        await _productDetailService.DeleteProductDetailAsync(id);
        return Ok("Product detail successfully deleted.");
    }
}
