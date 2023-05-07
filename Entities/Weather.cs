namespace Entities
{
    public class Weather : BaseEntity<long>
    {
        public double Value { get; set; }
        public DateTime Date { get; set; }
    }
}