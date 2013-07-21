using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Depender.Rules
{
    class FindFieldsThatCanBeDerivedFromRule:IRule
    {
        public bool CanCheck(object obj)
        {
            return obj is FieldInfo;
        }

        public void Check(object obj, Dependency parent)
        {
            Check(obj as FieldInfo, parent);
        }

        public void Check(FieldInfo info, Dependency parent)
        {
//            Dependency parent = new Dependency(info.);
            bool isInterface = info.FieldType.IsInterface;
            bool isAbstract = info.FieldType.IsAbstract;
            bool isNotSealed = !info.FieldType.IsSealed;

            string message = "";
            if (isInterface)
            {
                message = string.Format("Field {0} is interface {1}", info.Name, info.FieldType.Name);
            }
            else if (isAbstract)
            {
                message = string.Format("Field {0} is an abstract class {1} and can be inherited from", info.Name,info.FieldType.Name);
                
            }
            else if (isNotSealed)
            {
                message =
                    string.Format("Field {0} is non sealed {1} and can be inherited from", info.Name,
                                  info.FieldType.Name);
            }

            parent.Add(new Dependency(message));
//            if (parent.AlreadyContains(info.FieldType))
//            {
//                parent.Add(new Dependency(message));
//            }
//            else
//            {
//                parent.Add(new Dependency(info.FieldType, message));
//            }
        }

    }
}
