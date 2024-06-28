using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _context;

    public CategoryController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var categories = _context.Categories.ToList();
        return View(categories);
    }

    //GET
    public IActionResult Create()
    {
        return View();
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category category)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        _context.Categories.Add(category);
        _context.SaveChanges();

        TempData["Success"] = $"Category created successfully";

        return RedirectToAction("Index");
    }

    //GET
    public IActionResult Edit(int? id)
    {
        if (id is null || id <= 0)
        {
            return NotFound();
        }

        var category = _context.Categories.Find(id);

        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category category)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        _context.Categories.Update(category);
        _context.SaveChanges();

        TempData["Success"] = $"Category updated successfully";

        return RedirectToAction("Index");
    }

    //GET
    public IActionResult Delete(int? id)
    {
        if (id is null || id <= 0)
        {
            return NotFound();
        }

        var category = _context.Categories.Find(id);

        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    //POST
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var category = _context.Categories.Find(id);

        if (category is null)
        {
            return NotFound();
        }

        _context.Categories.Remove(category);
        _context.SaveChanges();

        TempData["Success"] = $"Category deleted successfully";

        return RedirectToAction("Index");
    }
}
