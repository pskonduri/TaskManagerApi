using AutoMapper;
using TaskManagerApi.Models;
using TaskManagerApi.DTOs;

namespace TaskManagerApi.Profiles;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<TaskItem, TaskReadDto>();
        CreateMap<TaskCreateDto, TaskItem>();
        CreateMap<TaskUpdateDto, TaskItem>();
    }
}

