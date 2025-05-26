using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {


        }
        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    Id = 1,
                    Name = "Ocean View Villa",
                    Description = "A luxurious villa with a stunning ocean view and private beach access.",
                    ImageUrl = "https://example.com/images/ocean-view-villa.jpg",
                    Occupancy = 6,
                    Price = 250.00,
                    Sqft = 3500
                },
                new Villa
                {
                    Id = 2,
                    Name = "Mountain Retreat",
                    Description = "A peaceful retreat nestled in the mountains, perfect for relaxation.",
                    ImageUrl = "https://example.com/images/mountain-retreat.jpg",
                    Occupancy = 4,
                    Price = 180.00,
                    Sqft = 2800
                },
                new Villa
                {
                    Id = 3,
                    Name = "Tropical Paradise",
                    Description = "A beautiful villa surrounded by lush tropical gardens.",
                    ImageUrl = "https://example.com/images/tropical-paradise.jpg",
                    Occupancy = 8,
                    Price = 320.00,
                    Sqft = 4200
                },
                new Villa
                {
                    Id = 4,
                    Name = "Lakeview Mansion",
                    Description = "An elegant mansion with breathtaking lake views and modern amenities.",
                    ImageUrl = "https://example.com/images/lakeview-mansion.jpg",
                    Occupancy = 10,
                    Price = 500.00,
                    Sqft = 5500
                },
                new Villa
                {
                    Id = 5,
                    Name = "Desert Oasis",
                    Description = "A unique villa in the heart of the desert, featuring a private pool and spa.",
                    ImageUrl = "https://example.com/images/desert-oasis.jpg",
                    Occupancy = 5,
                    Price = 220.00,
                    Sqft = 3000
                },
                new Villa
                {
                    Id = 6,
                    Name = "Forest Hideaway",
                    Description = "A secluded villa in the woods, offering tranquility and nature views.",
                    ImageUrl = "https://example.com/images/forest-hideaway.jpg",
                    Occupancy = 6,
                    Price = 260.00,
                    Sqft = 3300
                },
                new Villa
                {
                    Id = 7,
                    Name = "Seaside Escape",
                    Description = "A modern villa with direct beach access and a private infinity pool.",
                    ImageUrl = "https://example.com/images/seaside-escape.jpg",
                    Occupancy = 7,
                    Price = 400.00,
                    Sqft = 5000,
                }
);

            modelBuilder.Entity<VillaNumber>().HasData(
                new VillaNumber
                {
                    Villa_Number = 101,
                    VillaId = 1,

                },
                new VillaNumber
                {
                    Villa_Number = 102,
                    VillaId = 2,

                },
                    new VillaNumber
                    {
                        Villa_Number = 103,
                        VillaId = 3,

                    },
                    new VillaNumber
                    {
                        Villa_Number = 201,
                        VillaId = 1,

                    },
                    new VillaNumber
                    {
                        Villa_Number = 202,
                        VillaId = 2,

                    },
                    new VillaNumber
                    {
                        Villa_Number = 203,
                        VillaId = 3,

                    },
                     new VillaNumber
                     {
                         Villa_Number = 301,
                         VillaId = 2,

                     },
                    new VillaNumber
                    {
                        Villa_Number = 302,
                        VillaId = 3,

                    }
                );

          
      
modelBuilder.Entity<Amenity>().HasData(
        new Amenity
        {
            Id = 1,
            Name = "Private Pool",
            Description = "Enjoy exclusive access to a private swimming pool.",
            VillaId = 1
        },
    new Amenity
    {
        Id = 2,
        Name = "WiFi",
        Description = "Stay connected with high-speed wireless internet access.",
        VillaId = 2
    },

    new Amenity
    {
        Id = 3,
        Name = "Microwave",
        Description = "Convenient in-villa microwave for quick meals and snacks.",
        VillaId = 3
    },
    new Amenity
    {
        Id = 4,
        Name = "Air Conditioning",
        Description = "Stay comfortable with modern air conditioning in every room.",
        VillaId = 4
    },
    new Amenity
    {
        Id = 5,
        Name = "Hot Tub",
        Description = "Relax in a luxurious private hot tub.",
        VillaId = 5
    },
    new Amenity
    {
        Id = 6,
        Name = "Smart TV",
        Description = "Access streaming services and cable on a large smart TV.",
        VillaId = 6
    },
    new Amenity
    {
        Id = 7,
        Name = "Washer & Dryer",
        Description = "In-unit washer and dryer for your convenience.",
        VillaId = 7
    }
    
);



        }
    }
}
