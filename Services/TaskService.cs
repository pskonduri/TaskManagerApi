using AutoMapper;
using TaskManagerApi.Data;
using TaskManagerApi.DTOs;
using TaskManagerApi.Models;
using TaskManagerApi.Repositories;

namespace TaskManagerApi.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _repo;
    private readonly IMapper _mapper;

    public TaskService(ITaskRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public List<TaskReadDto> GetAll()
    {
        var tasks = _repo.GetAll();
        return _mapper.Map<List<TaskReadDto>>(tasks);
    }

    public TaskReadDto? GetById(int id)
    {
        var task = _repo.GetById(id);
        return task == null ? null : _mapper.Map<TaskReadDto>(task);
    }

    public TaskReadDto Create(TaskCreateDto dto)
    {
        var task = _mapper.Map<TaskItem>(dto);
        _repo.Add(task);
        _repo.SaveChanges();
        return _mapper.Map<TaskReadDto>(task);
    }

    public bool Update(int id, TaskUpdateDto dto)
    {
        var task = _repo.GetById(id);
        if (task == null)
            return false;

        _mapper.Map(dto, task);
        _repo.Update(task);
        _repo.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var task = _repo.GetById(id);
        if (task == null)
            return false;

        _repo.Delete(task);
        _repo.SaveChanges();
        return true;
    }
}

