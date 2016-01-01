using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blobs.Interfaces
{
    public interface IBlobUI
    {
        void WriteLine(string line);
        void Write(string line);
        string ReadLine();
    }
}
