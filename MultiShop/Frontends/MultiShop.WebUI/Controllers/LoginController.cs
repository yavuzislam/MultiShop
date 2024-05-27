﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MultiShop.WebUI.Controllers;

public class LoginController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILoginService _loginService;

    public LoginController(IHttpClientFactory httpClientFactory, ILoginService loginService)
    {
        _httpClientFactory = httpClientFactory;
        _loginService = loginService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
    {
        var client = _httpClientFactory.CreateClient();
        var stringContent = new StringContent(JsonConvert.SerializeObject(createLoginDto), Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("http://localhost:5001/api/Logins", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            if (tokenModel != null)
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(tokenModel.Token);
                var claims = token.Claims.ToList();

                if (tokenModel.Token != null)
                {
                    claims.Add(new Claim("multishoptoken", tokenModel.Token));
                    var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                    var authProps = new AuthenticationProperties
                    {
                        ExpiresUtc = tokenModel.ExpireDate,
                        IsPersistent = true
                    };

                    await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                    var id = _loginService.GetUserID;
                    return RedirectToAction("Index", "Default");
                }
            }
        }
        return View();
    }
}
