using TaskManagerApi.Models;

namespace TaskManagerApi.Repositories;

public interface ITaskRepository
{
    List<TaskItem> GetAll();
    TaskItem? GetById(int id);
    TaskItem Add(TaskItem task);
    void Update(TaskItem task);
    void Delete(TaskItem task);
    void SaveChanges();
}

