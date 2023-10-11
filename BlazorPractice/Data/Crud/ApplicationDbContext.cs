using System;
using BlazorPractice.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorPractice.Data.Crud
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserModel> Birthday { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}

