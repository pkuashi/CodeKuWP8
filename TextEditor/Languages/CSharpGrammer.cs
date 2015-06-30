using System.Collections.Generic;
using System.Text.RegularExpressions;
using TextEditor.Lexer;

namespace TextEditor.Languages
{
    public class CSharpGrammer : IGrammer
    {
        public CSharpGrammer()
        {
            Rules = new GrammerRule[]
            {
                new GrammerRule(TokenType.Comment, new Regex("^(\\\\.*)")), // Comment
                new GrammerRule(TokenType.WhiteSpace, new Regex("^\\s")), // Whitespace
                new GrammerRule(TokenType.Operator, new Regex("^[\\+\\-\\*/%&|\\^~<>!]")), // Single Char Operator
                new GrammerRule(TokenType.Operator, new Regex("^((==)|(!=)|(<=)|(>=)|(<>)|(<<)|(>>)|(//)|(\\*\\*))")), // Double Char Operator
                new GrammerRule(TokenType.Delimiter, new Regex("^[\\(\\)\\[\\]\\{\\}@,:`=;\\.]")), // Single Delimiter
                new GrammerRule(TokenType.Delimiter, new Regex("^((\\+=)|(\\-=)|(\\*=)|(%=)|(/=)|(&=)|(\\|=)|(\\^=))")), // Double Char Operator
                new GrammerRule(TokenType.Delimiter, new Regex("^((//=)|(>>=)|(<<=)|(\\*\\*=))")), // Triple Delimiter

                new GrammerRule(TokenType.Identifier, new Regex("^[_A-Za-z][_A-Za-z0-9]*")), // Identifier

                new GrammerRule(TokenType.String, new Regex("^((\"\"\"(.*)\"\"\")|('''(.)*'''))", RegexOptions.IgnoreCase | RegexOptions.Multiline)),
                new GrammerRule(TokenType.String, new Regex("^((@'(?:[^']|'')*'|'(?:\\.|[^\\']|)*('|\\b))|(@\"(?:[^\"]|\"\")*\"|\"(?:\\.|[^\\\"])*(\"|\\b)))", RegexOptions.IgnoreCase | RegexOptions.Singleline)), // String Marker
            };

            Keywords = new string[]
            {
                "as", "break", "class", "continue", "do", "else", "finally", "for", "foreach", "from", "if", "interface", "namespace",
                "return", "struct", "try", "while", "with", "yield", "and", "or",
            };

            Builtins = new string[]
            {
                "bool", "Exception", "False", "float", "int", "int32", "int64", "list", "long", "object", "string", "String"
            };


        }

        public IEnumerable<GrammerRule> Rules { get; private set; }

        public IEnumerable<string> Builtins { get; private set; }

        public IEnumerable<string> Keywords { get; private set; }
    }
}