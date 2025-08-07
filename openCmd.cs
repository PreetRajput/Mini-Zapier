using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniZapier
{
    internal class openCmd
    {
        public string url { get; set; }
        public openCmd(string url)
        {
            this.url = url;
        }
        public override string ToString()
        {
            return $"openCmd: {url}";
        }
    }
}
