using SimpleLanguage.Tokens;

namespace SimpleLanguage.AST;

internal record BinaryOperationNode(Token Token, ExpressionNode Left, ExpressionNode Right) : ExpressionNode;
 