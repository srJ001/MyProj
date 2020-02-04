using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Sigma.Data;
using Sigma.Models;

namespace Sigma.Data
{
    public class CarContext : IdentityDbContext
    {
        public CarContext(DbContextOptions<CarContext> options)
              : base(options)
        {
        }


        public DbSet<Car> Car { get; set; }
        public DbSet<TypeCar> TypeCar { get; set; }
        public DbSet<Order> Order { get; set; }
       // public DbSet<User> Users { get; set; }
       
    }
    //public class TypeCarContext : DbContext
    //{
    //    public TypeCarContext(DbContextOptions<TypeCarContext> options)
    //          : base(options)
    //    {
    //    } 
        
    //}
    }
