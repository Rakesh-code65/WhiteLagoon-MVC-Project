﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Infrastructure.Repository
{
    public class UnitofWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IVillaRepository Villa { get; private set; }
        public IAmenityRepository Amenity { get; private set; }
        public IVillaNumberRepository VillaNumber { get; private set; }
        public UnitofWork(ApplicationDbContext db)
        {
            _db = db;
            Villa = new VillaRepository(_db);
            Amenity = new AmenityRepository(_db);
            VillaNumber = new VillaNumberRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
