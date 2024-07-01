using SimpleLanguage.Tokens;

namespace SimpleLanguage;

internal class Lexer
{
    public string Text { get; set; }
    public int Position { get; set; }
    public Dictionary<string, TokenType> Tokens = [];

    public Lexer(string text)
    {
        Text = text;
    }

    public Dictionary<string, TokenType> Analyze()
    {
        while (Next())
        {

        }

        return Tokens;
    }

    public bool Next()
    {
        if(Position > Tokens.Count)
        {
            return false;
        }


        var tokenTypesList = TokenTypesList.Values;

        for (int i = 0; i < tokenTypesList.Count; i++)
        {

        }

    }

}
