using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HttpEnties
{
    public class HttpDirectoryContentsDescriptor
    {
        public bool Exists { get; set; }

        public IEnumerable<HttpFileDescriptor> FileDescriptors { get; set; }

        public HttpDirectoryContentsDescriptor()
        {
            FileDescriptors = new HttpFileDescriptor[0];
        }

        public HttpDirectoryContentsDescriptor(IDirectoryContents contents,Func<string,string> physicalPathResolver)
        {
            Exists = contents.Exists;
            FileDescriptors = contents.Select(_=>new HttpFileDescriptor(_,physicalPathResolver));
        }
    }
}
