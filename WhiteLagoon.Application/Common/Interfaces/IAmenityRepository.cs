using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Application.Common.Interfaces;

namespace WhiteLagoon.Application.Common.Interfaces
{
    public interface IAmenityRepository : IRepository<Amenity>
    {
        //Villa Get(Expression<Func<Villa, bool>>? filter = null, string? inlcudeProperties = null);
        //IEnumerable<Villa> GetAll(Expression<Func<Villa, bool>>? filter = null, string? inlcudeProperties = null);

        // implemeted generic repository.

        void Update(Amenity entity);

        //void Save();
        //void Save();
    }
}
