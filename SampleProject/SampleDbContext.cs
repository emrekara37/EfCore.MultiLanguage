using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SampleProject
{
    public class SampleDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Translation> Localizations { get; set; }
        public DbSet<TranslationContent> LocalizationContents { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        

        public SampleDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=MultiLanguageDb;User ID=sa;Password=Yirmibir21*;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Translation>(b =>
            {
                b.ToTable("Localizations");
                b.HasMany(p => p.TranslationContents)
                    .WithOne(p => p.Translation)
                    .HasForeignKey(p => p.TranslationId);
                b.Navigation(p => p.TranslationContents).AutoInclude();
            });
            modelBuilder.Entity<TranslationContent>(b =>
            {
                b.ToTable("LocalizationContents");
            });
            foreach (var mutableEntityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in mutableEntityType.ClrType.GetProperties())
                {
                    Type propType = property.PropertyType;
                    if (propType == typeof(Translation) && mutableEntityType.ClrType != typeof(TranslationContent))
                    {
                        modelBuilder.Entity(mutableEntityType.ClrType, b =>
                        {
                            b.HasOne(property.Name)
                                .WithMany()
                                .HasForeignKey($"{property.Name}Localization");
                            b.Navigation(property.Name).AutoInclude();
                        });
                    }
                }
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}