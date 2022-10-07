using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;
using CarLbrary;
using MCLibrary;
using Microsoft.AspNetCore.Http.Features;
using TicketClass1;

namespace RESTServiceStorebealtsbroen.StorebealtsbroenManager
{
    public class CarManager : IStorebealtcs, IItem
    {
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

            //new MC() {Licensplate = "ABC 1234", Discount = 20, Date = DateTime.Parse("10.03.2022")},
            //new MC() {Licensplate = "GDH 1234", Discount = 20, Date = DateTime.Parse("09.03.2022")},
            //new MC() {Licensplate = "THD 1236", Discount = 20, Date = DateTime.Parse("10.03.2022")},
            //new MC() {Licensplate = "TJH 1286", Discount = 20, Date = DateTime.Parse("10.03.2022")},
            //new MC() {Licensplate = "ERT 1346", Discount = 20, Date = DateTime.Parse("10.03.2022")},
            //new MC() {Licensplate = "NMB 1346", Discount = 20, Date = DateTime.Parse("10.03.2022")},
            //new MC() {Licensplate = "YPH 1246", Discount = 20, Date = DateTime.Parse("10.03.2022")},
        };


        public List<Car> Get()
        {
            return new List<Car>(_items);

        }

        public Car Create(Car car)
        {
            {
                if (_items.Exists(c => c.Plate() == c.Plate()))
                    throw new ArgumentException("Plate already exist");

                _items.Add(car);
                return car;
            }
        }

        public List<Car> Read()
        {
            throw new NotImplementedException();
        }

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


        public List<Car> SearchDate(int? lowerDiscount, int? highDiscount)
        {
            List<Car> carTemp = (lowerDiscount is null) ? _items : _items.Where(c => c.Discount >= lowerDiscount).ToList();

            return (highDiscount is null) ? carTemp : carTemp.Where(c => c.Discount <= highDiscount).ToList();
        }

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

        public List<Car> Get(int fromPage, int toPage, out int actualTo, out int total)
        {
            // sætter antal i listen
            total = _items.Count;

            // tjekker at fra index ikke er større end antal i listen
            if (fromPage > total - 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            // sætter til index til laveste af toPage og total
            // fx toPage = 50  og  total = 45
            // så bliver actualTo = 45 - 1 = 44 (vi starter fra 0)
            actualTo = (toPage < total) ? toPage : total - 1;

            // laver en ny liste
            List<Car> returnList = new List<Car>();
            // fylder listen med de 'rigtige' værdier
            for (int i = fromPage; i <= actualTo; i++)
            {
                returnList.Add(_items[i]);
            }

            return returnList;
        }

        public Car Delete(string plateNumber)
        {
            Car deleteplate = Get(plateNumber);
            _items.Remove(deleteplate);
            return deleteplate;
        }


        public IEnumerable<Item> GetWithFilter(ItemsFeature filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetFromSubstring(string substring)

        {
            if (substring == null)
            {
                _items.Where(i => i.Licenseplate.Contains(substring));
            }

            throw new ArgumentException("licensplate don´t exist");
        }

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


    


        
            




    








  
        



   
        


    
