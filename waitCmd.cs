using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace miniZapier
{
    internal class waitCmd: node 
    {
        int time;
        public waitCmd(int time)
        {
            this.time = time;

        }
        public override void execute()
        {
            Thread.Sleep(time);

        }
    }
}
