using CWE.Controllers;
using Microsoft.AspNetCore.Mvc;
using CWE.Models;
using CWE.Services;
using System;
using System.Xml;
using Xunit;

namespace XUnitTestProject1
{
    public class HelpPageTest
    {
        CEA_DBContext _context;
        public HelpPageTest()
        {
            _context = new CEA_DBContext();
        }

        [Fact(DisplayName = "Outputs Correct Help Page")]
        public void Test1()
        {
            var controller = new HomeController();
            var view = (ViewResult)controller.Help();
            var viewName = view.ViewName;

            Assert.True(string.IsNullOrEmpty(viewName) || viewName == "Help");
        }

        [Fact(DisplayName = "Failing Test")]
        public void Test2()
        {
            throw new NotImplementedException();
        }
    }
}
