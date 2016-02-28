// <copyright file="IOutputEnabled.cs" company="Blobs.com">
//     Blobs.com. All rights reserved.
// </copyright>
// <author>Me</author>
namespace Blobs.Interfaces
{
    using Events;

    /// <summary>
    /// An interface, enabling classes to have access to the output
    /// </summary>
    public interface IOutputEnabled
    {
        /// <summary>
        /// The event, used for signaling to the output method
        /// </summary>
        event OutputMessageEventHandler OutputMessage;
    }
}
