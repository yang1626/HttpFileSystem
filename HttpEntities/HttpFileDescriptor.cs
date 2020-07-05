using Microsoft.Extensions.FileProviders;
using System;

namespace HttpEnties
{
    public class HttpFileDescriptor
    {
        public bool Exists { get; set; }

        public bool IsDirectory { get; set; }

        public DateTimeOffset LastModified { get; set; }

        public long Length { get; set; }

        public string Name { get; set; }

        public string PhysicalPath { get;  set; }

        public HttpFileDescriptor()
        {

        }

        public HttpFileDescriptor(IFileInfo fileInfo, Func<string, string> physicalPathResolver)
        {
            Name = fileInfo.Name;
            Length = fileInfo.Length;
            LastModified = fileInfo.LastModified;
            IsDirectory = fileInfo.IsDirectory;
            Exists = fileInfo.Exists;
            PhysicalPath = physicalPathResolver(Name);
        }

    }
}
