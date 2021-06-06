using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Temperature_Controller.Controllers
{
    public class ValuesHolder : IValuesHolder
    {
        public List<Temperature> temperatureData = new List<Temperature>();
        public ValuesHolder(){}

        public void Add(int temperatur, DateTime time)
        {
            var temperatureClass = new Temperature(temperatur, time);
            temperatureData.Add(temperatureClass);
        }
        public void Update(int temperatur, DateTime time)
        {            
            var temperatureClass = new Temperature(temperatur, time);
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
        public object Get(DateTime timeOne, DateTime timeTwo)
        {            
            List<Temperature> GetTemperatureDataTime = new List<Temperature>();
            
            foreach (var item in temperatureData)
            {
                if (item.Time >= timeOne && item.Time <= timeTwo)
                {                    
                    GetTemperatureDataTime.Add(item);
                }
            }
            return GetTemperatureDataTime;
        }
        public void Delete(DateTime timeOne, DateTime timeTwo)
        {
            List<Temperature> GetTemperatureDataTime = new List<Temperature>();
            foreach (var item in temperatureData)
            {
                if (item.Time >= timeOne && item.Time <= timeTwo)
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

    }
}
