using CWE.Models;
using CWE.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class ScheduleTest
    {
        CEA_DBContext _context;
        public ScheduleTest()
        {
            _context = new CEA_DBContext();
        }

        [Fact(DisplayName = "Pulls in correct Database")]
        public void Test1()
        {
            var scheduler = new Scheduling(_context);
            scheduler.RunScheduler(_context);
        }

        [Fact(DisplayName = "Failing Scheduler Test")]
        public void Test2()
        {
            throw new NotImplementedException();
        }
    }
}