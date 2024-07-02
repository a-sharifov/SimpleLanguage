using SimpleLanguage.AST;
using SimpleLanguage.Tokens;

namespace SimpleLanguage;

internal class Parser
{
    public List<Token> Tokens = [];
    public int Position { get; set; }
    public Dictionary<string, string> Scope = [];

    public Parser(List<Token> tokens)
    {
        Tokens = tokens;
    }

    public Token? Require(params TokenType[] tokenTypes)
    {
        if (Position < Tokens.Count)
        {
            var token = Tokens[Position];
            if (tokenTypes.Any(x => x.Name == token.Type.Name))
            {
                ++Position;
                return token;
            }
        }
        return null;
    }

    public Token Match(params TokenType[] tokenTypes) => 
        Require(tokenTypes) ?? throw new Exception();

    public ExpressionNode ParseCode()
    {
        var root = new StatementsNode([]);

        while (Position < Tokens.Count)
        {
            var expression = ParseExpression();
            Require(TokenTypesList.TokenTypes["END"]);
            root.Nodes.Add(expression);
        }
        return root;
    }

    private ExpressionNode ParseExpression()
    {
        if (Require(TokenTypesList.TokenTypes["VARIABLE"]) == null)
        {
            var printNode = ParsePrint();
            return printNode;
        }

        Position -= 1;
        var leftNode = ParseVariableOrNumber();
        var token = Match(TokenTypesList.TokenTypes["ASSIGN"]);
        if(token != null)
        {
            var rightValueNode = ParseFormula();
            var binaryOperator = new BinaryOperationNode(token, leftNode, rightValueNode);
            return binaryOperator;
        }
        throw new Exception();
    }

    public ExpressionNode ParseFormula()
    {
        var leftNode = ParseVariableOrNumber();
        var op = Require(TokenTypesList.TokenTypes["PLUS"], TokenTypesList.TokenTypes["MINUS"]);
        while (op != null)
        {
            var rightNode = ParseVariableOrNumber();
            leftNode = new BinaryOperationNode(op, leftNode, rightNode);
            op = Require(TokenTypesList.TokenTypes["PLUS"], TokenTypesList.TokenTypes["MINUS"]);
        }
        return leftNode;
    }

    public ExpressionNode ParsePrint()
    {
        var token = Match(TokenTypesList.TokenTypes["PRINT"]);
        return new UnaryOperationNode(token, ParseFormula());
    }


    public ExpressionNode ParseVariableOrNumber()
    {
        var token = Match(
            TokenTypesList.TokenTypes["NUMBER"], 
            TokenTypesList.TokenTypes["VARIABLE"]);

        return token.Type.Name == "NUMBER" ? new NumberNode(token) : new ValueNode(token);
    } 

    public object? Run(ExpressionNode node)
    {
        if(node is NumberNode numberNode)
        {
            return int.Parse(numberNode.token.Text);
        }
        if(node is UnaryOperationNode unaryOperationNode)
        {
            var name = unaryOperationNode.Operator.Type.Name;

            if(name == "PRINT")
            {
                Console.WriteLine(Run(unaryOperationNode.Operand));
                return null;
            }

        }
        if(node is BinaryOperationNode binaryOperationNode)
        {
            var name = binaryOperationNode.Token.Type.Name;

            if (name == "MINUS")
            {
                return (int)Run(binaryOperationNode.Left)! - (int)Run(binaryOperationNode.Right)!;
            }
            if (name == "PLUS")
            {
                return (int)Run(binaryOperationNode.Left)! + (int)Run(binaryOperationNode.Right)!;
            }
            if (name == "ASSIGN")
            {
                var result = Run(binaryOperationNode.Right);
                var variableNode = binaryOperationNode.Left as ValueNode;
                Scope[variableNode!.Token.Text] = ((int)result!).ToString();
                return result;
            }
        }
        if(node is ValueNode valueNode)
        {
            if (Scope.TryGetValue(valueNode.Token.Text, out string? value))
            {
                return int.Parse(value);
            }
            throw new Exception();
        }
        if(node is StatementsNode statementsNode)
        {
            foreach (var expressionNode in statementsNode.Nodes)
            {
                Run(expressionNode);
            }
        }
        //throw new Exception();
        return null;
    }

}
