namespace Internship2022WebAPI.Data
{
    public class Store
    {
        
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = String.Empty;
        public string Country { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;

        public int MonthlyIncome { get; set; }
        public string OwnerName{ get; set; } = String.Empty;


        public DateTime ActiveSince { get; set; } = DateTime.UtcNow;


    }
}
