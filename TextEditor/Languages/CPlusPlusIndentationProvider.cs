namespace TextEditor.Languages
{
    public class CPlusPlusIndentationProvider : IndentationProvider
    {
        bool NeedIndentation(string text)
        {
            if (text.TrimEnd(' ').EndsWith(":"))
                return true;

            int j = 0;
            while (j < text.Length && text[j] != '#') { j++; }

            if (j == text.Length)
                return false;

            text = text.Substring(0, j);

            return text.TrimEnd(' ').EndsWith(":");
        }

        int GuessIndentLevel(string text)
        {
            int indentLevel = GetIndentLevel(text);

            if (NeedIndentation(text))
                indentLevel += 4;

            return indentLevel;
        }

        public override int GuessIndentLevel(string text, int index)
        {
            var lineText = ExtractLineText(ref text, index - 2).TrimEnd('\r');

            int indentLevel = GetIndentLevel(lineText);

            /*if (IsBracketOpen(ref text))
                return indentLevel;
            else */
            if (NeedIndentation(lineText))            
                return indentLevel + TabWidth;            

            lineText = lineText.TrimStart(' ');
            if (indentLevel >= TabWidth && 
                (lineText.StartsWith("return") || lineText.StartsWith("pass"))
                )
                return indentLevel - TabWidth;

            return indentLevel;
        }
    }
}