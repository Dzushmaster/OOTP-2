using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace LPLab4
{
    class ExceptionDateOutOfRange:Exception
    {
        public new string Message = "Ошибка добавления: данный автомобиль не мог быть создан раньше, чем самый первый";
    }
    class ExceptionLifeSpan:Exception
    {
        public new string Message = "Error: lifespan can't be less or equal 0";
    }
    class ExceptionWeight:Exception
    {
        public new string Message = "Error: weight can't be less or equal 0";
    }
}
