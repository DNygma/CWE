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
        public List<String> EmailPairList = new List<String>();

        public Scheduling(CEA_DBContext context)
        {
            _context = context;
            RunScheduler(_context);
        }

        public void RunScheduler(CEA_DBContext context)
        {
            string UserEmail = "";
            string Pair = "";
            using (var schedulerDB = new CEA_DBContext())
            {
                
                if (schedulerDB.Request != null)
                {
                    List<Request> allRequests = (from req in schedulerDB.Request select req).ToList();

                    for (int index = 0; index < allRequests.Count; index++)
                    {
                        for (int count = 0; count < XMLParser.RatesList.Count; count++)
                        {
                            if (allRequests[index].Request_TargetRte == XMLParser.RatesList[count].Bid ||
                                allRequests[index].Request_TargetRte == XMLParser.RatesList[count].Ask)
                            {
                                MatchingPairRequestList.Add(ReqList[index]);
                                if(MatchingPairRequestList.Count > 0)
                                {
                                    for (int i = 0; i < MatchingPairRequestList.Count; i++)
                                    {
                                        UserEmail = MatchingPairRequestList[i].Email;
                                        Pair = MatchingPairRequestList[i].Request_Pair;
                                        Notifier.EmailNotification(UserEmail, Pair);
                                    }
                                    MatchingPairRequestList.Clear();
                                }
                            }
                        }
                    }
                }
            }
        }
        
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

    }
}
