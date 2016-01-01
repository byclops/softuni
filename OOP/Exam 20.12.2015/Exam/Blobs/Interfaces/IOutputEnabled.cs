using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blobs.Interfaces
{
    using Blobs.Events;
    public interface IOutputEnabled
    {
        event OutputMessageEventHandler OutputMessage;
    }
}
