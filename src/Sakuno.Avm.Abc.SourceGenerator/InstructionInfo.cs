using System.Collections.Generic;

namespace Sakuno.Avm.Abc.SourceGenerator
{
    internal class InstructionInfo
    {
        public string Name { get; }
        public string ClassName { get; }
        public IReadOnlyList<ParameterKind> Parameters { get; }

        public InstructionInfo(string name, string className, IReadOnlyList<ParameterKind> parameters)
        {
            Name = name;
            ClassName = className;
            Parameters = parameters;
        }
    }
}
