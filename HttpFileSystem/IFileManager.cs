using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HttpFileClient
{
    public interface IFileManager
    {
        void ShowStructure(Action<int,string> render);
        Task<string> ReadAllTextAsync(string path);
    }
}
