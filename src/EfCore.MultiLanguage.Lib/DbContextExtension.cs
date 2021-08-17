using System;
using Microsoft.EntityFrameworkCore;

namespace EfCore.MultiLanguage.Lib
{
    public static class DbContextExtension
    {
        public static void ApplyMultiLingualEntities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Translation>(b =>
            {
                b.ToTable("Translations");
                b.HasMany(p => p.TranslationContents)
                    .WithOne(p => p.Translation)
                    .HasForeignKey(p => p.TranslationId);
                b.Navigation(p => p.TranslationContents).AutoInclude();
            });
            modelBuilder.Entity<TranslationContent>(b =>
            {
                b.ToTable("TranslationContents");
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
                                .HasForeignKey($"{property.Name}TranslationId");
                            b.Navigation(property.Name).AutoInclude();
                        });
                    }
                }
            }
        }
    }
}