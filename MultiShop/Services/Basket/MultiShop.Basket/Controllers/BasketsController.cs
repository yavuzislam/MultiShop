﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;

namespace MultiShop.Basket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketsController : ControllerBase
{
    private readonly IBasketService _basketService;
    private readonly ILoginService _loginService;

    public BasketsController(IBasketService basketService, ILoginService loginService)
    {
        _basketService = basketService;
        _loginService = loginService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBasketDetail()
    {
        var values = await _basketService.GetBasket(_loginService.GetUserID);
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> SaveMyBasket(BasketTotalDto basketTotalDto)
    {
        basketTotalDto.UserID = _loginService.GetUserID;
        await _basketService.SaveBasket(basketTotalDto);
        return Ok("Changes in the basket were successfully saved.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBasket()
    {
        await _basketService.DeleteBasket(_loginService.GetUserID);
        return Ok("Basket deleted successfully.");
    }
}
