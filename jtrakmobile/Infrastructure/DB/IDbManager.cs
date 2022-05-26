using jtrakmobile.Models;
using System.Collections.Generic;

namespace jtrakmobile.Infrastructure.DB
{
    public interface IDbManager<T>
    {
        bool Insert(T book);
        List<T> GetAll();
    }
}