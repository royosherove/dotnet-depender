using System.Reflection;
using Depender.Rules;
using Depender.Rules;

namespace Depender
{
    class FindPrivateConstructorsOnNonAbstractClassesRule:IRule
    {
        public void Check(ConstructorInfo info, Dependency parent)
        {
            if (info.IsPrivate && !info.ReflectedType.IsAbstract)
            {
                parent.Add(new ProblemDependency(string.Format("This is a private constructor")));
            }
        }

        public bool CanCheck(object obj)
        {
            return obj is ConstructorInfo;
        }

        public void Check(object obj, Dependency parent)
        {
            Check(obj as ConstructorInfo, parent);
        }
    }
}
