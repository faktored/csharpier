using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CSharpier
{
    public partial class Printer
    {
        private Doc PrintBlockSyntax(BlockSyntax node)
        {
            if (node == null) // TODO why is this being called?
            {
                return "";
            }
            var statementSeparator = node.Parent is AccessorDeclarationSyntax && node.Statements.Count <= 1 ? Line : HardLine;
            return this.PrintStatements(node.OpenBraceToken, node.Statements, node.CloseBraceToken, statementSeparator);
        }
    }
}