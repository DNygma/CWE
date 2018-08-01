using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CWE.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CWE 
{
    public class Program
    {
        public static readonly CEA_DBContext _context;
        public static void CallToChildThread()
        {
            string URLString = "https://rates.fxcm.com/RatesXML";
            CWE.Services.XMLParser XmlParser = new CWE.Services.XMLParser(_context);
            while (true)
            {
                Thread.Sleep(10000);
                XmlParser.ParseAndAddToRateList(URLString);
            }
        }
        public static void Main(string[] args)
        {
            // String URLString = "https://rates.fxcm.com/RatesXML";
            ThreadStart childref = new ThreadStart(CallToChildThread);
            Console.WriteLine("In Main: Creating the Child thread");
            Thread childThread = new Thread(childref);
            childThread.Name = "XML Parsing Thread";
            childThread.Start();

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
