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
using Microsoft.AspNetCore.Mvc;

namespace CWE.Services
{
    public class Scheduling 
    {
        private readonly CEA_DBContext _context;
        public static List<Request> MatchingPairRequestList = new List<Request>();
        List<Models.Request> ReqList = null;

        public Scheduling(CEA_DBContext context)
        {
            _context = context;
            RunScheduler(_context);
        }

        public void RunScheduler(CEA_DBContext context)
        {
            CEA_DBContext schedulerDB = new CEA_DBContext();
            schedulerDB = context;
            if (schedulerDB.Request != null)
            {
                List<Request> allRequests = (from req in schedulerDB.Request select req).ToList();
                if (schedulerDB.Request != null)
                {
                    for (int index = 0; index < allRequests.Count; index++)
                    {
                        for (int count = 0; count < XMLParser.RatesList.Count; count++)
                        {
                            if (allRequests[index].Request_TargetRte == XMLParser.RatesList[count].Bid ||
                                allRequests[index].Request_TargetRte == XMLParser.RatesList[count].Ask)
                            {
                                MatchingPairRequestList.Add(ReqList[index]);
                                // b = true;
                            }
                        }
                    }
                }
            }
        }

        //public Scheduling(CEA_DBContext t)
        //{
        //    _context = t;

        //List<Models.Request> ReqList = _context.Request.Where(e => e.Email == email).ToList<Models.Request>();
        //for (int index = 0; index < ReqList.Count; index++)
        //{
        //    for (int count = 0; count < XMLParser.RatesList.Count; count++)
        //    {
        //        if (ReqList[index].Request_TargetRte == XMLParser.RatesList[count].Bid ||
        //            ReqList[index].Request_TargetRte == XMLParser.RatesList[count].Ask)
        //        {
        //            MatchingPairRequestList.Add(ReqList[index]);
        //            // b = true;
        //        }
        //    }
        //}
        //    //var allUsers = t.User.ToList<User>();
        //    var allRequests = t.Request.ToList<Request>();
        //    if (t.Request != null)
        //    {
        //        List<Models.Request> ReqList = null; //= allUsers.Where(e => e.User_ID == ).ToList<Models.Request>();
        //        for (int index = 0; index < allRequests.Count; index++)
        //        {
        //            for (int count = 0; count < XMLParser.RatesList.Count; count++)
        //            {
        //                if (allRequests[index].Request_TargetRte == XMLParser.RatesList[count].Bid ||
        //                    allRequests[index].Request_TargetRte == XMLParser.RatesList[count].Ask)
        //                {
        //                    MatchingPairRequestList.Add(ReqList[index]);
        //                    // b = true;
        //                }
        //            }
        //        }
        //    }
        //}




        //bool b = false;
        //for (int index = 0; index < ReqList.Count; index++)
        //{
        //    for (int count = 0; count < XMLParser.RatesList.Count; count++)
        //    {
        //        if (ReqList[index].Request_Pair == XMLParser.RatesList[count].RateSymbol)
        //        {

        //            MatchingRequestList.Add(ReqList[index]);
        //           // b = true;
        //        }
        //    }
        //}
        //if(b == true)
        //{
        //    Console.WriteLine(MatchingRequestList);
        //    Console.WriteLine("REQUEST MET");
        //}

        //CWE.Services.XMLParser XmlParser = new CWE.Services.XMLParser(_context);
        //    Console.WriteLine(XMLParser.RatesList);
        //}

    }
}
