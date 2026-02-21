using TaskManagerApi.DTOs;

namespace TaskManagerApi.Services;

public interface ITaskService
{
    List<TaskReadDto> GetAll();
    TaskReadDto? GetById(int id);
    TaskReadDto Create(TaskCreateDto dto);
    bool Update(int id, TaskUpdateDto dto);
    bool Delete(int id);
}

