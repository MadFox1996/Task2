using AutoMapper;
using Task2.DataModel;
using Task2.Dto;

namespace Task2.Map
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodolistItem, TodolistItemDto>().ReverseMap();
            CreateMap<CreateTodolistItemDto, TodolistItem>();
            CreateMap<UpdateTodolistItemDto, TodolistItem>().ReverseMap();
        }
    }
}