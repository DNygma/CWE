using System;
using System.Collections.Generic;
using System.Linq;
using CWE.Models;

namespace CWE.Services
{
    public class Scheduling 
    {
        private readonly CEA_DBContext _context;
        // Matching Pair Request List - Holds all requests that have reached target rate
        public static List<Request> MatchingPairRequestList = new List<Request>();
        // Email Pair List temporarily stores a current user from Matching Pair Request List
            // in order to grab all users emails
        //public List<String> EmailPairList = new List<String>();

        public Scheduling(CEA_DBContext context)
        {
            _context = context;
            // run scheduler function
            RunScheduler(_context);
        }

        // Begins the scheduler function
        public void RunScheduler(CEA_DBContext context)
        {
            string UserEmail = "";
            string Pair = "";
            // Creates new Database Context instance in order to run the scheduler 
                // simultaneously it cannot instantiate same object as rest of site
            using (var schedulerDB = new CEA_DBContext())
            {
                
                if (schedulerDB.Request != null)
                {
                    // Grab a list of all Requests from Database
                    List<Request> allRequests = (from req in schedulerDB.Request select req).ToList();

                    // If rates list gets too big we need to delete it 
                        // in order to not slow down our search
                    if(XMLParser.RatesList.Count > 122)
                    {
                        XMLParser.RatesList.Clear();
                    }

                    // Iterate through all requests
                    for (int index = 0; index < allRequests.Count; index++)
                    {
                        // Iterate through all rates
                        for (int count = 0; count < XMLParser.RatesList.Count; count++)
                        {
                            // If a request matches bid or asking price (do something)
                            if (allRequests[index].Request_TargetRte == XMLParser.RatesList[count].Bid ||
                                allRequests[index].Request_TargetRte == XMLParser.RatesList[count].Ask)
                            {
                                // Add matching request to Matching Pair Request List
                                MatchingPairRequestList.Add(allRequests[index]);
                                // If list contains values go ahead and push them out as they come in
                                if(MatchingPairRequestList.Count > 0)
                                {
                                    int tempCount = MatchingPairRequestList.Count();
                                    for (int i = 0; i < tempCount; i++)
                                    {
                                        UserEmail = MatchingPairRequestList[i].Email;
                                        Pair = MatchingPairRequestList[i].Request_Pair;
                                        // Notify user 
                                        Notifier.EmailNotification(UserEmail, Pair);
                                        UserEmail = null; Pair = null;
                                    }
                                    // Clear list + Reset Count
                                    MatchingPairRequestList.Clear();
                                    tempCount = 0;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
