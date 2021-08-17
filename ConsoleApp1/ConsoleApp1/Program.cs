using System;
using System.IO;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var bytes = Convert.FromBase64String(
                    "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");
                await using (var ms = new MemoryStream(bytes))
                {
                    using (Image image = await Image.LoadAsync(ms))
                    {
                        int width = image.Width / 2;
                        int height = image.Height / 2;
                        image.Mutate(x => x.Resize(300, 300));

                        await using (var ms2 = new MemoryStream())
                        {
                            await image.SaveAsPngAsync(ms2);
                            var newImageBytes = ms2.ToArray();
                            var base64 = Convert.ToBase64String(newImageBytes);
                        }
                    }
                }


                Console.WriteLine("1");
            }
            catch (Exception e)
            {
                Console.WriteLine("2");
            }
            finally
            {
                Console.WriteLine("3");
            }

            Console.WriteLine("Hello World!");
        }
    }
}