using System;
using System.ServiceModel;

namespace TestWeek4L.WCFSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(
                typeof(TestWeek4L.ClienteWCF.ClienteAnagrafica)))
            {
                host.Open();

                Console.WriteLine("=== Cliente WCF Service ===");
                Console.WriteLine("Premi un tasto per fermare il servizio ...");

                Console.ReadKey();
            }
        }
    }
}
