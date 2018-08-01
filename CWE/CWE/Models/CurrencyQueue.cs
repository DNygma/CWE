﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CWE.Models
{
    public class CurrencyQueue
    {
        public CurrencyQueue()
        {

        }


        public static void AddQueueTop(CurrencyQueue newReq)
        {
            Queue<CurrencyQueue> q = new Queue<CurrencyQueue>();
            Console.Write("OBJECT ADDED TO TOP OF QUEUE");
            q.Enqueue(newReq);
            //Console.WriteLine(q.Peek());
            //Console.WriteLine("\nDequeuing '{0}'", q.Dequeue());
        }

        public static void RemoveQueueTop(Queue q)
        {
            q.Dequeue();
        }

        [Key]
        [Display(Name = "ID")]
        public string Queue_UserID { get; set; }
        [Display(Name = "Pair")]
        public string Queue_CurrencyPair { get; set; }
        [Display(Name = "Target Rate")]
        public double Queue_Target { get; set; }
        //public ICollection<Request> PacketProcessQueue { get; set; } //Request or Packet?
    }
}