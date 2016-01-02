namespace Blobs.Interfaces
{
    using System.Collections.Generic;
    using Model;

    public interface IBlobDb
    {
        void AddBlob(Blob blob);

        Blob GetBlob(string blobName);

        ICollection<string> GetBlobs();

        void SetBlob(Blob blob);

        void NextTurn();
    }
}
