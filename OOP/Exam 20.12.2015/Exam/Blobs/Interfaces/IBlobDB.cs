using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blobs.Interfaces
{
    using Blobs.Model;

    public interface IBlobDB
    {
        void AddBlob(Blob blob);
        Blob GetBlob(string blobName);
        ICollection<string> GetBlobs();
        void SetBlob(Blob blob);
        void NextTurn();
    }
}
