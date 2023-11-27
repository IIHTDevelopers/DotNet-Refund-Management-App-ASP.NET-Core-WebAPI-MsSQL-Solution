using Microsoft.EntityFrameworkCore;
using RefundManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RefundManagementApp.DataLayer
{
    public class RefundManagementAppDbContext : DbContext
    {
        public RefundManagementAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Refund> Refunds { get; set; }
    }

}