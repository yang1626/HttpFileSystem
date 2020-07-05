using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HttpFileServer
{
    public class FileHandlerFactory: IFileHandlerFactory
    {
        private readonly PhysicalPathResolver _physicalPathResolver;
        public FileHandlerFactory(PhysicalPathResolver physicalPathResolver)
        {
            _physicalPathResolver = physicalPathResolver;
        }

        public IFileHandler Create(HttpContext context)
        {
            if (context.Request.Query.ContainsKey("dir-meta"))
            {
                return new DirMetaHandler(_physicalPathResolver);
            } else if (context.Request.Query.ContainsKey("file-meta"))
            {
                return new FileMetaHandler(_physicalPathResolver);
            }else
            {
                return new DefaultFileHandler();
            }
        }
    }
}
