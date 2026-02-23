using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using TaskManagerApi.Data;
using TaskManagerApi.DTOs;
using TaskManagerApi.Models;
using TaskManagerApi.Repositories;

namespace TaskManagerApi.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _repo;
    private readonly IMapper _mapper;
    private readonly IMemoryCache _cache;

    public TaskService(ITaskRepository repo, IMapper mapper, IMemoryCache cache)
    {
        _repo = repo;
        _mapper = mapper;
        _cache = cache;
    }

    public List<TaskReadDto> GetAll()
    {
        const string cacheKey = "tasks_all";

        if (_cache.TryGetValue(cacheKey, out List<TaskReadDto>? cached))
            return cached;

        var tasks = _repo.GetAll();
        var dto = _mapper.Map<List<TaskReadDto>>(tasks);

        _cache.Set(cacheKey, dto, TimeSpan.FromSeconds(30));

        return dto;
    }

    public TaskReadDto? GetById(int id)
    {
        var task = _repo.GetById(id);
        return task == null ? null : _mapper.Map<TaskReadDto>(task);
    }

    public TaskReadDto Create(TaskCreateDto dto)
    {
        _cache.Remove("tasks_all");

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

        _cache.Remove("tasks_all");

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

        _cache.Remove("tasks_all");

        _repo.Delete(task);
        _repo.SaveChanges();
        return true;
    }
}

