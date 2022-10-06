using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CMDMessagerClient.Connection
{
    public  class HandleConnection
    {
        public Socket sender;


        public void StartClient()
        {
             
            byte[] bytes = new byte[1024];

            // Connect to a remote device.  
            try
            {
                // Establish the remote endpoint for the socket.  
                // This example uses port 11000 on the local computer.  
               IPAddress ipAddress = IPAddress.Parse("212.87.212.36");
              //  IPAddress ipAddress = IPAddress.Parse("127.0.0.1");

                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 12000);

                // Create a TCP/IP  socket.  
                sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.  
                try
                {
                    sender.Connect(remoteEP);


                }
                catch (ArgumentNullException ane)
                {
                    Debug.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Debug.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            Thread t = new Thread(() =>
            {
                handleTextRsciver();

            });
            t.Start();

        



         }


        public void handleTextRsciver()
        {
            string data = null;
            byte[] bytes = new Byte[2048];

            while (true)
            {
                int bytesRec = sender.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                if (data.IndexOf("<EOF>") > -1)
                {

                    break;
                }
                

            }
            
           Console.WriteLine(data.Replace("<EOF>", ""));


            handleTextRsciver();


        }



        public string sendAndRecive(string txt)
        {
            byte[] bytes = new byte[8192];
            try
            {


                // Encode the data string into a byte array.  
                byte[] msg = Encoding.ASCII.GetBytes(txt);
                // Send the data through the socket.  
                int bytesSent = sender.Send(msg);

                // Receive the response from the remote device.  

            }
            catch (ArgumentNullException ane)
            {
                Debug.WriteLine("ArgumentNullException : {0}", ane.ToString());
            }
            catch (SocketException se)
            {
                Debug.WriteLine("SocketException : {0}", se.ToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine("Unexpected exception : {0}", e.ToString());
            }

            return Encoding.ASCII.GetString(bytes);

        }

        public void shutdown()
        {
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }

    }
}

