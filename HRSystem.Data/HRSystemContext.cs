using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using HRSystem.Model;

namespace HRSystem.Data
{
    public class HRSystemContext : DbContext
    {
        public HRSystemContext(DbContextOptions<HRSystemContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
