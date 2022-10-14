using CMDMessagerClient.Start;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDMessagerClient.Connection
{
    public class HandleCMD
    {


        public void cmd(string msg)
        {
            switch(msg.Replace("<EOF>", ""))
            {
                case "cls": {

                    Console.Clear();
                    break;
                   
                }
                case "clear": {

                    Console.Clear();
                    break;
                }
                case "hide": {
                    Console.Clear();
                    break;
                }

                default:  
                {
                    Program.handleConnection.sendAndRecive("/" +msg + "<EOF>");

                    break;
                }
  
             }

            

            
        }
    }
}
