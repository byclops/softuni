namespace Blobs.Core
{
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;
    using Model;


    public class BaseDb: IBlobDb
    {
        private Dictionary<string, Blob> blobs = new Dictionary<string, Blob>();

        public void AddBlob(Blob blob)
        {
            this.blobs[blob.Name] = blob;
        }

        public Blob GetBlob(string blobName)
        {
            return this.blobs[blobName];
        }

        public void SetBlob(Blob blob)
        {
            this.blobs[blob.Name] = blob;
        }

        public ICollection<string> GetBlobs()
        {
            return this.blobs.Keys;
        }

        public void NextTurn()
        {
            foreach (var blob in this.blobs.Values)
            {
                blob.NextTurn();
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (var blob in blobs.Values)
                result.AppendLine(blob.ToString());
            return result.ToString();
        }

    }
}
