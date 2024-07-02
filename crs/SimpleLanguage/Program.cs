using SimpleLanguage;

var lexer = new Lexer(
    @"
        a = 2 + 3 + 5;
        b = 2 + 3 + 5;
        PRINT a; 
        a = a - b;
        PRINT a;
    ");

lexer.Analyze();
var parser = new Parser(lexer.Tokens);
var rootNode = parser.ParseCode();
parser.Run(rootNode);

