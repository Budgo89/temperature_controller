using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Temperature_Controller.Controllers
{
    public class ValuesHolder : IValuesHolder
    {
        public List<TemperatureClass> temperatureData = new List<TemperatureClass>();
        public ValuesHolder(){}

        public void Add(string temperatur, string time)
        {
            var temperatureClass = CreateClass(temperatur, time);
            temperatureData.Add(temperatureClass);
        }
        public void Update(string temperatur, string time)
        {
            var temperatureClass = CreateClass(temperatur, time);
            foreach (var item in temperatureData)
            {
                if (item.Time == temperatureClass.Time)
                {
                    temperatureData.Remove(item);
                    temperatureData.Add(temperatureClass);
                    break;
                }
            }
        }
        public object Get(string timeOne, string timeTwo)
        {
            temperatureData.Sort(delegate (TemperatureClass us1, TemperatureClass us2) { return us1.Time.CompareTo(us2.Time); });
            List<String> GetTemperatureDataTime = new List<string>();
            
            foreach (var item in temperatureData)
            {
                if (Convert.ToDateTime(item.Time) >= Convert.ToDateTime(timeOne) && Convert.ToDateTime(item.Time) <= Convert.ToDateTime(timeTwo))
                {
                    string temperatureDataString = item.Temperatur +" "+ item.Time;
                    GetTemperatureDataTime.Add(temperatureDataString);
                }
            }
            return GetTemperatureDataTime;
        }
        public void Delete(string timeOne, string timeTwo)
        {
            temperatureData.Sort(delegate (TemperatureClass us1, TemperatureClass us2) { return us1.Time.CompareTo(us2.Time); });
            List<TemperatureClass> GetTemperatureDataTime = new List<TemperatureClass>();
            foreach (var item in temperatureData)
            {
                if (Convert.ToDateTime(item.Time) >= Convert.ToDateTime(timeOne) && Convert.ToDateTime(item.Time) <= Convert.ToDateTime(timeTwo))
                {
                    GetTemperatureDataTime.Add(item);
                }
            }
            if (GetTemperatureDataTime.Count > 0)
            {
                foreach (var item in GetTemperatureDataTime)
                {
                    temperatureData.Remove(item);
                }
            }
        }

        private TemperatureClass CreateClass(string temperatur, string time)
        {
            var temperatureClass = new TemperatureClass()
            {
                Temperatur = temperatur,
                Time = time
            };
            return temperatureClass;
        }


    }
}
