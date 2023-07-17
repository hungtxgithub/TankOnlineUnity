using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckBotRecharge.Models
{
    public class TransactionInsertRequest
    {
        public string SecretKey { get; set; }
        public string UserID { get; set; }
        public string TransactionContent { get; set; }
        public DateTime TransactionTime { get; set; }
        public float Money{ get; set; }
    }
}
