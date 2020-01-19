using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Configuration;

namespace LAB_12_13P
{
    class TCPServer
    {
        static TcpListener listener;
        const int LIMIT = 5; // concurrent client limit

        static void Main(string[] args)
        {
            listener = new TcpListener(8490);
            listener.Start();
            #if LOG
                Console.WriteLine("Server mounted. Port: 8490");
            #endif
            for(int i=0; i<LIMIT; i++)
            {
                Thread t = new Thread(new ThreadStart(Service));
                t.Start();
            }
        }

        public static void Service()
        {
            while (true)
            {
                Socket soc = listener.AcceptSocket();
                try
                {
                    Stream s = new NetworkStream(soc);
                    StreamReader sR = new StreamReader(s);
                    StreamWriter sW = new StreamWriter(s);
                    sW.AutoFlush = true;
                    sW.WriteLine(" {0} Employees Available!", ConfigurationSettings.AppSettings.Count);
                    while(true)
                    {
                        string name = sR.ReadLine();
                        if (name == "" || name == null) break;
                        string job = ConfigurationSettings.AppSettings[name];
                        if (job == null) job = "No such employee!";
                        sW.WriteLine(job);
                    }

                    s.Close();
                }
                catch (Exception exc)
                {
                    Console.Write(exc.Message);
                }

                soc.Close();

            }
        }
    }
}
