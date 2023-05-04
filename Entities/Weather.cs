namespace Entities
{
    public class Weather : BaseEntity<long>
    {
        public long Id { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
    }
}