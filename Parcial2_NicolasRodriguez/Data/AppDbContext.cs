using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parcial2_NicolasRodriguez.Models;

namespace Parcial2_NicolasRodriguez.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Parcial2_NicolasRodriguez.Models.Friend> Friend { get; set; }
    }
}
