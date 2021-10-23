using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sakuno.Avm.Abc.SourceGenerator
{
    [Generator]
    internal class InstructionReaderGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context) =>
            context.RegisterForSyntaxNotifications(() => new InstructionReceiver());

        public void Execute(GeneratorExecutionContext context)
        {
            if (context.SyntaxContextReceiver is not InstructionReceiver receiver)
                return;

            var arms = new List<SwitchExpressionArmSyntax>();

            foreach (var instruction in receiver.CandidateInstructions)
            {
                var patternExpression = SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, SyntaxFactory.IdentifierName("InstructionKind"), SyntaxFactory.IdentifierName(instruction.Name));
                var expression = SyntaxFactory.ObjectCreationExpression(SyntaxFactory.ParseTypeName(instruction.ClassName), SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList(instruction.Parameters.Select(GenerateArgument))), null);

                arms.Add(SyntaxFactory.SwitchExpressionArm(SyntaxFactory.ConstantPattern(patternExpression), expression));

                static ArgumentSyntax GenerateArgument(ParameterKind parameter)
                {
                    var readInvocation = SyntaxFactory.InvocationExpression(
                        SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, SyntaxFactory.IdentifierName("reader"), SyntaxFactory.IdentifierName(parameter switch
                        {
                            ParameterKind.U8 => "ReadU8",
                            ParameterKind.S24 => "ReadS24",
                            _ => "ReadU30",
                        })));

                    return SyntaxFactory.Argument(parameter switch
                    {
                        ParameterKind.Integer or
                        ParameterKind.UnsignedInteger or
                        ParameterKind.Double or
                        ParameterKind.String or
                        ParameterKind.Namespace or
                        ParameterKind.Multiname => GenerateConstantPoolInvocationExpression(parameter, readInvocation),

                        ParameterKind.Method => SyntaxFactory.ElementAccessExpression(SyntaxFactory.IdentifierName("methods"), SyntaxFactory.BracketedArgumentList(SyntaxFactory.SingletonSeparatedList(SyntaxFactory.Argument(readInvocation)))),
                        ParameterKind.Class => SyntaxFactory.ElementAccessExpression(SyntaxFactory.IdentifierName("classes"), SyntaxFactory.BracketedArgumentList(SyntaxFactory.SingletonSeparatedList(SyntaxFactory.Argument(readInvocation)))),

                        _ => readInvocation,
                    });
                }
                static InvocationExpressionSyntax GenerateConstantPoolInvocationExpression(ParameterKind parameter, InvocationExpressionSyntax readInvocation) => SyntaxFactory.InvocationExpression(
                    SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, SyntaxFactory.IdentifierName("constantPool"), SyntaxFactory.IdentifierName(parameter switch
                    {
                        ParameterKind.Integer => "GetInteger",
                        ParameterKind.UnsignedInteger => "GetUnsignedInteger",
                        ParameterKind.Double => "GetDouble",
                        ParameterKind.String => "GetString",
                        ParameterKind.Namespace => "GetNamespace",
                        ParameterKind.Multiname => "GetMultiname",

                        _ => throw new ArgumentOutOfRangeException(nameof(parameter)),
                    })),
                    SyntaxFactory.ArgumentList(SyntaxFactory.SingletonSeparatedList(SyntaxFactory.Argument(readInvocation))));
            }

            arms.Add(SyntaxFactory.SwitchExpressionArm(SyntaxFactory.DiscardPattern(), SyntaxFactory.ThrowExpression(SyntaxFactory.ObjectCreationExpression(
                SyntaxFactory.ParseTypeName("ArgumentOutOfRangeException"),
                SyntaxFactory.ArgumentList(SyntaxFactory.SingletonSeparatedList(SyntaxFactory.Argument(SyntaxFactory.InvocationExpression(
                    SyntaxFactory.IdentifierName("nameof"),
                    SyntaxFactory.ArgumentList(SyntaxFactory.SingletonSeparatedList(SyntaxFactory.Argument(SyntaxFactory.IdentifierName("kind")))))))), null))));

            var switchExpression = SyntaxFactory.SwitchExpression(SyntaxFactory.IdentifierName("kind"), SyntaxFactory.SeparatedList(arms));

            var readMethod = SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName("AbcInstruction"), "ReadInstructionCore")
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PrivateKeyword), SyntaxFactory.Token(SyntaxKind.StaticKeyword), SyntaxFactory.Token(SyntaxKind.PartialKeyword))
                .AddParameterListParameters(
                    SyntaxFactory.Parameter(SyntaxFactory.Identifier("reader")).AddModifiers(SyntaxFactory.Token(SyntaxKind.ThisKeyword), SyntaxFactory.Token(SyntaxKind.RefKeyword)).WithType(SyntaxFactory.ParseTypeName("AbcReader")),
                    SyntaxFactory.Parameter(SyntaxFactory.Identifier("kind")).WithType(SyntaxFactory.ParseTypeName("InstructionKind")),
                    SyntaxFactory.Parameter(SyntaxFactory.Identifier("constantPool")).WithType(SyntaxFactory.ParseTypeName("ConstantPool")),
                    SyntaxFactory.Parameter(SyntaxFactory.Identifier("methods")).WithType(SyntaxFactory.ParseTypeName("AbcMethod[]")),
                    SyntaxFactory.Parameter(SyntaxFactory.Identifier("classes")).WithType(SyntaxFactory.ParseTypeName("AbcClass[]")))
                .WithExpressionBody(SyntaxFactory.ArrowExpressionClause(switchExpression))
                .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));

            var @class = SyntaxFactory.ClassDeclaration("AbcReaderExtensions")
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PartialKeyword))
                .AddMembers(readMethod)
                .WithLeadingTrivia(SyntaxFactory.Trivia(SyntaxFactory.NullableDirectiveTrivia(SyntaxFactory.Token(SyntaxKind.EnableKeyword), true)))
                .WithTrailingTrivia(SyntaxFactory.Trivia(SyntaxFactory.NullableDirectiveTrivia(SyntaxFactory.Token(SyntaxKind.DisableKeyword), true)));
            var @namespace = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName("Sakuno.Avm.Abc"))
                .AddMembers(@class);

            var compilationUnit = SyntaxFactory.CompilationUnit()
                .AddMembers(@namespace)
                .AddUsings(
                    SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System")),
                    SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("Sakuno.Avm.Abc.Instructions")))
                .NormalizeWhitespace();

            context.AddSource("AbcReaderExtensions.Instructions.g.cs", SyntaxFactory.SyntaxTree(compilationUnit, encoding: Encoding.UTF8).GetText());
        }
    }
}
