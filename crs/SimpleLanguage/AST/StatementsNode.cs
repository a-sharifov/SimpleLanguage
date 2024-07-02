namespace SimpleLanguage.AST;

internal record StatementsNode(List<ExpressionNode> Nodes) : ExpressionNode
{
    public void Add(ExpressionNode node) =>
        Nodes.Append(node);
}
