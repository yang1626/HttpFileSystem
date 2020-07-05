using HttpEnties;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HttpFileServer
{
    public class DirMetaHandler : IFileHandler
    {
        private readonly PhysicalPathResolver _physicalPathResolver;
        public DirMetaHandler(PhysicalPathResolver physicalPathResolver)
        {
            _physicalPathResolver = physicalPathResolver;
        }
        public async Task HandleRequest(HttpContext context, IFileProvider fileProvider)
        {
            var directoryContents = fileProvider.GetDirectoryContents(context.Request.Path);
            HttpDirectoryContentsDescriptor descriptor = new HttpDirectoryContentsDescriptor(directoryContents, _physicalPathResolver.CreateResolver(context,true));
            await context.Response.WriteAsync(JsonConvert.SerializeObject(descriptor)).ConfigureAwait(false);
        }
    }
}
