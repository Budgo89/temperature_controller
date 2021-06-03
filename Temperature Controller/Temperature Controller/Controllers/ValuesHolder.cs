using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Temperature_Controller.Controllers
{
    public class ValuesHolder : IValuesHolder
    {
        public List<TemperatureClass> TemperatureData { get; set; }

        public void Add(string temperatur, string time)
        {
            var temperatureClass = CreateClass(temperatur, time);
            TemperatureData.Add(temperatureClass);
        }
        public void Update(string temperatur, string time)
        {
            var temperatureClass = CreateClass(temperatur, time);
            foreach (var item in TemperatureData)
            {
                if (item.Time == temperatureClass.Time)
                {
                    TemperatureData.Remove(item);
                    TemperatureData.Add(temperatureClass);
                }
            }
        }
        public object Get(string timeOne, string timeTwo)
        {
            TemperatureData.Sort(delegate (TemperatureClass us1, TemperatureClass us2) { return us1.Time.CompareTo(us2.Time); });
            List<String> GetTemperatureDataTime = new List<string>();
            foreach (var item in TemperatureData)
            {
                if (Convert.ToDateTime(item.Time) <= Convert.ToDateTime(timeOne) && Convert.ToDateTime(item.Time) <= Convert.ToDateTime(timeTwo))
                {
                    string temperatureData = item.Temperatur + item.Time;
                    GetTemperatureDataTime.Add(temperatureData);
                }
            }
            return GetTemperatureDataTime;
        }
        public void Delete(string timeOne, string timeTwo)
        {
            TemperatureData.Sort(delegate (TemperatureClass us1, TemperatureClass us2) { return us1.Time.CompareTo(us2.Time); });
            List<String> GetTemperatureDataTime = new List<string>();
            foreach (var item in TemperatureData)
            {
                if (Convert.ToDateTime(item.Time) <= Convert.ToDateTime(timeOne) && Convert.ToDateTime(item.Time) <= Convert.ToDateTime(timeTwo))
                {
                    TemperatureData.Remove(item);
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
