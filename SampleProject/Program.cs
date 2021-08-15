using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SampleProject
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            var ct = new SampleDbContext();
            var a = await ct.Posts.FirstOrDefaultAsync();

            string test = a.Name;


            var ab  = ct.Posts.EntityType.GetNavigations().ToList();
            
                // a.Name.Add(new LocalizationContent("denemeingilizce", "en"));
            //
            // ct.Posts.Update(a);
            // await ct.SaveChangesAsync();
            //
            // var post = new Post();
            // post.Name = new Localization("Deneme");
            //
            // await ct.Posts.AddAsync(post);
            // await ct.SaveChangesAsync();

            Console.WriteLine("Hello World!");
        }
    }
}