using SimpleLanguage;

var lexer = new Lexer(
    @"
        a = 2 + 3 + 5;
        b = 2 + 3 + 5;
        Print a; 
        a = a - b;
        Print a;
    ");

lexer.Analyze();
var parser = new Parser(lexer.Tokens);
var rootNode = parser.ParseCode();
parser.Run(rootNode);

