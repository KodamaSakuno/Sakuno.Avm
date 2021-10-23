using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sakuno.Avm.Abc.SourceGenerator
{
    [Generator]
    internal class InstructionVistorGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context) =>
            context.RegisterForSyntaxNotifications(() => new InstructionReceiver());

        public void Execute(GeneratorExecutionContext context)
        {
            if (context.SyntaxContextReceiver is not InstructionReceiver receiver)
                return;

            GenerateVisitorMethods(context, receiver);
            GenerateAcceptMethods(context, receiver);
        }

        private static void GenerateVisitorMethods(GeneratorExecutionContext context, InstructionReceiver receiver)
        {
            var visitorMethods = new List<MemberDeclarationSyntax>();
            var genericVisitorMethods = new List<MemberDeclarationSyntax>();

            foreach (var instruction in receiver.CandidateInstructions)
            {
                var method = SyntaxFactory.MethodDeclaration(SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.VoidKeyword)), "Visit")
                    .AddParameterListParameters(SyntaxFactory.Parameter(SyntaxFactory.Identifier("instruction")).WithType(SyntaxFactory.ParseTypeName(instruction.ClassName)))
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));

                visitorMethods.Add(method);
                genericVisitorMethods.Add(method.WithReturnType(SyntaxFactory.ParseTypeName("TResult")));
            }

            var visitorBase = SyntaxFactory.InterfaceDeclaration("IInstructionVisitor")
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PartialKeyword));
            var visitor = visitorBase.AddMembers(visitorMethods.ToArray());
            var genericVisitor = visitorBase
                .AddTypeParameterListParameters(SyntaxFactory.TypeParameter("TResult").WithVarianceKeyword(SyntaxFactory.Token(SyntaxKind.OutKeyword)))
                .AddMembers(genericVisitorMethods.ToArray());

            var @namespace = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName("Sakuno.Avm.Abc"))
                .AddMembers(visitor, genericVisitor);

            var compilationUnit = SyntaxFactory.CompilationUnit()
                .AddMembers(@namespace)
                .AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("Sakuno.Avm.Abc.Instructions")))
                .NormalizeWhitespace();

            context.AddSource("IInstructionVisitor.g.cs", SyntaxFactory.SyntaxTree(compilationUnit, encoding: Encoding.UTF8).GetText());
        }
        private static void GenerateAcceptMethods(GeneratorExecutionContext context, InstructionReceiver receiver)
        {
            var classes = new List<ClassDeclarationSyntax>();

            foreach (var instruction in receiver.CandidateInstructions)
            {
                var methodBase = SyntaxFactory.MethodDeclaration(SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.VoidKeyword)), "Accept")
                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.OverrideKeyword))
                    .WithExpressionBody(SyntaxFactory.ArrowExpressionClause(
                        SyntaxFactory.InvocationExpression(SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, SyntaxFactory.IdentifierName("visitor"), SyntaxFactory.IdentifierName("Visit")))
                            .AddArgumentListArguments(SyntaxFactory.Argument(SyntaxFactory.ThisExpression()))))
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
                var acceptMethod = methodBase
                    .AddParameterListParameters(SyntaxFactory.Parameter(SyntaxFactory.Identifier("visitor")).WithType(SyntaxFactory.ParseTypeName("IInstructionVisitor")));
                var genericAcceptMethod = methodBase
                    .AddTypeParameterListParameters(SyntaxFactory.TypeParameter("TResult"))
                    .AddParameterListParameters(SyntaxFactory.Parameter(SyntaxFactory.Identifier("visitor")).WithType(SyntaxFactory.ParseTypeName("IInstructionVisitor<TResult>")))
                    .WithReturnType(SyntaxFactory.ParseTypeName("TResult"));

                var @class = SyntaxFactory.ClassDeclaration(instruction.ClassName)
                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PartialKeyword))
                    .AddMembers(acceptMethod, genericAcceptMethod);

                classes.Add(@class);
            }

            var @namespace = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName("Sakuno.Avm.Abc.Instructions"))
                .AddMembers(classes.ToArray());

            var compilationUnit = SyntaxFactory.CompilationUnit()
                .AddMembers(@namespace)
                .NormalizeWhitespace();

            context.AddSource("AbcInstruction.g.cs", SyntaxFactory.SyntaxTree(compilationUnit, encoding: Encoding.UTF8).GetText());
        }
    }
}
