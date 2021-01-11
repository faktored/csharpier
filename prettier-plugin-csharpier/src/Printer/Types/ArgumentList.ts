import { printCommaList } from "../Helpers";
import { PrintMethod } from "../PrintMethod";
import { SyntaxTreeNode } from "../SyntaxTreeNode";
import { concat, group, hardline, indent, join, softline, line, doubleHardline } from "../Builders";

export interface ArgumentListNode extends SyntaxTreeNode<"ArgumentList"> {
    arguments: SyntaxTreeNode[];
}

export const print: PrintMethod<ArgumentListNode> = (path, options, print) => {
    const node = path.getValue();
    if (node.arguments.length === 0) {
        return "()";
    }

    return group(
        concat(["(", indent(concat([softline, printCommaList(path.map(print, "arguments"))])), softline, ")"]),
    );
};