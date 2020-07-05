using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Net.Http;

namespace HttpFileClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //HttpClient httpClient;

            var services = new ServiceCollection();

            services.AddHttpClient("RemoteFileClient", client =>
             {
                 client.BaseAddress = new Uri("http://localhost:5000/files/dir1/");
                 client.Timeout = new TimeSpan(0, 0, 30);
             });

            var serviceProvider=services
                .AddSingleton<IFileProvider,HttpFileProvider>()
                .AddSingleton<IFileManager,FileManager>()
                .BuildServiceProvider();

            var fileManager = serviceProvider.GetRequiredService<IFileManager>();

            fileManager.ShowStructure((layer, name) => Console.WriteLine($"{new string('\t',layer)}{name}"));

            //using (var scope = services
            //    .BuildServiceProvider()
            //    .CreateScope())
            //{
            //    httpClient = scope.ServiceProvider.GetRequiredService<IHttpClientFactory>().CreateClient("RemoteFileClient");
            //    Console.WriteLine($"InnerScope:{httpClient.BaseAddress}");
            //}

            //Console.WriteLine($"OuterScope:{httpClient?.BaseAddress}");
            Console.ReadLine();
        }
    }
}
