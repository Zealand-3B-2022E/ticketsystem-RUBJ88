using Microsoft.AspNetCore.Http.Features;

namespace RESTServiceStorebealtsbroen.StorebealtsbroenManager
{
    public interface IItem
    {
        public IEnumerable<Item> GetWithFilter(ItemsFeature filter);

        public IEnumerable<Item> GetFromSubstring(String substring);
    }
}
