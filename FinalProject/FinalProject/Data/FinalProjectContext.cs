using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Models
{
    public class FinalProjectContext : DbContext
    {
        public FinalProjectContext (DbContextOptions<FinalProjectContext> options)
            : base(options)
        {
        }

        public DbSet<FinalProject.Models.Business> Business { get; set; }

        public DbSet<FinalProject.Models.Contractor> Contractor { get; set; }

        public DbSet<FinalProject.Models.Project> Project { get; set; }
    }
}
