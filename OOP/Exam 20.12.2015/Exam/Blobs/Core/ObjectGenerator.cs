namespace Blobs.Core
{
    using System;

    public class ObjectGenerator
    {
        public object Create( string objectType, string nameSpace="")
        {
            Type type = Type.GetType(nameSpace + "." + objectType);
            if (type == null)
            {
                throw new Exception($"Type {nameSpace}.{objectType} not found!");
            }
            //var obj = Convert.ChangeType(Activator.CreateInstance(type), type);
            return Convert.ChangeType(Activator.CreateInstance(type), type);
        }
    }
}
