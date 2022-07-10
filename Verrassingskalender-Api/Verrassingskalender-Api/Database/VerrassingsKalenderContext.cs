using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Verrassingskalender_Api.Models;

namespace Verrassingskalender_Api.Database
{
    public class VerrassingsKalenderContext : DbContext
    {
        public DbSet<Grid> Grid { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Cell> Cell { get; set; }

        public string DbPath { get; }

        public VerrassingsKalenderContext(DbContextOptions<VerrassingsKalenderContext> options)
            : base(options)
        {
        }
    }
}
