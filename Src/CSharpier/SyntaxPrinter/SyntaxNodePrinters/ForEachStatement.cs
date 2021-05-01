using System;
using CSharpier.DocTypes;
using CSharpier.SyntaxPrinter;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CSharpier.SyntaxPrinter.SyntaxNodePrinters
{
    public static class ForEachStatement
    {
        public static Doc Print(ForEachStatementSyntax node)
        {
            var groupId = Guid.NewGuid().ToString();

            var result = Doc.Concat(
                ExtraNewLines.Print(node),
                Token.PrintWithSuffix(node.AwaitKeyword, " "),
                Token.Print(node.ForEachKeyword),
                " ",
                Token.Print(node.OpenParenToken),
                Doc.GroupWithId(
                    groupId,
                    Doc.Indent(
                        Doc.SoftLine,
                        Node.Print(node.Type),
                        " ",
                        Token.Print(node.Identifier),
                        " ",
                        Token.Print(node.InKeyword),
                        " ",
                        Node.Print(node.Expression)
                    ),
                    Doc.SoftLine
                ),
                Token.Print(node.CloseParenToken),
                node.Statement is BlockSyntax blockSyntax
                    ? Block.PrintWithConditionalSpace(blockSyntax, groupId)
                    : Node.Print(node.Statement)
            );

            return result;
        }
    }
}