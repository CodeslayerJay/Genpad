using Genpad.Data.DbRules;
using Genpad.Engine.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Genpad.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        { }

        public DbSet<Card> Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DbConfigure.Configure(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
