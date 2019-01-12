using System;
using Iot;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin;
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
            string url = "httpS://*:8080/";
            SignalR = WebApp.Start(url);

            Console.ReadKey();
        }
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
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
