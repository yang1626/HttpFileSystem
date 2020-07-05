using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HttpFileServer
{
    public class FileProviderMiddleware
    {
        private readonly RequestDelegate _next;

        public FileProviderMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext httpContext,IFileProvider provider, IFileHandlerFactory fileHandlerFactory)
        {
            var fileHandler = fileHandlerFactory.Create(httpContext);
            await fileHandler?.HandleRequest(httpContext, provider);
        }

    }
}
