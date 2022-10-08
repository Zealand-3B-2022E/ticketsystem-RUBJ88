using CarLbrary;
using TicketClass1;

namespace RESTServiceStorebealtsbroen.StorebealtsbroenManager
{

    /// <summary>
    /// CRUD methods, create, read, update and delete
    /// </summary>
    public interface IStorebealtcs
    {

        /// <summary>
        /// get car in the list
        /// </summary>
        /// <returns>get</returns>
        List<Car> Get();

        /// <summary>
        /// Create Car
        /// </summary>
        /// <param name="platenumber">plate number</param>
        /// <returns>create</returns>
        Car Create(Car platenumber);
        
        /// <summary>
        /// Read all Car in the list
        /// </summary>
        /// <returns>empty of read</returns>
        List<Car> Read();


        /// <summary>
        /// Update a car 
        /// </summary>
        /// <param name="platenumber">Update plate number</param>
        /// <param name="car">Update car parameter</param>
        /// <returns>update</returns>
        Car Update(string platenumber,Car car);


        /// <summary>
        /// Delete a car 
        /// </summary>
        /// <param name="platenumber">Delete plate number </param>
        /// <returns>Delete</returns>
        Car Delete(String platenumber);


        public IEnumerable<Car> GetRange(int low, int high);


        List<Car> SearchDate(int? lowerDiscount, int? highDiscount);


        Car Get(String car);

        List<Car> Get(int fromPage, int toPage, out int actualTo, out int total);


    }
}
