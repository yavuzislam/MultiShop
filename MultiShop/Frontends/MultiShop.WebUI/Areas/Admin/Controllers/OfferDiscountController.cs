using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/OfferDiscount")]
public class OfferDiscountController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IOfferDiscountService _OfferDiscountService;

    public OfferDiscountController(IHttpClientFactory httpClientFactory, IOfferDiscountService OfferDiscountService)
    {
        _httpClientFactory = httpClientFactory;
        _OfferDiscountService = OfferDiscountService;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        OfferDiscountViewbagList();
        var values = await _OfferDiscountService.GetAllOfferDiscountAsync();
        return View(values);
    }

    [HttpGet]
    [Route("CreateOfferDiscount")]
    public IActionResult CreateOfferDiscount()
    {
        OfferDiscountViewbagList();
        return View();
    }

    [HttpPost]
    [Route("CreateOfferDiscount")]
    public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
    {
        await _OfferDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
        return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
    }

    [Route("UpdateOfferDiscount/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateOfferDiscount(string id)
    {
        OfferDiscountViewbagList();
        var value = await _OfferDiscountService.GetByIdOfferDiscountAsync(id);
        return View(value);
    }

    [Route("UpdateOfferDiscount/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
    {
        await _OfferDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
        return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
    }

    [Route("DeleteOfferDiscount/{id}")]
    public async Task<IActionResult> DeleteOfferDiscount(string id)
    {
        await _OfferDiscountService.DeleteOfferDiscountAsync(id);
        return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
    }
    void OfferDiscountViewbagList()
    {
        ViewBag.v1 = "Ana Sayfa";
        ViewBag.v2 = "İndirim Teklifleri";
        ViewBag.v3 = "İndirim Teklif Listesi";
        ViewBag.v0 = "İndirim Teklif İşlemleri";
    }
}
