using Microsoft.AspNetCore.Mvc;
using TaskManagerApi.Data;
using TaskManagerApi.Models;

namespace TaskManagerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly AppDbContext _context;

    public TasksController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Tasks.ToList());
    }

    [HttpPost]
    public IActionResult Create(TaskItem task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetAll), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, TaskItem updated)
    {
        var task = _context.Tasks.Find(id);
        if (task == null)
            return NotFound();

        task.Title = updated.Title;
        task.Description = updated.Description;
        task.IsCompleted = updated.IsCompleted;

        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var task = _context.Tasks.Find(id);
        if (task == null)
            return NotFound();

        _context.Tasks.Remove(task);
        _context.SaveChanges();

        return NoContent();
    }
}

