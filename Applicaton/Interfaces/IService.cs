﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicaton.Interfaces
{
    public interface IService<TModel,TDto, TVm> where TModel : class
    {
        Task<List<TVm>> Get();
        Task<TDto> Get(int id);
        Task<TDto> Create(TDto dto);
        Task<TDto> Update(TDto dto);
        Task<int> Delete(int id);
        Task<List<TDto>> CreateRange(List<TDto> dtos);
        Task<List<TDto>> UpdateRange(List<TDto> dtos);
        Task<int> DeleteRange(List<TDto> dtos);
    }
}
