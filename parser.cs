using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniZapier
{
    internal class parser
    {
        List<Lexer> tokens= new List<Lexer>();
        List<node> alldaNodes = new List<node>();
        int pos = 0;
        public parser(List<Lexer> tokens)
        {
            this.tokens = tokens;
        }
        public List<node> parse()
        {
            while(pos<tokens.Count)
            {
                if (tokens[pos].type==Lexer.Type.Keyword)
                {
                    switch(tokens[pos].value)
                    {
                        case "open":
                            pos++;
                            String link = tokens[pos].value;
                            alldaNodes.Add(new openCmd(link));
                            pos += 2;
                            break;
                        case "wait":
                            pos++;
                            int time = int.Parse(tokens[pos].value);
                            alldaNodes.Add(new waitCmd(time));
                            pos += 2;
                            break;
                        case "scroll":
                            pos++;
                            String direction = tokens[pos].value;
                            pos++;
                            int pixels = int.Parse(tokens[pos].value);
                            alldaNodes.Add(new scrollCmd(direction,pixels));
                            pos += 2;
                            break;


                    }
                    
                }

            }
            return alldaNodes;
        }
    }
}
