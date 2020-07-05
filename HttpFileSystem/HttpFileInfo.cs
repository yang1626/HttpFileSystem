using HttpEnties;
using Microsoft.Extensions.FileProviders;
using System;
using System.IO;
using System.Net.Http;

namespace HttpFileClient
{
    public class HttpFileInfo : IFileInfo
    {
        public bool Exists { get; }

        public bool IsDirectory { get; }

        public DateTimeOffset LastModified { get; }

        public long Length { get; set; }

        public string Name { get; set; }

        public string PhysicalPath { get; set; }

        private readonly HttpClient _httpClient;


        public HttpFileInfo(HttpFileDescriptor descriptor,IHttpClientFactory httpClientFactory)
        {
            Name = descriptor.Name;
            Length = descriptor.Length;
            LastModified = descriptor.LastModified;
            IsDirectory = descriptor.IsDirectory;
            Exists = descriptor.Exists;
            PhysicalPath = descriptor.PhysicalPath;

            _httpClient = httpClientFactory.CreateClient("RemoteFileClient");
        }

        public Stream CreateReadStream()
        {
            return _httpClient.GetStreamAsync(PhysicalPath).Result;
        }
    }
}
