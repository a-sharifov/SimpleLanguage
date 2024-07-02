using SimpleLanguage.Tokens;

namespace SimpleLanguage.AST;

internal record UnaryOperationNode(Token Operator, ExpressionNode Operand) : ExpressionNode;
