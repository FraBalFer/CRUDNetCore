using CRUDApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDApi.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) 
        { 
        }

        public DbSet<WaterMeter> WaterMeter { get; set; }
        public DbSet<Gateway> Gateway { get; set; }
        public DbSet<ElectricMeter> ElectricMeter { get; set; }
    }
}
