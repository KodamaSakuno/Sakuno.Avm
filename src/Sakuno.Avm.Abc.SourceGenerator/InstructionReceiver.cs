using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;

namespace Sakuno.Avm.Abc.SourceGenerator
{
    internal class InstructionReceiver : ISyntaxContextReceiver
    {
        private INamedTypeSymbol? _attributeSymbol;
        private INamedTypeSymbol? _parameterAttributeSymbol;
        private INamedTypeSymbol? _methodSymbol;
        private INamedTypeSymbol? _namespaceSymbol;
        private INamedTypeSymbol? _multinameSymbol;
        private INamedTypeSymbol? _classSymbol;

        private readonly List<InstructionInfo> _candidateInstructions = new();
        public IReadOnlyList<InstructionInfo> CandidateInstructions => _candidateInstructions;

        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            _attributeSymbol ??= context.SemanticModel.Compilation.GetTypeByMetadataName("Sakuno.Avm.Abc.Instructions.InstructionAttribute");
            _parameterAttributeSymbol ??= context.SemanticModel.Compilation.GetTypeByMetadataName("Sakuno.Avm.Abc.Instructions.ArgumentAttribute");
            _namespaceSymbol ??= context.SemanticModel.Compilation.GetTypeByMetadataName("Sakuno.Avm.Abc.AbcNamespace");
            _multinameSymbol ??= context.SemanticModel.Compilation.GetTypeByMetadataName("Sakuno.Avm.Abc.AbcMultiname");
            _methodSymbol ??= context.SemanticModel.Compilation.GetTypeByMetadataName("Sakuno.Avm.Abc.AbcMethod");
            _classSymbol ??= context.SemanticModel.Compilation.GetTypeByMetadataName("Sakuno.Avm.Abc.AbcClass");

            if (context.Node is not ConstructorDeclarationSyntax
                {
                    Parent: ClassDeclarationSyntax { Parent: NamespaceDeclarationSyntax { } namespaceDeclaration } classDeclaration
                } constructorDeclaration || namespaceDeclaration.Name.ToString() != "Sakuno.Avm.Abc.Instructions")
                return;

            var instructionName = string.Empty;

            foreach (var attributeList in classDeclaration.AttributeLists)
                foreach (var attribute in attributeList.Attributes)
                {
                    var symbolInfo = context.SemanticModel.GetSymbolInfo(attribute);

                    if (SymbolEqualityComparer.Default.Equals(symbolInfo.Symbol?.ContainingType, _attributeSymbol))
                    {
                        var argument = attribute.ArgumentList!.Arguments[0];
                        var expression = (MemberAccessExpressionSyntax)argument.Expression;

                        instructionName = expression.Name.ToString();
                    }
                }

            if (string.IsNullOrEmpty(instructionName))
                return;

            var parameters = new List<ParameterKind>();

            foreach (var parameter in constructorDeclaration.ParameterList.Parameters)
            {
                if (context.SemanticModel.GetDeclaredSymbol(parameter) is not IParameterSymbol parameterSymbol)
                    throw new Exception();

                var type = parameterSymbol.Type;

                switch (type.SpecialType)
                {
                    case SpecialType.System_Byte:
                        parameters.Add(ParameterKind.U8);
                        break;

                    case SpecialType.System_UInt32:
                        parameters.Add(ParameterKind.UnsignedInteger);
                        break;

                    case SpecialType.System_Double:
                        parameters.Add(ParameterKind.Double);
                        break;

                    case SpecialType.System_String:
                        parameters.Add(ParameterKind.String);
                        break;

                    case SpecialType.System_Int32:
                        parameters.Add(GetParameter(parameter, context));
                        break;

                    default:
                        if (SymbolEqualityComparer.Default.Equals(type, _namespaceSymbol))
                            parameters.Add(ParameterKind.Namespace);
                        else if (SymbolEqualityComparer.Default.Equals(type, _multinameSymbol))
                            parameters.Add(ParameterKind.Multiname);
                        else if (SymbolEqualityComparer.Default.Equals(type, _methodSymbol))
                            parameters.Add(ParameterKind.Method);
                        else if (SymbolEqualityComparer.Default.Equals(type, _classSymbol))
                            parameters.Add(ParameterKind.Class);
                        else
                            throw new InvalidOperationException(type.ToString());
                        break;
                }
            }

            _candidateInstructions.Add(new(instructionName, classDeclaration.Identifier.Text, parameters));
        }

        private ParameterKind GetParameter(ParameterSyntax parameter, GeneratorSyntaxContext context)
        {
            foreach (var attributeList in parameter.AttributeLists)
                foreach (var attribute in attributeList.Attributes)
                {
                    var symbolInfo = context.SemanticModel.GetSymbolInfo(attribute);

                    if (!SymbolEqualityComparer.Default.Equals(symbolInfo.Symbol?.ContainingType, _parameterAttributeSymbol))
                        continue;

                    var argument = attribute.ArgumentList!.Arguments[0];
                    var expression = (MemberAccessExpressionSyntax)argument.Expression;

                    return expression.Name.ToString() switch
                    {
                        "U30" => ParameterKind.U30,
                        "S24" => ParameterKind.S24,

                        _ => throw new InvalidOperationException(),
                    };
                }

            return ParameterKind.Integer;
        }
    }
}
