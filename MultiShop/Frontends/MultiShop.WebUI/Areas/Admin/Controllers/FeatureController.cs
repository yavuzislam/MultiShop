using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/Feature")]
public class FeatureController : Controller
{
    private readonly IFeatureService _FeatureService;

    public FeatureController(IFeatureService FeatureService)
    {
        _FeatureService = FeatureService;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        FeatureViewbagList();
        var values = await _FeatureService.GetAllFeatureAsync();
        return View(values);
    }

    [HttpGet]
    [Route("CreateFeature")]
    public IActionResult CreateFeature()
    {
        FeatureViewbagList();
        return View();
    }

    [HttpPost]
    [Route("CreateFeature")]
    public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
    {
        await _FeatureService.CreateFeatureAsync(createFeatureDto);
        return RedirectToAction("Index", "Feature", new { area = "Admin" });
    }

    [Route("UpdateFeature/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateFeature(string id)
    {
        FeatureViewbagList();
        var value = await _FeatureService.GetByIdFeatureAsync(id);
        return View(value);
    }

    [Route("UpdateFeature/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
    {
        await _FeatureService.UpdateFeatureAsync(updateFeatureDto);
        return RedirectToAction("Index", "Feature", new { area = "Admin" });
    }

    [Route("DeleteFeature/{id}")]
    public async Task<IActionResult> DeleteFeature(string id)
    {
        await _FeatureService.DeleteFeatureAsync(id);
        return RedirectToAction("Index", "Feature", new { area = "Admin" });
    }
    void FeatureViewbagList()
    {
        ViewBag.v1 = "Ana Sayfa";
        ViewBag.v2 = "Öne Çıkan Alanlar";
        ViewBag.v3 = "Öne Çıkan Alan Listesi";
        ViewBag.v0 = "Ana Sayfa Öne Çıkan Alan İşlemleri";
    }
}
