using SimpleLanguage.Tokens;

namespace SimpleLanguage.AST;

internal record NumberNode(Token token) : ExpressionNode;
    