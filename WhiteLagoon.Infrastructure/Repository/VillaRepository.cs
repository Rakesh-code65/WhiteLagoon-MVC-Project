﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Infrastructure.Repository
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
       
           
            private readonly ApplicationDbContext _db;

            public VillaRepository(ApplicationDbContext db) : base(db)
            {
                _db = db;
            }
        //    public void Add(Villa entity)
        //{
        //        _db.Add(entity);
        //}

        //public Villa Get(Expression<Func<Villa, bool>>? filter, string? inlcudeProperties = null)
        //{

        //    IQueryable<Villa> query = _db.Set<Villa>();
        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }
        //    if (!string.IsNullOrEmpty(inlcudeProperties))
        //    {
        //        //Villa, VillaNumber - case sensitive
        //        foreach (var includeProp in inlcudeProperties.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            query = query.Include(includeProp);
        //        }
        //    }
        //    return query.FirstOrDefault();
        //}
        //public IEnumerable<Villa> GetAll(Expression<Func<Villa, bool>>? filter = null, string? inlcudeProperties = null)
        //{
        //    IQueryable<Villa> query = _db.Set<Villa>();
        //    if(filter!=null)
        //    {
        //        query = query.Where(filter);
        //    }
        //    if (!string.IsNullOrEmpty(inlcudeProperties))
        //    {
        //        //Villa, VillaNumber - case sensitive
        //        foreach (var includeProp in inlcudeProperties.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            query = query.Include(includeProp);
        //        }
        //    }
        //    return query.ToList();
        //}

        //public void Remove(Villa entity)
        //{
        //        _db.Remove(entity);
        //}

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Villa entity)
        {
                _db.Villas.Update(entity);
        }
    }

}
