using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using static CWE.Models.CurrencyQueue;
using static CWE.Models.Request;
using static CWE.Models.Notifier;
using CWE.Models;
using CWE.Services;
using CWE.Controllers;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using static CWE.Services.XMLParser;

namespace CWE.Services
{
    public class Scheduling
    {

        private readonly CEA_DBContext _context;
        public static List<Request> MatchingRequestList = new List<Request>();

        public Scheduling(CEA_DBContext t, string email)
        {
            _context = t;
            Console.WriteLine(t);
            Console.WriteLine(email);
            Console.WriteLine("BREAKPOINT");
            List<Models.Request> ReqList = _context.Request.Where(e => e.Email == email).ToList<Models.Request>();
            bool b = false;
            for (int index = 0; index < ReqList.Count; index++)
            {
                for (int count = 0; count < XMLParser.RatesList.Count; count++)
                {
                    if (ReqList[index].Request_Pair == XMLParser.RatesList[count].RateSymbol)
                    {

                        MatchingRequestList.Add(ReqList[index]);
                        b = true;
                    }
                }
            }
            if(b == true)
            {
                Console.WriteLine(MatchingRequestList);
                Console.WriteLine("REQUEST MET");
            }

            //CWE.Services.XMLParser XmlParser = new CWE.Services.XMLParser(_context);
            Console.WriteLine(XMLParser.RatesList);
        }
        // Request Req = new Request();


        //public CEA_DBContext CreateContext()
        //{
        //    var optionsBuilder = new DbContextOptionsBuilder();
        //    optionsBuilder.UseSqlServer("Server = DESKTOP - O7AC2QN; Database = CurrencyExchangeDB; Trusted_Connection = True; MultipleActiveResultSets = true");
        //    var context = new CEA_DBContext(optionsBuilder.Options);

        //    User user = new UserFactory(context).Create(WindowsIdentity.GetCurrent());
        //    return;
        //}
    }
}
