using System;

namespace Temperature_Controller.Controllers
{
    public interface IValuesHolder
    {
        void Add(int temperatur, DateTime time);
        void Update(int temperatur, DateTime time);
        object Get(DateTime timeOne, DateTime timeTwo);
        void Delete(DateTime timeOne, DateTime timeTwo);
    }
}