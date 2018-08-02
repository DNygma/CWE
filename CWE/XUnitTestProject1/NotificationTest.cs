using CWE;
using CWE.Models;
using CWE.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class NotificationTest
    {
        CEA_DBContext _context;
        public NotificationTest()
        {
            _context = new CEA_DBContext();
        }

        [Fact(DisplayName = "Takes in Two Strings")]
        public void Test1()
        {
            string temp1 = "email@gmail.com";
            string temp2 = "Complete";
            var not = new Notifier();
            not.Notifier_ID = temp1;
            not.Notifier_NotificationString = temp2;
        }

        [Fact(DisplayName = "Failing Notification Test")]
        public void Test2()
        {
            throw new NotImplementedException();
        }
    }
}
