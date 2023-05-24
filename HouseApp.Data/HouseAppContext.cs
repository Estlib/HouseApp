using HouseApp.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseApp.Data
{
    public class HouseAppContext : DbContext
    { 
        public HouseAppContext(DbContextOptions<HouseAppContext> options) : base(options) 
        {
        }

        public DbSet<House> Houses { get; set; }
    }
}
