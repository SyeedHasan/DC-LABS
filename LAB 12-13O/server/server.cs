using System;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Configuration;

class EmployeeTCPServer
{
    static TcpListener listener;
    const int LIMIT = 5; //5 concurrent clients

    public static void Main()
    {
        listener = new TcpListener(3056);
        listener.Start();
        Console.WriteLine("Server mounted, listening to port 3056");
        
        for (int i = 0; i < LIMIT; i++)
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
            //soc.SetSocketOption(SocketOptionLevel.Socket,
            //        SocketOptionName.ReceiveTimeout,10000);
            Console.WriteLine("Connected: {0}", soc.RemoteEndPoint);

            try
            {
                Stream s = new NetworkStream(soc);
                StreamReader sr = new StreamReader(s);
                StreamWriter sw = new StreamWriter(s);
                sw.AutoFlush = true; // enable automatic flushing
                sw.WriteLine("{0} Employees available",
                      ConfigurationSettings.AppSettings.Count);
                while (true)
                {
                    string name = sr.ReadLine();
                    if (name == "" || name == null) break;
                    string job =
                        ConfigurationSettings.AppSettings[name];
                    if (job == null) job = "No such employee";
                    sw.WriteLine(job);
                }
                s.Close();
            }
            catch (Exception e)
            {
                    Console.WriteLine(e.Message);
            }
            Console.WriteLine("Disconnected: {0}", soc.RemoteEndPoint);
            soc.Close();
        }
    }
}
