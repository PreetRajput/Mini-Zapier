using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniZapier
{
    internal class Lexer
    {   
        public enum Type
            {
            Keyword,
            Identifier,
            String,
            Number,
            Symbol,
            NewLine,
            EndOfFile
        }
        Type type;
        String value;

        public Lexer(Type type, String value) 
        {
            this.type= type;
            this.value= value;
        }
        override
        public String ToString()
        {
            return $"Type: {type}, Value: {value}";
        }
    }
}
