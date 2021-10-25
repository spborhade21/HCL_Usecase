using Microsoft.EntityFrameworkCore;
using PharmaRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaRestAPI.DataAccess
{
    public class PharmaDBContext : DbContext
    {
        public PharmaDBContext(DbContextOptions<PharmaDBContext> options) : base(options)
        {

        }

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ContractUserAllocation> ContractUserAllocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>().ToTable("Contract");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<ContractUserAllocation>().ToTable("ContractUserAllocation");
        }
    }
}
