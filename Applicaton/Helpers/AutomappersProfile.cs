using Applicaton.Dtos;
using Applicaton.ViewModels;
using AutoMapper;
using Domain.Models;

namespace Applicaton.Helpers
{
    public class AutomappersProfile : Profile
    {
        public AutomappersProfile()
        {
            CreateMap<TodoGroupDTO, TodoGroup>();
            CreateMap<TodoGroup, TodoGroupDTO>();
            CreateMap<TodoGroup, TodoGroupVM>();
        }

    }
}
