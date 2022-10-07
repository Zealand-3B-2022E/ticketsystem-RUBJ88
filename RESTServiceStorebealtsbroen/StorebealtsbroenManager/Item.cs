namespace RESTServiceStorebealtsbroen.StorebealtsbroenManager
{
    public class Item
    {
        public Item(int? lowerDiscount, int? highDiscount)
        {
            LowerDiscount = LowerDiscount;
            HighDiscount = HighDiscount;
        }

        public int? LowerDiscount { get; set; }
        public int? HighDiscount { get; set; }

    }
    public record ItemsRecord(int? LowerDiscount, int? HighDiscount);
}

