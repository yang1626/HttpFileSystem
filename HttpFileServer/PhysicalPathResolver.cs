using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpFileServer
{
    public class PhysicalPathResolver
    {
        public Func<string, string> CreateResolver(HttpContext context,bool isDirRequest)
        {
            string schema = context.Request.IsHttps ? "https" : "http";
            string host = context.Request.Host.Host;
            int port = context.Request.Host.Port ?? 8080;
            string pathBase = context.Request.PathBase.ToString().Trim('/');
            string path = context.Request.Path.ToString().Trim('/');

            pathBase = string.IsNullOrEmpty(pathBase) ? string.Empty
                : $"/{pathBase}";

            path = string.IsNullOrEmpty(path) ? string.Empty : $"/{path}";

            return isDirRequest ? (Func<string, string>)(
                name => $"{schema}://{host}:{port}{pathBase}{path}/{name}"
                ):name=>$"{schema}://{host}:{port}{pathBase}{path}";
        }
    }
}
