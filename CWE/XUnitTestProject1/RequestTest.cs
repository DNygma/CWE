using CWE.Controllers;
using CWE.Models;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class RequestTest
    {
        CEA_DBContext _context;
        public RequestTest()
        {
            _context = new CEA_DBContext();
        }

        [Fact(DisplayName = "User DB and Email Requests")]
        public void Test1()
        {
            string temp = "email@gmail.com";
            var req = new RequestController(_context);
            var reqController = req.Index(temp);

        }

        [Fact(DisplayName = "Failing Request Test")]
        public void Test2()
        {
            throw new NotImplementedException();
        }
    }
}
