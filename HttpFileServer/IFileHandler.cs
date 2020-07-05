using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HttpFileServer
{
    public interface IFileHandler
    {
         Task HandleRequest(HttpContext context,IFileProvider fileProvider); 
    }
}
