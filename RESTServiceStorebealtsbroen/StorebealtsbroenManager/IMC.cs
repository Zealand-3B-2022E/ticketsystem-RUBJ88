using CarLbrary;
using MCLibrary;

namespace RESTServiceStorebealtsbroen.StorebealtsbroenManager
{
    public interface IMC
    {
        List<MC> Get();
        MC Create(MC platenumber);
        List<MC> Read();

        MC Update(string platenumber, MC mc);

        MC Delete(String platenumber);

        public IEnumerable<MC> GetRange(int low, int high);


        List<MC> SearchDate(int? lowerDiscount, int? highDiscount);


        MC Get(String mc);

        List<MC> Get(int fromPage, int toPage, out int actualTo, out int total);
    }
}
