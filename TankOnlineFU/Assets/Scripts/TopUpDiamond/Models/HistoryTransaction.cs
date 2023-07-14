using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckBotRecharge.Models
{
    public class HistoryTransaction
    {
        public string TransactionID { get; set; }
        public string TransactionTime { get; set; }
        public string TransactionContent { get; set; }
        public string Money { get; set; }
    }

    public class TransactionResponseAPI
    {
        public string LastUpdate { get; set; }
        public List<HistoryTransaction> ListHistoryTransaction { get; set; }
    }
}
