using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Players_and_coaches8.Models;

namespace Players_and_coaches8.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Players_and_coaches8.Models.Coaches> Coaches { get; set; }
        public DbSet<Players_and_coaches8.Models.Players> Players { get; set; }
        public DbSet<Players_and_coaches8.Models.Transfers> Transfers { get; set; }
    }
}
