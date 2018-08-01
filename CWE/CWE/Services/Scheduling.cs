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

namespace CWE.Services
{
    public class Scheduling 
    {
        
        public static List<Request> MatchingRequestList;

        public Scheduling(string email)
        {
            //Request temp = new Request();
            //string ReqEmail = request.Email;
            //Console.WriteLine(context);
            //List<Models.Request> ReqList = context.Request.Where(e => e.Email == email).ToList<Models.Request>();

            //for (int index = 0; index < ReqList.Count; index++)
            //{
            //    for (int count = 0; count < XMLParser.RatesList.Count; count++)
            //    {
            //        if (ReqList[index].Request_Pair == XMLParser.RatesList[count].RateSymbol)
            //        {
            //            MatchingRequestList.Add(ReqList[index]);
                        
            //        }
            //    }
            //}
            //Console.WriteLine(MatchingRequestList);

            //CWE.Services.XMLParser XmlParser = new CWE.Services.XMLParser(context);
            //Console.WriteLine(XMLParser.RatesList);
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
