using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CSharpier
{
    public partial class Printer
    {
        private Doc PrintExpressionStatementSyntax(ExpressionStatementSyntax node)
        {
            this.printNewLinesInLeadingTrivia.Push(true);
            var parts = new Parts(this.Print(node.Expression), ";");
            this.printNewLinesInLeadingTrivia.Pop();
            this.PrintTrailingTrivia(node.SemicolonToken.TrailingTrivia, parts);
            return Concat(parts);
        }
    }
}