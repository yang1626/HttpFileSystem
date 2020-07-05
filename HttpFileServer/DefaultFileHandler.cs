using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HttpFileServer
{
    public class DefaultFileHandler : IFileHandler
    {
        public async Task HandleRequest(HttpContext context, IFileProvider fileProvider)
        {
            await context.Response.SendFileAsync(fileProvider.GetFileInfo(context.Request.Path)).ConfigureAwait(false);
        }
    }
}
