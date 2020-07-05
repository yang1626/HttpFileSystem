using HttpEnties;
using Microsoft.Extensions.FileProviders;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace HttpFileClient
{
    public class HttpDirectoryContents : IDirectoryContents
    {
        public bool Exists { get; }

        private readonly IEnumerable<IFileInfo> _fileInfos;

        public HttpDirectoryContents(HttpDirectoryContentsDescriptor httpDirectoryContentsDescriptor,IHttpClientFactory httpClientFactory)
        {
            Exists = httpDirectoryContentsDescriptor.Exists;
            _fileInfos = httpDirectoryContentsDescriptor.FileDescriptors.Select(_=>new HttpFileInfo(_,httpClientFactory));
        }

        public IEnumerator<IFileInfo> GetEnumerator()
        {
            return _fileInfos.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _fileInfos.GetEnumerator();
        }
    }
}
