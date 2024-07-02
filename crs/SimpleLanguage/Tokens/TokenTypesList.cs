namespace SimpleLanguage.Tokens;

internal class TokenTypesList
{
    public static Dictionary<string, TokenType> TokenTypes = new() {
        { "NUMBER", new TokenType("NUMBER", "^[0-9]*") },
        { "VARIABLE", new TokenType("VARIABLE", "^[a-z]*") },
        { "END", new TokenType("END", "^;") },
        { "SPACE", new TokenType("SPACE", "^[ \\n\\t\\r]") },
        { "ASSIGN", new TokenType("ASSIGN", "^[=]") },
        { "PRINT", new TokenType("PRINT", "^Print") },
        { "PLUS", new TokenType("PLUS", "^[+]") },
        { "MINUS", new TokenType("MINUS", "^[-]") },
        { "LPAR", new TokenType("LPAR", "^\\(") },
        { "RPAR", new TokenType("RPAR", "^\\)") },
    };
}
