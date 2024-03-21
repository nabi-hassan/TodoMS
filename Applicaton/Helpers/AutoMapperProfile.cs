using Applicaton.Dtos;
using Applicaton.ViewModels;
using AutoMapper;
using Domain.Models;

namespace Applicaton.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {   //For Todo Groups
            CreateMap<TodoGroupDTO, TodoGroup>();
            CreateMap<TodoGroup, TodoGroupDTO>();
            CreateMap<TodoGroup, TodoGroupVM>();

            //For Todo Lists
            CreateMap<TodoListDTO, TodoList>();
            CreateMap<TodoList, TodoListDTO>();
            CreateMap<TodoList, TodoListVM>();

            //For Todo Items
            CreateMap<TodoDTO, Todo>();
            CreateMap<Todo, TodoDTO>();
            CreateMap<Todo, TodoVM>();
        }

    }
}
