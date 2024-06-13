using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.DiscountServices;

namespace MultiShop.WebUI.Controllers;

public class DiscountController : Controller
{
    private readonly IDiscountService _discountService;
    private readonly IBasketService _basketService;

    public DiscountController(IDiscountService discountService, IBasketService basketService)
    {
        _discountService = discountService;
        _basketService = basketService;
    }

    [HttpGet]
    public async Task<PartialViewResult> ConfirmDiscountCoupon()
    {
        var basket = await _basketService.GetBasket();
        return PartialView(basket);
    }
    [HttpPost]
    public async Task<IActionResult> ConfirmDiscountCoupon(string code)
    {
        var value = await _discountService.GetDiscountCodeDetailByCode(code);

        var basketValues = await _basketService.GetBasket();
        var totalPriceWithTax = basketValues.TotalPrice + (basketValues.TotalPrice * 0.1m);
        var totalNewPriceWithDiscount = totalPriceWithTax - (totalPriceWithTax * value.Rate / 100);
        //ViewBag.totalPriceWithDiscount = totalNewPriceWithDiscount;
        return RedirectToAction("Index", "ShoppingCart", new { code = code,discountRate=value.Rate, totalNewPriceWithDiscount=totalNewPriceWithDiscount });
    }
}
