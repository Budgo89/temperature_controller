using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Temperature_Controller
{
    public class Temperature
    {
        public int Temperatur { get; set; }
        public DateTime Time { get; set; }
        public Temperature() { }
        public Temperature(int _temperatur, DateTime _time) 
        {
            Temperatur = _temperatur;
            Time = _time;
        }
    }

}
