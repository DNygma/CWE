using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CWE.Models
{
    public class CurrencyQueue
    {
        CEA_DBContext _context;
        public CurrencyQueue(CEA_DBContext context)
        {
            _context = context;
        }
        

        // Add new request item to the top of the quee
        public static void AddQueueTop(CurrencyQueue newReq)
        {
            Queue<CurrencyQueue> q = new Queue<CurrencyQueue>();
            q.Enqueue(newReq);
        }

        // Remove item from the top of the queue
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
        public string Queue_Target { get; set; }
    }
}
