using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.TopUpDiamond.Models
{
    public class DiamonModel
    {
        public string UserID { get; set; }
        public float Diamond { get; set; }
    }

    public class GoldModel
    {
        public int Gold { get; set; }
    }

    public class TankModel
    {
        public List<int> TankOwned { get; set; }
        public int TankSelected { get; set; }
    }
}
