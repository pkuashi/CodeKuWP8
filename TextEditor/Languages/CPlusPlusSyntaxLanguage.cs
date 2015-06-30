using System.Collections.Generic;
using TextEditor.Lexer;
using Windows.UI;

namespace TextEditor.Languages
{
    public class CPlusPlusSyntaxLanguage : SyntaxLanguage
    {
        public static readonly Color CommentColor = Color.FromArgb(255, 0, 128, 0);
        public static readonly Color StringColor = Color.FromArgb(255, 163, 21, 21);
        public static readonly Color BuiltinsColor = Color.FromArgb(255, 43, 145, 175);
        public static readonly Color KeywordsColor = Color.FromArgb(255, 0, 0, 255);

        public CPlusPlusSyntaxLanguage()
            : base("C/C++")
        {
            this.Grammer = new CPlusPlusGrammer();

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