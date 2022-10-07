namespace RESTServiceStorebealtsbroen.Model
{
    public class CarEndAndSrart
    {
        public int? Start { get; set; }
        public int? End { get; set; }
    }



    /*
     * Som record - glem det
     */

    public record CarYearFilterRecord(int? Start, int? End);
}

