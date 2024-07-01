namespace SimpleLanguage.Tokens;

internal class TokenTypesList
{
    public static Dictionary<string, TokenType> Values = new() {
        { "^[0-9]*", new TokenType("NUMBER", "^[0-9]*") },
        { "^[a-z]*", new TokenType("VARIABLE", "^[a-z]*") },
        { "^;", new TokenType("END", "^;") },
        { "^[ \\n\\t\\r]", new TokenType("SPACE", "^[ \\n\\t\\r]") },
        { "^ASSIGN", new TokenType("ASSIGN", "^ASSIGN") },
        { "^PRINT", new TokenType("PRINT", "^PRINT") },
        { "^PLUS", new TokenType("PLUS", "^PLUS") },
        { "^MINUS", new TokenType("MINUS", "^MINUS") },
        { "^\\(", new TokenType("LPAR", "^\\(") },
        { "^\\)", new TokenType("RPAR", "^\\)") },
    };
}
