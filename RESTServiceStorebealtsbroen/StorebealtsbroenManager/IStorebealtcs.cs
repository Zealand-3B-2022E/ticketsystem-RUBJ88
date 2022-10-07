using CarLbrary;
using TicketClass1;

namespace RESTServiceStorebealtsbroen.StorebealtsbroenManager
{
    public interface IStorebealtcs
    {

        List<Car> Get();
        Car Create(Car platenumber);
        List<Car> Read();

        Car Update(string platenumber,Car car);

        Car Delete(String platenumber);

        public IEnumerable<Car> GetRange(int low, int high);


        List<Car> SearchDate(int? lowerDiscount, int? highDiscount);


        Car Get(String car);

        List<Car> Get(int fromPage, int toPage, out int actualTo, out int total);


    }
}
