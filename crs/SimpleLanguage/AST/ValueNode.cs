using SimpleLanguage.Tokens;

namespace SimpleLanguage.AST;

internal record ValueNode(Token Token) : ExpressionNode;
