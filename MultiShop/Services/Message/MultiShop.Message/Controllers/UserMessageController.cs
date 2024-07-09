using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Dtos;
using MultiShop.Message.Services;


namespace MultiShop.Message.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UserMessageController : ControllerBase
{
    private readonly IUserMessageService _userMessageService;

    public UserMessageController(IUserMessageService userMessageService)
    {
        _userMessageService = userMessageService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMessage()
    {
        var values = await _userMessageService.GetAllMessageAsync();
        return Ok(values);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdUserMessage(int id)
    {
        var value = await _userMessageService.GetByIdMessageAsync(id);
        return Ok(value);
    }

    [HttpGet("GetInboxMessage")]
    public async Task<IActionResult> GetInboxMessage(string id)
    {
        var values = await _userMessageService.GetInboxMessageAsync(id);
        return Ok(values);
    }

    [HttpGet("GetSendboxMessage")]
    public async Task<IActionResult> GetSendboxMessage(string id)
    {
        var values = await _userMessageService.GetSendboxMessageAsync(id);
        return Ok(values);
    }


    [HttpPost]
    public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
    {
        await _userMessageService.CreateMessageAsync(createMessageDto);
        return Ok("Message successfully added.");
    }


    [HttpPut]
    public async Task<IActionResult> UpdateMessage(UpdateMessageDto updateMessageDto)
    {
        await _userMessageService.UpdateMessageAsync(updateMessageDto);
        return Ok("Message successfully updated.");
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMessage(int id)
    {
        await _userMessageService.DeleteMessageAsync(id);
        return Ok("Message successfully deleted.");
    }
}
