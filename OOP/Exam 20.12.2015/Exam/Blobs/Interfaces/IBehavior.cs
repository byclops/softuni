using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blobs.Interfaces
{
    using Blobs.Model;

    public interface IBehavior
    {

        bool IsActive { get; set; }
        //int GetHealth { get; }
        //int GetDamage { get; }
        void ApplyEffects(Blob blob);
        //void Update(int damage, int health);
        void NextTurn();
        void Activate();

   
    }
}
