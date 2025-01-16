using Diary.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DiaryApp.Controllers;

public class DiaryEntriesController(DiaryDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index()
    {
        var entries = await dbContext.DiaryEntries.ToListAsync();
        return View(entries);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Edit(int? id)
    {
        var entry = dbContext.DiaryEntries.Find(id);
        
        if (entry is null)
        {
            return NotFound();
        }
        
        return View(entry);
    }


    [HttpPost]
    public async Task<IActionResult> Edit(int? id, DiaryEntry request)
    {
        var entity = await dbContext.DiaryEntries.FindAsync(id);

        if (entity is null)
        {
            return NotFound();
        }

        // update entity
        
        entity.Title = request.Title;
        entity.Content = request.Content;
        entity.CreateDate = request.CreateDate;

        dbContext.DiaryEntries.Update(entity);
        await dbContext.SaveChangesAsync();
        
        return View(entity);
    }

    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        DiaryEntry? diaryEntry = dbContext.DiaryEntries.Find(id);

        if (diaryEntry == null)
        {
            return NotFound();
        }

        return View(diaryEntry);
    }

    [HttpPost]
    public IActionResult Delete(DiaryEntry obj)
    {

        dbContext.DiaryEntries.Remove(obj);     // Remove the diary entry from the database
        dbContext.SaveChanges();                // Saves the changes to the database
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Create(DiaryEntry request)
    {
        Debug.WriteLine(request);
        dbContext.DiaryEntries.Add(request);

        await dbContext.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}