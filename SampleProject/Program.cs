using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace SampleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("tr");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("tr");
            var culture = CultureInfo.CurrentCulture;
            Console.WriteLine("Hello World!");
        }
    }

    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class MultiLanguage : Attribute
    {
        
    }

    public class MultiLocalizable
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        
        [ForeignKey(nameof(LanguageCode))]
        public Language Language { get; set; }
        public string LanguageCode { get; set; }

        public MultiLocalizable()
        {
            
        }

        public MultiLocalizable(string content)
        {
            SetContent(content);
        }
        public void SetContent(string content)
        {
            Content = content;
            Language = new Language(CultureInfo.CurrentCulture.Name);
        }
        
        public static implicit operator string(MultiLocalizable ml) => ml.Content;
        public static explicit operator MultiLocalizable(string value) => new MultiLocalizable(value);

    }

    public class Language
    {
        public Language()   
        {
            
        }

        public Language(string code)
        {
            var culture = CultureInfo.GetCultureInfo(code);
            if (culture == null)
            {
                throw new ArgumentException();
            }

            Code = code;
            Name = culture.NativeName;
        }

        public Language(string code, string name)
        {
            Code = code;
            Name = name;
        }
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class SampleDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

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
            foreach (var mutableEntityType in modelBuilder.Model.GetEntityTypes())
            {
                var entityTypeBuilder = modelBuilder.Entity(mutableEntityType.ClrType);
                foreach (var property in mutableEntityType.ClrType.GetProperties())
                {
                    var attribute = property.GetCustomAttribute<MultiLanguage>();
                    if (attribute != null)
                    {
                        
                    }
                    
                }
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}