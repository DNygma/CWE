using System;
using System.Collections.Generic;
using System.Linq;
using CWE.Models;

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

                    if(XMLParser.RatesList.Count > 122)
                    {
                        XMLParser.RatesList.Clear();
                    }

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
    }
}
