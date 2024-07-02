using SimpleLanguage.Tokens;
using System.Text.RegularExpressions;

namespace SimpleLanguage;

internal class Lexer
{
    public string Code { get; set; }
    public int Position { get; set; }
    public List<Token> Tokens = [];

    public Lexer(string code)
    {
        Code = code;
    }

    public List<Token> Analyze()
    {
        while (Next())
        {

        }

        return Tokens;
    }

    public bool Next()
    {
        if (Position >= Code.Length)
        {
            return false;
        }

        var tokenTypesList = TokenTypesList.TokenTypes.Values;

        foreach (var tokenType in tokenTypesList)
        {
            var regex = new Regex(tokenType.Regex);
            var substring = Code[Position..];
            var match = regex.Match(substring);

            if (match.Success && match.Value != string.Empty)  
            {
                Position += match.Length;
                if (tokenType.Name != "SPACE") 
                {
                    var token = new Token(tokenType, match.Value, Position);
                    Tokens.Add(token);
                    //Console.WriteLine(token.ToString());
                }
                return true;
            }
        }

        throw new Exception($"{Position} - position error");
    }

}
