using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class isntNumber:Exception
    {
        public new string Message = "It isn't number";
    }
    class NegativePower:Exception
    {
        public new string Message = "Capacity can't be less zero";
    }
    class NegativeTorque:Exception
    {
        public new string Message = "Torque can't be less zero";
    }

}
