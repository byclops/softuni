// <copyright file="IBlobDB.cs" company="Blobs.com">
//     Blobs.com. All rights reserved.
// </copyright>
// <author>Me</author>

namespace Blobs.Interfaces
{
    using System.Collections.Generic;
    using Model;

    /// <summary>
    /// An interface, defining the functionality of a database for the blobs game
    /// </summary>
    public interface IBlobDb
    {
        /// <summary>
        /// Adds a new blob
        /// </summary>
        /// <param name="blob">The blob to be added</param>
        void AddBlob(Blob blob);

        /// <summary>
        /// Returns a certain blob 
        /// </summary>
        /// <param name="blobName">The name of the blob</param>
        /// <returns>A blob with the name blobName</returns>
        Blob GetBlob(string blobName);

        /// <summary>
        /// Returns all blobs
        /// </summary>
        /// <returns>A collection containing all blobs</returns>
        ICollection<string> GetBlobs();

        /// <summary>
        /// Modifies a blob
        /// </summary>
        /// <param name="blob">The blob to be modified</param>
        void SetBlob(Blob blob);

        /// <summary>
        /// Triggers the next turn method on all contained blobs
        /// </summary>
        void NextTurn();
    }
}
