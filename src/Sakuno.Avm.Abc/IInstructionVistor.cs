using Sakuno.Avm.Abc.Instructions;

namespace Sakuno.Avm.Abc
{
    public partial interface IInstructionVisitor
    {
        void Visit(LookupSwitchInstruction instruction);
    }
    public partial interface IInstructionVisitor<out TResult>
    {
        TResult Visit(LookupSwitchInstruction instruction);
    }
}
