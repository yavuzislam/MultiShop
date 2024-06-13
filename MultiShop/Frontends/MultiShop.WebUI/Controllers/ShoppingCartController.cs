using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Controllers;

public class ShoppingCartController : Controller
{
    private readonly IProductService _productService;
    private readonly IBasketService _basketService;

    public ShoppingCartController(IProductService productService, IBasketService basketService)
    {
        _productService = productService;
        _basketService = basketService;
    }

    [HttpGet] 
    public async Task<IActionResult> Index(string code,int discountRate,decimal totalNewPriceWithDiscount)
    {
        ViewBag.code = code;
        ViewBag.discountRate = discountRate;
        ViewBag.totalPriceWithDiscount = totalNewPriceWithDiscount;
        ViewBag.directory1 = "Anasayfa";
        ViewBag.directory2 = "Ürünler";
        ViewBag.directory3 = "Sepetim";
        var values = await _basketService.GetBasket();
        ViewBag.total = values.TotalPrice;
        ViewBag.kdv = values.TotalPrice * 0.1m;
        ViewBag.totalPrice = values.TotalPrice + ViewBag.kdv;
        return View();
    }

    public async Task<IActionResult> AddBasketItem(string id)
    {
        var value = await _productService.GetByIdProductAsync(id);
        var item = new BasketItemDto
        {
            ProductID = value.ProductID,
            ProductName = value.ProductName,
            Price = value.ProductPrice,
            Quantity = 1,
            ProductImageUrl = value.ProductImageUrl
        };
        await _basketService.AddBasketItem(item);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> RemoveBasketItem(string id)
    {
        await _basketService.RemoveBasketItem(id);
        return RedirectToAction("Index");
    }
}
