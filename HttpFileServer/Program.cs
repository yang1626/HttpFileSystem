using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;

namespace HttpFileServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Host.CreateDefaultBuilder()
                .ConfigureServices(svc=> 
                {
                    svc.AddSingleton<IFileProvider>(_=>new PhysicalFileProvider(@"c:\test"));
                    svc.AddSingleton<PhysicalPathResolver>();
                    svc.AddScoped<IFileHandlerFactory,FileHandlerFactory>();
                })
                .ConfigureWebHostDefaults(wBuilder=> 
                {
                    wBuilder.Configure(app =>
                    {
                        app.UsePathBase("/files")
                        .UseMiddleware<FileProviderMiddleware>();
                    });
                })
                .Build()
                .Run();
        }

    }
}
