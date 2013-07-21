using System.Reflection;
using ClrTest.Reflection;

namespace Depender.Rules
{
    public class FindStaticMethodCallRule : MethodParserRule
    {
        protected override void DoChecks(MethodBase mehodBeingChecked, MethodBodyInfo methodBody, Dependency parent)
        {
            foreach (ILInstruction instruction in methodBody.Instructions)
            {
                if (instruction is InlineMethodInstruction)
                {
                    InlineMethodInstruction line = instruction as InlineMethodInstruction;
                    if (line.Method.IsStatic)
                    {
                        string message =
                            string.Format("Static method call {0} on {1}", line.Method.Name,
                                          line.Method.ReflectedType.Name);

                        parent.Add(new ProblemDependency(message));
                    }
                }
            }
        }

    }
}