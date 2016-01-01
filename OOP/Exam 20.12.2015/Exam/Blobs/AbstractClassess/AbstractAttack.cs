namespace Blobs.AbstractClasses
{
    using Blobs.Interfaces;
    using Blobs.Model;
    using Blobs.AbstractClasses;

    public abstract class AbstractAttack 
    {
        public abstract void ApplyEffects(AbstractBlobEntity blob);
      
    }
}
