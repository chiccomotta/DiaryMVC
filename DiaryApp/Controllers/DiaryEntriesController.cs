using System.Diagnostics;
using Diary.Domain.Models;
using DiaryApp.Models;
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

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(DiaryEntry request)
    {
        Debug.WriteLine(request);
        return View();
    }
}