using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blobs.Interfaces
{
    using Blobs.Model;

    public interface IAttack
    {
        void ApplyEffects(AbstractBlobEntity blob);
    }
}
