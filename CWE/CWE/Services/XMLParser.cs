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
        // 
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
            // Read in XML String
            XmlTextReader reader = new XmlTextReader(URLString);
            Rate rate = new Rate();
            string PrevValue = "";
            // Start reading each rate
            while (reader.Read())
            {
                // Get rate 
                if (reader.Name == "Rate")
                {
                    // Create new object for each section of the XML file
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
                            // Set rate symbol
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
                            // Set bid
                            rate.Bid = PrevValue;
                        }
                        else if (reader.Name == "Ask")
                        {
                            // Set ask
                            rate.Ask = PrevValue;
                        }
                        else if (reader.Name == "High")
                        {
                            // Set high
                            rate.High = PrevValue;
                        }
                        else if (reader.Name == "Low")
                        {
                            // Set high
                            rate.Low = PrevValue;
                        }
                        else if (reader.Name == "Direction")
                        {
                            // Set direction
                            rate.Direction = PrevValue;
                        }
                        else if (reader.Name == "Last")
                        {
                            // Set last
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

        // XML Parser constructor
        public XMLParser()
        {
        }
    }
}
