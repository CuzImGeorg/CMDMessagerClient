using CMDMessagerClient.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDMessagerClient.Start
{
    public class Program
    {

        public static HandleConnection handleConnection { get; private set; }
        public static HandleInput handleInput { get; private set; }
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting Client");
            handleConnection = new HandleConnection();
            handleConnection.StartClient();
            handleInput = new HandleInput();

        }

    }
}
