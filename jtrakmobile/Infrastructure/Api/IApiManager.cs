using System.Collections.Generic;
using System.Threading.Tasks;

namespace jtrakmobile.Infrastructure.Api
{
    public interface IApiManager<T>
    {
        Task<List<T>> GetAsync();
    }
}