using System.Collections.Generic;
using TextEditor.Lexer;
using Windows.UI;

namespace TextEditor.Languages
{
    public class CSharpSyntaxLanguage : SyntaxLanguage
    {
        public static readonly Color CommentColor = Color.FromArgb(255, 0, 128, 0);
        public static readonly Color StringColor = Color.FromArgb(255, 163, 21, 21);
        public static readonly Color BuiltinsColor = Color.FromArgb(255, 43, 145, 175);
        public static readonly Color KeywordsColor = Color.FromArgb(255, 0, 0, 255);

        public CSharpSyntaxLanguage()
            : base("CSharp")
        {
            this.Grammer = new PythonGrammer();

            HighlightColors = new Dictionary<TokenType, Color>
            {
                { TokenType.Comment, CommentColor },
                { TokenType.String, StringColor },
                { TokenType.Builtins, BuiltinsColor },
                { TokenType.Keyword, KeywordsColor },
            };

            IndentationProvider = new CSharpIndentationProvider();            
        }
    }
}