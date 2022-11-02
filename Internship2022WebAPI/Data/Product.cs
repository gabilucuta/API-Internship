namespace Internship2022WebAPI.Data
{
    public class Product
    {
        
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public  int[] Ratings { get; set; } = new int[4];
       
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public int RatingsCount { get; set;}

    }
}
