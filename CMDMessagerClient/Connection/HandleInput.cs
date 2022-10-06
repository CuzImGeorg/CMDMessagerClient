using CMDMessagerClient.Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDMessagerClient.Connection
{
    public class HandleInput
    {
        private HandleCMD handleCMD = new HandleCMD();

        public HandleInput()
        {
            Thread t = new Thread(() =>
            {
                waitforInput();
            });

            t.Start();
        }


        public void waitforInput()
        {
            string msg = Console.ReadLine();            

            if (msg.StartsWith("/"))
            {
                handleCMD.cmd(msg.Substring(1));
            }
            else
            {
                Program.handleConnection.sendAndRecive(msg + "<EOF>");

            }


            waitforInput();
        }


    }
}
