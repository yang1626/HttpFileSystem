using HttpEnties;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HttpFileServer
{
    public class FileMetaHandler : IFileHandler
    {
        private readonly PhysicalPathResolver _physicalPathResolver;

        public FileMetaHandler(PhysicalPathResolver physicalPathResolver)
        {
            _physicalPathResolver = physicalPathResolver;
        }

        public async Task HandleRequest(HttpContext context, IFileProvider fileProvider)
        {
            var fileInfo = fileProvider.GetFileInfo(context.Request.Path);
            var fileDescriptor = new HttpFileDescriptor(fileInfo, _physicalPathResolver.CreateResolver(context,false));
            await context.Response.WriteAsync(JsonConvert.SerializeObject(fileDescriptor)).ConfigureAwait(false);
        }
    }
}
