using CWE.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class CurrencyQueueTest
    {
        CEA_DBContext _context;
        public CurrencyQueueTest()
        {
            _context = new CEA_DBContext();
        }

        [Fact(DisplayName = "Takes Database and Assigns Values")]
        public void Test1()
        {
            var queue = new CurrencyQueue(_context);
            queue.Queue_CurrencyPair = "EURUSD";
            queue.Queue_Target = "1.32913";
            queue.Queue_UserID = "test@gmail.com";
        }

        [Fact(DisplayName = "Failing Queue Test")]
        public void Test2()
        {
            throw new NotImplementedException();
        }
    }
}
