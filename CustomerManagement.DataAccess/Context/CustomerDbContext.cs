﻿using CustomerManagement.DataAccess.Models;

using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.DataAccess.Context
{
    public class CustomerDbContext(DbContextOptions<CustomerDbContext> options) : DbContext(options)
    {
        public DbSet<Parametros> Parametros { get; set; }
        public DbSet<Cliente> Cliente { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
