using TaskManagerApi.Data;
using TaskManagerApi.Models;

namespace TaskManagerApi.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<TaskItem> GetAll()
    {
        return _context.Tasks.ToList();
    }

    public TaskItem? GetById(int id)
    {
        return _context.Tasks.Find(id);
    }

    public TaskItem Add(TaskItem task)
    {
        _context.Tasks.Add(task);
        return task;
    }

    public void Update(TaskItem task)
    {
        _context.Tasks.Update(task);
    }

    public void Delete(TaskItem task)
    {
        _context.Tasks.Remove(task);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}

