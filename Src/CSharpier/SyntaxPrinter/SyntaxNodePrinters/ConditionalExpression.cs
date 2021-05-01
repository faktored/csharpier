using CSharpier.DocTypes;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CSharpier.SyntaxPrinter.SyntaxNodePrinters
{
    public static class ConditionalExpression
    {
        public static Doc Print(ConditionalExpressionSyntax node)
        {
            return Doc.Group(
                Doc.Indent(
                    Node.Print(node.Condition),
                    Doc.Line,
                    Token.Print(node.QuestionToken, " "),
                    Doc.Indent(Node.Print(node.WhenTrue)),
                    Doc.Line,
                    Token.Print(node.ColonToken, " "),
                    Doc.Indent(Node.Print(node.WhenFalse))
                )
            );
        }
    }
}