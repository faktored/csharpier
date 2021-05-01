using System;
using System.Collections.Generic;
using System.Linq;
using CSharpier.DocTypes;
using CSharpier.SyntaxPrinter;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CSharpier.SyntaxPrinter.SyntaxNodePrinters
{
    public static class ForStatement
    {
        public static Doc Print(ForStatementSyntax node)
        {
            var groupId = Guid.NewGuid().ToString();

            var docs = new List<Doc>
            {
                ExtraNewLines.Print(node),
                Token.Print(node.ForKeyword, " "),
                Token.Print(node.OpenParenToken)
            };

            var innerGroup = new List<Doc> { Doc.SoftLine };
            if (node.Declaration != null)
            {
                innerGroup.Add(VariableDeclaration.Print(node.Declaration));
            }
            innerGroup.Add(
                SeparatedSyntaxList.Print(node.Initializers, Node.Print, " ")
            );
            innerGroup.Add(Token.Print(node.FirstSemicolonToken));
            if (node.Condition != null)
            {
                innerGroup.Add(Doc.Line, Node.Print(node.Condition));
            }
            else
            {
                innerGroup.Add(Doc.SoftLine);
            }

            innerGroup.Add(Token.Print(node.SecondSemicolonToken));
            if (node.Incrementors.Any())
            {
                innerGroup.Add(Doc.Line);
            }
            else
            {
                innerGroup.Add(Doc.SoftLine);
            }
            innerGroup.Add(
                Doc.Indent(
                    SeparatedSyntaxList.Print(
                        node.Incrementors,
                        Node.Print,
                        Doc.Line
                    )
                )
            );
            docs.Add(
                Doc.GroupWithId(groupId, Doc.Indent(innerGroup), Doc.SoftLine)
            );
            docs.Add(Token.Print(node.CloseParenToken));
            if (node.Statement is BlockSyntax blockSyntax)
            {
                docs.Add(Block.PrintWithConditionalSpace(blockSyntax, groupId));
            }
            else
            {
                // TODO 1 force braces? we do in if and else
                docs.Add(Doc.Indent(Doc.HardLine, Node.Print(node.Statement)));
            }

            return Doc.Concat(docs);
        }
    }
}