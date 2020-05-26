using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AsynchrounousProgrammingBasics.ImageProcessorExample
{
    // For I/O-bound operations avoid Task.Run()
    // instead use await without Task.Run()
    // https://app.pluralsight.com/guides/using-task-run-async-await
    static class App
    {
        static async Task Main(string[] args)
        {
            var uri = new Uri("https://miro.medium.com/proxy/1*wxC3mcax_8XXR16ppuWYCQ.jpeg");
            var filename = "downloaded_image" + Path.GetExtension(uri.LocalPath);
            var newFilename = "downloaded_image_blurred" + Path.GetExtension(uri.LocalPath);
              

            Console.WriteLine("Started download...");
            var bytes = await DownloadImage(uri.AbsoluteUri);
            
            var path = AppContext.BaseDirectory.ToString() + filename;

            Console.WriteLine("Saving to disk as " + filename);
            await SaveImage(bytes, path);

            Console.WriteLine("Applying blur...");
            var jpeg = await BlurImage(bytes);

            var newPath = AppContext.BaseDirectory.ToString() + newFilename;
            Console.WriteLine("Saving to disk as " + Path.GetFileName(newPath));
            
            await SaveImage(jpeg, newPath);            

            Console.WriteLine("Completed!");
        }
        // Using await without Task.Run() because of I/O-bounded operation
        static Task<byte[]> DownloadImage(string url)
        {
            var client = new HttpClient();
            return client.GetByteArrayAsync(url);
        }

        // Using await without Task.Run() because of I/O-bounded operation
        static async Task SaveImage(byte[] bytes, string imagePath)
        {
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await fileStream.WriteAsync(bytes, 0, bytes.Length);
            }
        }

        // Using Task.Run(), because it's a CPU-bounded operation
        static async Task<byte[]> BlurImage(byte[] bytes)
        {
            return await Task.Run(() =>
            {
                var image = Image.Load(bytes);
                image.Mutate(ops => ops.GaussianBlur());
                using (var memStream = new MemoryStream())
                {
                    image.SaveAsJpeg(memStream);
                    return memStream.ToArray();
                }
            });
        }
        
    }
}
