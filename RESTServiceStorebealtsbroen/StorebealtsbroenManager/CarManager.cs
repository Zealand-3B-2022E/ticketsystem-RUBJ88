using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;
using CarLbrary;
using MCLibrary;
using Microsoft.AspNetCore.Http.Features;
using TicketClass1;

namespace RESTServiceStorebealtsbroen.StorebealtsbroenManager
{

    /// <summary>
    /// The CarManager class contains inheritance IStorebelt and IItem, so all CRUD methods can be
    /// implement (Create, read, update and delete. This class also contain a static list of car-tickets, witch contains licensplate,
    /// discounts and dates.
    /// 
    /// </summary>
    public class CarManager : IStorebealtcs, IItem
    {

        /// <summary>
        /// The static list contains licensplate string, discount double and date DateTime.Parse.
        /// The filed is _items 
        /// </summary>
        private static List<Car> _items = new List<Car>()

        {
            new Car() {Licenseplate = "12346", Discount = 5, Date = DateTime.Parse("10.01.2022")},
            new Car() {Licenseplate = "32358", Discount = 2, Date = DateTime.Parse("03,01,2022")},
            new Car() {Licenseplate = "23456", Discount = 20, Date = DateTime.Parse("05,01,2022")},
            new Car() {Licenseplate = "98765", Discount = 10, Date = DateTime.Parse("06,01,2022")},
            new Car() {Licenseplate = "88775", Discount = 15, Date = DateTime.Parse("06,01,2022")},
            new Car() {Licenseplate = "55345", Discount = 12, Date = DateTime.Parse("07,01,2022")},
            new Car() {Licenseplate = "23456", Discount = 20, Date = DateTime.Parse("02,01,2022")},
            new Car() {Licenseplate = "98765", Discount = 18, Date = DateTime.Parse("10.03.2022")},

        };

        /// <summary>
        /// This methods does so the system can get Car in the list 
        /// </summary>
        /// <returns>Returning Car list in the system</returns>
        public List<Car> Get()
        {
            return new List<Car>(_items);

        }

        /// <summary>
        /// This method does so the system can create new car 
        /// </summary>
        /// <param name="car">Returning a exist method there pointing to create new Plate to the system</param>
        /// <returns>Return add car to the system</returns>
        /// <exception cref="ArgumentException">If the system already have the correct plate, the system throw new argument exception with a message "plate already exist
        /// </exception>
        public Car Create(Car car)
        {
            {
                if (_items.Exists(c => c.Plate() == c.Plate()))
                    throw new ArgumentException("Plate already exist");

                _items.Add(car);
                return car;
            }
        }

        /// <summary>
        /// This method does so the system can read all the list of car in the system
        /// </summary>
        /// <returns>empty</returns>
        /// <exception cref="NotImplementedException">empty</exception>
        public List<Car> Read()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// This method does so the system can update a car
        /// </summary>
        /// <param name="licensplate">Update and get all car licensplate in the system</param>
        /// <param name="cars">Update alle cars parameters with licensplate, date and discount propertie in the systems</param>
        /// <returns>Returning variable of plate number in the system </returns>
        public Car Update(string licensplate, Car cars)
        {
            Car plateNumber = Get(licensplate);
            if (plateNumber is not null)
            {
                plateNumber.Licenseplate = cars.Licenseplate;
                plateNumber.Date = cars.Date;
                plateNumber.Discount = cars.Discount;

            }

            return plateNumber;
        }
        /// <summary>
        /// This method does the system can search lower and higher discount percentages of car list in the system
        /// </summary>
        /// <param name="lowerDiscount">Searching the lower discount values of car list in the system </param>
        /// <param name="highDiscount">Searching the higher discount values of car list in the system</param>
        /// <returns>Returning the lower and higher discount percentages of car list</returns>
        public List<Car> SearchDate(int? lowerDiscount, int? highDiscount)
        {
            List<Car> carTemp = (lowerDiscount is null) ? _items : _items.Where(c => c.Discount >= lowerDiscount).ToList();

            return (highDiscount is null) ? carTemp : carTemp.Where(c => c.Discount <= highDiscount).ToList();
        }


        /// <summary>
        /// This method does so the system can find a special car plate number
        /// </summary>
        /// <param name="platenumber">Finding the special plate number in the system</param>
        /// <returns>Returning the variable of car</returns>
        /// <exception cref="KeyNotFoundException">If the plate number don´t exist, the system throw an exception KeyNotFountException</exception>
        public Car Get(string platenumber)
        {

            Car car = _items.Find(c => c.Licenseplate == platenumber);
            {
                if (car == null)
                {
                    throw new KeyNotFoundException();
                }
            }
            return car;
        }
        /// <summary>
        /// This method does so the system can get different kinds of values in the system
        /// </summary>
        /// <param name="fromPage">checking from index is not bigger than numbers in the list</param>
        /// <param name="toPage"> putting index from actualTo</param>
        /// <param name="actualTo">Putting to index to the lowest of toPage and total</param>
        /// <param name="total">putting number to the list</param>
        /// <returns>Create a new car list, and put the list with the correct values</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public List<Car> Get(int fromPage, int toPage, out int actualTo, out int total)
        {
            total = _items.Count;

            if (fromPage > total - 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            actualTo = (toPage < total) ? toPage : total - 1;

            List<Car> returnList = new List<Car>();
            for (int i = fromPage; i <= actualTo; i++)
            {
                returnList.Add(_items[i]);
            }

            return returnList;
        }
        /// <summary>
        /// This method does so the system can delete Car 
        /// </summary>
        /// <param name="plateNumber">Delete special plate number from the system</param>
        /// <returns>The variable of deleteplate</returns>
        public Car Delete(string plateNumber)
        {
            Car deleteplate = Get(plateNumber);
            _items.Remove(deleteplate);
            return deleteplate;
        }


        /// <summary>
        /// This method does so the system set a filter
        /// </summary>
        /// <param name="filter">parameter filter</param>
        /// <returns>empty</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Item> GetWithFilter(ItemsFeature filter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method does so the system can get substring
        /// </summary>
        /// <param name="substring">getting licensplate to the substring</param>
        /// <returns>empty</returns>
        /// <exception cref="ArgumentException">"licensplate don´t exist</exception>
        public IEnumerable<Item> GetFromSubstring(string substring)

        {
            if (substring == null)
            {
                _items.Where(i => i.Licenseplate.Contains(substring));
            }

            throw new ArgumentException("licensplate don´t exist");
        }

        /// <summary>
        /// This method does system can range cars in the system
        /// </summary>
        /// <param name="low">Range</param>
        /// <param name="high">Range</param>
        /// <returns>Variable of car</returns>
        /// <exception cref="ArgumentNullException">low range</exception>
        /// <exception cref="ArgumentException">high range</exception>
        public IEnumerable<Car> GetRange(int low, int high)
        {
            if (low > _items.Count)
            {
                throw new ArgumentNullException();
            }

            if (high > _items.Count)
            {
                throw new ArgumentException();
            }

            List<Car> car = new List<Car>();

            for (int i = low; i < high; i++)
            {
                car.Add((Car)_items[i]);
            }

            for (int i = high; i > low; i--)
            {
                car.Add((Car)_items[i]);
            }

            return car;
        }


    }

}


    


        
            




    








  
        



   
        


    
