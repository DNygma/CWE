using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CWE.Models;
using CWE.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CWE 
{
    public class Program
    {
        // New thread to parse the xml file throughout system
        public static void XMLParsingThread()
        {
            // Read in XML page
            string URLString = "https://rates.fxcm.com/RatesXML";
            // Create new parsing object
            CWE.Services.XMLParser XmlParser = new CWE.Services.XMLParser();
            while (true)
            {
                Thread.Sleep(10000);
                // Parse and add to Rate List
                XmlParser.ParseAndAddToRateList(URLString);
            }
        }

        public static void Main(string[] args)
        {
            // Create thread
            ThreadStart parse = new ThreadStart(XMLParsingThread);
            Console.WriteLine("In Main: Creating the XML Parsing Thread");
            Thread parseThread = new Thread(parse);
            parseThread.Name = "XML Parsing Thread";
            parseThread.Start();

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>() 
                .Build();
    }
}
