using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace LogServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting application consuming log events...");
            
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://+:5000")
                .Build();
    }
}
