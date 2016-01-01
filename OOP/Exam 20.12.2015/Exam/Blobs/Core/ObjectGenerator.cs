using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blobs.Core
{
    public class ObjectGenerator
    {
        public object Create( string objectType, string nameSpace="")
        {

            Type type = Type.GetType(nameSpace + "." + objectType);
            //Console.WriteLine(this.GetType().AssemblyQualifiedName);
            var obj = Convert.ChangeType(Activator.CreateInstance(type), type);
            //Dictionary<string, (obj.GetType())> tmp = new Dictionary<string, (obj.GetType())>();
            return Convert.ChangeType(Activator.CreateInstance(type), type);

        }
    }
}
