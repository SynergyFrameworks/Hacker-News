using HackerService.DAL.Models;
using HackerService.DAL.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HackerService.DAL
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

      //      modelBuilder.ApplyConfiguration(new WhatEverDATAConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

     //   public DbSet<WhatEverDATA> whatEverDATA { get; set; }
 
    }
}
