using System.Reflection;
using Depender.Rules;

namespace Depender
{
    class FindOverridableMethodsRule:IRule
    {
        public void Check(MethodInfo info, Dependency parent)
        {
            if (!info.IsFinal && (info.IsVirtual || info.IsAbstract))
            {
                parent.Add(new Dependency(string.Format(" {0}() can be overriden", info.Name)));
            }
        }

        public bool CanCheck(object obj)
        {
            return obj is MethodInfo;
        }

        public void Check(object obj, Dependency parent)
        {
            Check(obj as MethodInfo, parent);
        }
    }
}
