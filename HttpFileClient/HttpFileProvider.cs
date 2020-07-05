using HttpEnties;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HttpFileClient
{
    public class HttpFileProvider : IFileProvider
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpFileProvider(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("RemoteFileClient");
            _httpClientFactory = httpClientFactory;
        }

        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            string url = $"{subpath}?dir-meta";
            string content = _httpClient.GetStringAsync(url).Result;
            HttpDirectoryContentsDescriptor descriptor = JsonConvert.DeserializeObject<HttpDirectoryContentsDescriptor>(content);
            return new HttpDirectoryContents(descriptor, _httpClientFactory);
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            string url = $"{subpath}?file-meta";
            string content = _httpClient.GetStringAsync(url).Result;
            HttpFileDescriptor descriptor = JsonConvert.DeserializeObject<HttpFileDescriptor>(content);
            return new HttpFileInfo(descriptor,_httpClientFactory);
        }

        public IChangeToken Watch(string filter)
        {
            return NullChangeToken.Singleton;
        }
    }
}
