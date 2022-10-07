using CarLbrary;
using MCLibrary;
using Microsoft.AspNetCore.Http.Features;
using RESTServiceStorebealtsbroen.Controllers;
using TicketClass1;

namespace RESTServiceStorebealtsbroen.StorebealtsbroenManager
{
    public class MCManager : IMC, IItem
    {

        private static List<MC> _items = new List<MC>()
        {
            new MC() {Licensplate = "ABC 1234", Discount = 20, Date = DateTime.Parse("10.03.2022")},
            new MC() {Licensplate = "GDH 1234", Discount = 20, Date = DateTime.Parse("09.03.2022")},
            new MC() {Licensplate = "THD 1236", Discount = 20, Date = DateTime.Parse("10.03.2022")},
            new MC() {Licensplate = "TJH 1286", Discount = 20, Date = DateTime.Parse("10.03.2022")},
            new MC() {Licensplate = "ERT 1346", Discount = 20, Date = DateTime.Parse("10.03.2022")},
            new MC() {Licensplate = "NMB 1346", Discount = 20, Date = DateTime.Parse("10.03.2022")},
            new MC() {Licensplate = "YPH 1246", Discount = 20, Date = DateTime.Parse("10.03.2022")},
        };


        public List<MC> Get()
        {
            return new List<MC>(_items);
        }

        public MC Create(MC platenumber)
        {
            if (_items.Exists(m => m.Plate() == m.Plate()))
                throw new ArgumentException("Plate already exist");

            _items.Add(platenumber);
            return platenumber;
        }

        public List<MC> Read()
        {
            throw new NotImplementedException();
        }

        public MC Update(string platenumber, MC mc)
        {
            MC plateNumber = Get(platenumber);
            if (plateNumber is not null)
            {
                plateNumber.Licensplate = mc.Licensplate;
                plateNumber.Date = mc.Date;
                plateNumber.Discount = mc.Discount;

            }

            return plateNumber;
        }

        public MC Delete(string platenumber)
        {
            MC deleteplate = Get(platenumber);
            _items.Remove(deleteplate);
            return deleteplate;
        }

        public IEnumerable<MC> GetRange(int low, int high)
        {
            if (low > _items.Count)
            {
                throw new ArgumentNullException();
            }

            if (high > _items.Count)
            {
                throw new ArgumentException();
            }

            List<MC> mc = new List<MC>();

            for (int i = low; i < high; i++)
            {
                mc.Add((MC)_items[i]);
            }

            for (int i = high; i > low; i--)
            {
                mc.Add((MC)_items[i]);
            }

            return mc;
        }
    

        public List<MC> SearchDate(int? lowerDiscount, int? highDiscount)
        {
            List<MC> mcTemp = (lowerDiscount is null) ? _items : _items.Where(c => c.Discount >= lowerDiscount).ToList();

            return (highDiscount is null) ? mcTemp : mcTemp.Where(c => c.Discount <= highDiscount).ToList();
        }

        public MC Get(string platenumber)
        {
            MC mc = _items.Find(m => m.Licensplate == platenumber);
            {
                if (mc == null)
                {
                    throw new KeyNotFoundException();
                }
            }
            return mc;
        }

        public List<MC> Get(int fromPage, int toPage, out int actualTo, out int total)
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
            List<MC> returnList = new List<MC>();
            // fylder listen med de 'rigtige' værdier
            for (int i = fromPage; i <= actualTo; i++)
            {
                returnList.Add(_items[i]);
            }

            return returnList;
        }

        public IEnumerable<Item> GetWithFilter(ItemsFeature filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetFromSubstring(string substring)
        {
            if (substring == null)
            {
                _items.Where(i => i.Licensplate.Contains(substring));
            }

            throw new ArgumentException("licensplate don´t exist");
        }
    }
}
