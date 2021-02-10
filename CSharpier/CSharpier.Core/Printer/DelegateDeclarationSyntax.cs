using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CSharpier.Core
{
    public partial class Printer
    {
        private Doc PrintDelegateDeclarationSyntax(DelegateDeclarationSyntax node)
        {
            var parts = new Parts();
            parts.Add(this.PrintModifiers(node.Modifiers));
            parts.Push(node.DelegateKeyword.Text, " ");
            parts.Add(this.Print(node.ReturnType));
            parts.Push(" ", node.Identifier.Text);
            if (node.TypeParameterList != null) {
                parts.Add(this.Print(node.TypeParameterList));
            }
            parts.Add(this.Print(node.ParameterList));
            this.PrintConstraintClauses(node, node.ConstraintClauses, parts);
            parts.Add(";");
            return Concat(parts);
        }
    }
}