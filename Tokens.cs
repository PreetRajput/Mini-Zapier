using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;

namespace miniZapier
{
    internal class Tokens
    {
        char[] chars;
        int pos = 0;
        List<Lexer> tokens = new List<Lexer>();
        List<string> keywords = new List<string> {
        "click", "scroll", "wait", "type", "open", "close", "press", "release"
        };
        StringBuilder token = new StringBuilder();
        StringBuilder str = new StringBuilder();

        public Tokens(char[] chars)
        {
            this.chars= chars;
        }
        public List<Lexer> tokenExtracter()
        {
            while (pos<chars.Length)
            {
                
                checkWhitespace();
                while (pos < chars.Length && char.IsLetterOrDigit(chars[pos])) 
                {
                    if (char.IsDigit(chars[pos]))
                    {
                        while (pos < chars.Length && char.IsDigit(chars[pos]))
                        {
                        token.Append(chars[pos]);
                        pos++;
                        }
                        tokens.Add(new Lexer(Lexer.Type.Number, token.ToString()));
                        token.Clear();

                    }
                    else if (char.IsLetter(chars[pos]))
                    {
                        while (pos < chars.Length && (char.IsLetterOrDigit(chars[pos])))
                        {
                            token.Append(chars[pos]);
                            pos++;
                        }
                    }
                }
                if (token.Length>0)
                {
                    if (keywords.Contains(token.ToString()))
                    {
                        tokens.Add(new Lexer(Lexer.Type.Keyword, token.ToString()));
                        
                    }
                    

                    else
                    {
                        tokens.Add(new Lexer(Lexer.Type.Identifier, token.ToString()));
                    }

                }
                if (pos < chars.Length && chars[pos] == '"')
                {
                    pos++; // skip the opening quote

                    while (pos < chars.Length && chars[pos] != '"')
                    {
                        str.Append(chars[pos]);
                        pos++;
                    }

                    if (pos < chars.Length && chars[pos] == '"') // skip the closing quote
                        pos++;

                    tokens.Add(new Lexer(Lexer.Type.String, str.ToString()));
                    str.Clear();
                }

                if (pos < chars.Length && chars[pos] == '\n')
                {
                    tokens.Add(new Lexer(Lexer.Type.NewLine, null));

                    pos++;
                }
                token.Clear();
            }
            try
            {
                if (pos == chars.Length)
                {
                    tokens.Add(new Lexer(Lexer.Type.EndOfFile, null));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
                return tokens;

        }
        void advance()
        {
            pos++;
        }
        void checkWhitespace()
        {
            if (char.IsWhiteSpace(chars[pos]))
            {
                advance();
            }
        }
    }
}
