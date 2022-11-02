using Internship2022WebAPI.Data;



namespace Internship2022WebAPI.Data
{
    public interface IStaticDatabase
    {
        List<Product> GetProducts();
        Product GetById(Guid id);
        Product AddProduct(Product product);
        Product RemoveProduct(Product product);
        Product EditProduct(Product product);
        List<Product> GetByKeyword(string keyword);
        List<Product> GetByRatingAsc();
        List<Product> GetByRatingDesc();
        Product GetTheMostRecent();
        Product GetTheOldest();

    }
    public class StaticDatabase : IStaticDatabase
    {
        private List<Product> Products { get; set; } = new List<Product>();

        public List<Product> GetProducts()
        {
            return Products;
        }

        public Product AddProduct(Product product)
        {
            Products.Add(product);
            return product;
        }

        public Product GetTheMostRecent()
        {
            Product product = new Product();

            for (int i = 0; i < Products.Count; i++)
            {
                for (int j = 0; j < Products.Count; j++)
                {
                   int compare = DateTime.Compare(Products[i].CreatedOn, Products[j].CreatedOn);
                    if(compare > 0)
                    {
                        product = Products[i];
                    }

                }

            }

            return product;
        }

        public Product GetTheOldest()
        {
            Product product = new Product();

            for (int i = 0; i < Products.Count; i++)
            {
                for (int j = 0; j < Products.Count - 2; j++)
                {
                    int compare = DateTime.Compare(Products[i].CreatedOn, Products[j].CreatedOn);
                    if (compare > 0)
                    {
                        product = Products[j];

                    }

                }

            }

            return product;


        }


        public Product EditProduct(Product product)
        {
            return product;
        }

        public Product RemoveProduct(Product product)
        {
            Products.Remove(product);
            return product;
        }

        public Product GetById(Guid id)
        {
            return Products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetByKeyword(string keyword)
        {
            List < Product > myList = new List<Product>();
            for (int i = 0; i < Products.Count; i++)
            {
                var aux = Products[i];

                if (aux.Id.ToString().Contains(keyword) || aux.Ratings.ToString().Contains(keyword) || aux.Name.Contains(keyword) || aux.Description.Contains(keyword) || aux.CreatedOn.ToString().Contains(keyword))
                {
                    myList.Add(aux);
                }

            }

            return myList;
           
        }

        public List<Product> GetByRatingAsc()
        {

            for (int i = 0; i < Products.Count; i++)
            {
                var aux = Products[i];

                int sum = 0;
                for (int j = 0; j < aux.Ratings.Length; j++)
                {
                    sum += aux.Ratings[j];

                }

                Products[i].RatingsCount = sum/5;

            }

           Products.OrderBy(p => p.RatingsCount).ToList();



              return Products;
            
        }

        public List<Product> GetByRatingDesc()
        {

            for (int i = 0; i < Products.Count; i++)
            {
                var aux = Products[i];

                int sum = 0;
                for (int j = 0; j < aux.Ratings.Length; j++)
                {
                    sum += aux.Ratings[j];

                }

                Products[i].RatingsCount = sum / 5;

            }

            Products.OrderByDescending(p => p.RatingsCount).ToList();




            return Products;

        }
    }

}
