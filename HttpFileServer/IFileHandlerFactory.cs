using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpFileServer
{
    public interface IFileHandlerFactory
    {
         IFileHandler Create(HttpContext context);
    }
}
