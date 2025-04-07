using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Common.Interfaces
{
    public interface IRepository<T> where T : class 
    {
        T Get(Expression<Func<T, bool>>? filter = null, string? inlcudeProperties = null);
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? inlcudeProperties = null);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void Save();
    }
}
