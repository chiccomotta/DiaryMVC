using Diary.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiaryApp.Controllers;

public class DiaryEntriesController : Controller
{
    private readonly DiaryDbContext _dbContext;
    
    public DiaryEntriesController(DiaryDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IActionResult> Index()
    {
        var entries = await _dbContext.DiaryEntries.ToListAsync();
        return View(entries);
    }
}