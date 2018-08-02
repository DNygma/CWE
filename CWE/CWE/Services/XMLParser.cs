using CWE.Models;
using CWE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace CWE.Services
{
    
    public class Rate
    {
        public string RateSymbol, Bid, Ask, High, Low, Direction, Last;
        public Rate()
        {

        }
    }

    public class XMLParser
    {
        //private readonly CEA_DBContext _context;
        public static List<Rate> RatesList = new List<Rate>();
        public List<Rate> ParseAndAddToRateList(string URLString)
        {
            XmlTextReader reader = new XmlTextReader(URLString);

            Rate rate = new Rate();
            string PrevValue = "";
            while (reader.Read())
            {
                if (reader.Name == "Rate")
                {
                    rate = new Rate();
                }
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        //Console.Write("<" + reader.Name);

                        while (reader.MoveToNextAttribute()) // Read the attributes.
                            Console.Write(" " + reader.Name + "='" + reader.Value + "'");
                        if (reader.Name == "Symbol")
                        {
                            rate.RateSymbol = reader.Value;
                        }
                        Console.Write(">");
                        Console.WriteLine(">");
                        break;
                    case XmlNodeType.Text: //Display the text in each element.
                        PrevValue = reader.Value;
                        Console.WriteLine(reader.Value);
                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.
                        if (reader.Name == "Bid")
                        {
                            rate.Bid = PrevValue;
                        }
                        else if (reader.Name == "Ask")
                        {
                            rate.Ask = PrevValue;
                        }
                        else if (reader.Name == "High")
                        {
                            rate.High = PrevValue;
                        }
                        else if (reader.Name == "Low")
                        {
                            rate.Low = PrevValue;
                        }
                        else if (reader.Name == "Direction")
                        {
                            rate.Direction = PrevValue;
                        }
                        else if (reader.Name == "Last")
                        {
                            rate.Last = PrevValue;
                            RatesList.Add(rate);
                        }
                        Console.Write("</" + reader.Name);
                        Console.WriteLine(">");
                        break;
                }
            }

            return RatesList;
        }

        public XMLParser()
        {
        }
    }
}
