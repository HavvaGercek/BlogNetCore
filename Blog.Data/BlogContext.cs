using Blog.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Data
{
    public class BlogContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            ConfigureModelBuilderForUser(modelBuilder);
        }

        void ConfigureModelBuilderForUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>()
                .Property(user => user.Username)
                .HasMaxLength(60)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(user => user.Email)
                .HasMaxLength(60)
                .IsRequired();
        }
    }
}
