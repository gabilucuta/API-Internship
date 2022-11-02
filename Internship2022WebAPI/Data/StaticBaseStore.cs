using Internship2022WebAPI.Data;
using System.Collections.Generic;
using System.Linq;



namespace Internship2022WebAPI.Data
{
    public interface IStaticDatabaseStore
    {
        List<Store> getStores();
        Store createStore(Store store);
        Store removeStore(Store store);
        Store editStore(Store store);
        Store GetById(Guid id);
        Store GetTheOldest();
        Store GetTheMostRecent();
        Store SwitchOwnerName(Store store);



        List<Store> getByKeyword(string keyword);
        List<Store> GetByCountry(string country);
        List<Store> GetByCity(string city);
        List<Store> GetByMonthlyIncome();  
        List<Store> GetByYear(string year);






    }
    public class StaticBaseStore : IStaticDatabaseStore
    {
        private List<Store> Stores { get; set; } = new List<Store>();

        public List<Store> getStores()
        {
            return Stores;
        }

        public Store createStore(Store store)
        {
            Stores.Add(store);
            return store;

        }

        public Store GetTheOldest()
        {
            Store store = new Store();


            store = Stores[0];

            return store;
        }

        public List<Store> GetByYear(string year)
        {
            List<Store> myList = new List<Store>();
            for (int i = 0; i < Stores.Count; i++)
            {
                if(Stores[i].ActiveSince.ToString().Contains(year))
                {
                    myList.Add(Stores[i]);
                }    

            }
            return myList;

        }

      public Store SwitchOwnerName(Store store)
        {
            store.OwnerName = "GABRIEL";
            return store;
        }

        public Store GetTheMostRecent()
        {
            Store store = new Store();


            store = Stores[Stores.Count-1];

            return store;
        }

        public Store removeStore(Store store)
        {
            Stores.Remove(store);
            return store;
        }

        public Store GetById(Guid id)
        {
            return Stores.FirstOrDefault(p => p.Id == id);
        }

        public  List<Store> getByKeyword(string keyword)
        {
            List<Store> myList = new List<Store>();
            for (int i = 0; i < Stores.Count; i++)
            {
                var aux = Stores[i];

                if (aux.Id.ToString().Contains(keyword) || aux.Name.Contains(keyword) 
                    || aux.Country.Contains(keyword) || aux.City.Contains(keyword) 
                    || aux.MonthlyIncome.ToString().Contains(keyword) || aux.OwnerName.Contains(keyword)
                    || aux.ActiveSince.ToString().Contains(keyword))
                {
                    myList.Add(aux);
                }

            }

            return myList;
        }

        public List<Store> GetByCountry(string country)
        {
            var myList = new List<Store>();
            for (int i = 0; i < Stores.Count; i++)
            {
                if(Stores[i].Country.ToString().Contains(country))
                    myList.Add(Stores[i]);

            }

            return myList;
        }

        public List<Store> GetByCity(string city)
        {
            var myList = new List<Store>();
            for (int i = 0; i < Stores.Count; i++)
            {
                if (Stores[i].City.ToString().Contains(city))
                    myList.Add(Stores[i]);

            }

            return myList;
        }

        public Store editStore(Store store)
        {
            return store;
        }

        public List<Store> GetByMonthlyIncome()
        {
            for (int j = 0; j <= Stores.Count - 2; j++)
            {
                for (int i = 0; i <= Stores.Count - 2; i++)
                {
                    if (Stores[i].MonthlyIncome > Stores[i + 1].MonthlyIncome)
                    {
                        Store temp = Stores[i + 1];
                        Stores[i + 1] = Stores[i];
                        Stores[i] = temp;
                    }
                }
            }
            return Stores;
        }







    }
}