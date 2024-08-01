﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;


namespace MultiShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/Product")]
public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ProductController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        ProductViewbagList();
        var values = await _productService.GetAllProductsAsync();
        return View(values);
    }
    [Route("ProductListWithCategory")]
    public async Task<IActionResult> ProductListWithCategory()
    {
        ProductViewbagList();
        //var values = await _productService.GetProductsWithCategoryAsync();
        //return View(values);
        return View();
    }
    [HttpGet]
    [Route("CreateProduct")]
    public async Task<IActionResult> CreateProduct()
    {
        ProductViewbagList();
        var values = await _categoryService.GetAllCategoryAsync();

        List<SelectListItem> categoryValues = (from x in values
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID
                                               }).ToList();
        ViewBag.CategoryValues = categoryValues;
        return View();
    }

    [HttpPost]
    [Route("CreateProduct")]
    public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
    {
        await _productService.CreateProductAsync(createProductDto);
        return RedirectToAction("Index", "Product", new { area = "Admin" });
    }

    [Route("DeleteProduct/{id}")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        await _productService.DeleteProductAsync(id);
        return RedirectToAction("Index", "Product", new { area = "Admin" });
    }

    [Route("UpdateProduct/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateProduct(string id)
    {
        ProductViewbagList();

        var values = await _categoryService.GetAllCategoryAsync();
        List<SelectListItem> categoryValues = (from x in values
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID
                                               }).ToList();
        ViewBag.CategoryValues = categoryValues;

        var productValues = await _productService.GetByIdProductAsync(id);
        return View(productValues);
    }

    [Route("UpdateProduct/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
    {
        await _productService.UpdateProductAsync(updateProductDto);
        return RedirectToAction("Index", "Product", new { area = "Admin" });
    }

    void ProductViewbagList()
    {
        ViewBag.v1 = "Ana Sayfa";
        ViewBag.v2 = "Ürünler";
        ViewBag.v3 = "Ürün Güncelleme Sayfası";
        ViewBag.v0 = "Ürün İşlemleri";
    }
}
