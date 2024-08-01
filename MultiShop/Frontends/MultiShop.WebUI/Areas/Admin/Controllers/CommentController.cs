using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUI.Services.CommentServices;


namespace MultiShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
//[AllowAnonymous]
[Route("Admin/Comment")]
public class CommentController : Controller
{
    private readonly ICommentService _commentService;

    public CommentController( ICommentService commentService)
    {
        _commentService = commentService;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var values=await _commentService.GetAllCommentAsync();
        return View(values);
        //var client = _httpClientFactory.CreateClient();
        //var responseMessage = await client.GetAsync("https://localhost:7075/api/Comments");
        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //    var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
        //    return View(values);
        //}
        //return View();
    }

    [HttpGet]
    [Route("CreateComment")]
    public IActionResult CreateComment()
    {
        CommentViewbagList();
        return View();
    }


    [HttpPost]
    [Route("CreateComment")]
    public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
    {
        await _commentService.CreateCommentAsync(createCommentDto);
        return RedirectToAction("Index", "Comment", new { area = "Admin" });
        //var client = _httpClientFactory.CreateClient();
        //var jsonData = JsonConvert.SerializeObject(createCommentDto);
        //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //var responseMessage = await client.PostAsync("https://localhost:7075/api/Comments", stringContent);
        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    return RedirectToAction("Index", "Comment", new { area = "Admin" });
        //}
        //return View();
    }

    [Route("UpdateComment/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateComment(string id)
    {
        CommentViewbagList();
        var value = await _commentService.GetByIdCommentAsync(id);
        return View(value);
        //var client = _httpClientFactory.CreateClient();
        //var responseMessage = await client.GetAsync("https://localhost:7075/api/Comments/" + id);
        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //    var value = JsonConvert.DeserializeObject<UpdateCommentDto>(jsonData);
        //    return View(value);
        //}
        //return View();
    }

    [Route("UpdateComment/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
    {
        await _commentService.UpdateCommentAsync(updateCommentDto);
        return RedirectToAction("Index", "Comment", new { area = "Admin" });
        //updateCommentDto.Status = true;
        //var client = _httpClientFactory.CreateClient();
        //var jsonData = JsonConvert.SerializeObject(updateCommentDto);
        //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //var responseMessage = await client.PutAsync("https://localhost:7075/api/Comments", stringContent);
        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    return RedirectToAction("Index", "Comment", new { area = "Admin" });
        //}
        //return View();
    }

    [Route("DeleteComment/{id}")]
    public async Task<IActionResult> DeleteComment(string id)
    {
        await _commentService.DeleteCommentAsync(id);
        return RedirectToAction("Index", "Comment", new { area = "Admin" });
        //var client = _httpClientFactory.CreateClient();
        //var responseMessage = await client.DeleteAsync("https://localhost:7070/api/Comments/" + id);
        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    return RedirectToAction("Index", "Comment", new { area = "Admin" });
        //}
        //return View();
    }
    private void CommentViewbagList()
    {
        ViewBag.v1 = "Ana Sayfa";
        ViewBag.v2 = "Yorumlar";
        ViewBag.v3 = "Yorum Listesi";
        ViewBag.v0 = "Yorum İşlemleri";
    }
}
