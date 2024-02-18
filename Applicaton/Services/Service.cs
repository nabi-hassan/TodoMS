using Applicaton.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicaton.Services
{
    public class Service<TModel, TDto, TVm> : IService<TModel, TDto, TVm> where TModel : class
    {
        public Task<TDto> Create(TDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<TDto> Uodate(TDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TDto>> CreateRange(List<TDto> dto)
        {
            throw new NotImplementedException();
        }

        public Task<List<TDto>> UodateRange(List<TDto> dto)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteRange(List<TDto> id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TVm>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<TDto> Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
