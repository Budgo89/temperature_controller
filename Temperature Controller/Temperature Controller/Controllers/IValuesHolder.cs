namespace Temperature_Controller.Controllers
{
    public interface IValuesHolder
    {
        void Add(string temperatur, string time);
        void Update(string temperatur, string time);
        object Get(string timeOne, string timeTwo);
        void Delete(string timeOne, string timeTwo);
    }
}