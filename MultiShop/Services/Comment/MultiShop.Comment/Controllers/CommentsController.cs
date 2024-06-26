﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly CommentContext _context;

    public CommentsController(CommentContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> CommentList()
    {
        var values = await _context.Set<UserComment>().ToListAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdComment(int id)
    {
        var value = await _context.Set<UserComment>().FindAsync(id);
        return Ok(value);
    }

    [HttpGet("CommentListByProductId/{id}")]
    public async Task<IActionResult> CommentListByProductId(string id)
    {
        var value = await _context.Set<UserComment>().Where(x => x.ProductID == id).ToListAsync();
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateComment(UserComment userComment)
    {
        await _context.Set<UserComment>().AddAsync(userComment);
        await _context.SaveChangesAsync();
        return Ok("Comment successfully added.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateComment(UserComment userComment)
    {
        _context.Set<UserComment>().Update(userComment);
        await _context.SaveChangesAsync();
        return Ok("Comment successfully updated.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComment(int id)
    {
        var value = await _context.Set<UserComment>().FindAsync(id);
        _context.Set<UserComment>().Remove(value);
        await _context.SaveChangesAsync();
        return Ok("Comment successfully deleted.");
    }
}
