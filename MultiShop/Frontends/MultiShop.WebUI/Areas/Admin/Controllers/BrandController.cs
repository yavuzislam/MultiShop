﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[AllowAnonymous]
[Route("Admin/Brand")]
public class BrandController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BrandController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        BrandViewbagList();

        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7070/api/Brands");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpGet]
    [Route("CreateBrand")]
    public IActionResult CreateBrand()
    {
        BrandViewbagList();
        return View();
    }

    [HttpPost]
    [Route("CreateBrand")]
    public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createBrandDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7070/api/Brands", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }
        return View();
    }

    [Route("UpdateBrand/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateBrand(string id)
    {
        BrandViewbagList();
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7070/api/Brands/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateBrandDto>(jsonData);
            return View(value);
        }
        return View();
    }

    [Route("UpdateBrand/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateBrandDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:7070/api/Brands/", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }
        return View();
    }

    [Route("DeleteBrand/{id}")]
    public async Task<IActionResult> DeleteBrand(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync("https://localhost:7070/api/Brands/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }
        return View();
    }
    void BrandViewbagList()
    {
        ViewBag.v1 = "Ana Sayfa";
        ViewBag.v2 = "Markalar";
        ViewBag.v3 = "Marka Listesi";
        ViewBag.v0 = "Marka İşlemleri";
    }
}
