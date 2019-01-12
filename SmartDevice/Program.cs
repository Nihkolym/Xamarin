using System;
using Iot;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Host.HttpListener;
using Microsoft.Owin.Hosting;
using Owin;

[assembly: OwinStartup(typeof(Program.Startup))]
namespace Iot
{
    class Program
    {
        static IDisposable SignalR = null;

        static void Main(string[] args)
        {
            string url = "http://localhost:8088";
            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }
            Console.ReadKey();
        }
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.UseCors(CorsOptions.AllowAll);
                app.MapSignalR();
            }
        }

        [HubName("MyHub")]
        public class MyHub : Hub
        {
            public void Send(string name, string message)
            {
                Console.WriteLine("JELLO");
                Clients.All.addMessage(name, message);
            }
        }
    }
}
