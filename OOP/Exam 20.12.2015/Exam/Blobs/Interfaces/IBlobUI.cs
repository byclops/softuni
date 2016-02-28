// <copyright file="IBlobUI.cs" company="Blobs.com">
//     Blobs.com. All rights reserved.
// </copyright>
// <author>Me</author>
namespace Blobs.Interfaces
{
    /// <summary>
    /// Defines an interface for Input/Output for the game
    /// </summary>
    public interface IBlobUi
    {
        /// <summary>
        /// Writes a line to the output
        /// </summary>
        /// <param name="line">The string to be written</param>
        void WriteLine(string line);

        /// <summary>
        /// Writes a string to the output
        /// </summary>
        /// <param name="line">The string to be written</param>
        void Write(string line);

        /// <summary>
        /// Reads a line from the input
        /// </summary>
        /// <returns>Returns the read string</returns>
        string ReadLine();
    }
}
