using Internship2022WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace Internship2022WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStaticDatabaseStore _staticDataBaseStore;
        public StoreController(IStaticDatabaseStore staticDatabaseStore)
        {
            _staticDataBaseStore = staticDatabaseStore;
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            return Ok(_staticDataBaseStore.getStores());
        }

        [HttpGet("get/{keyword}")]
        public IActionResult GetByKeyword(string keyword)
        {
           List<Store> store = _staticDataBaseStore.getByKeyword(keyword);
            if (store is null)
                return NotFound();

            return Ok(store);
        }

        [HttpGet("get/by/Country")]
        public IActionResult GetByCountry(string country)
        {
            List<Store> store = _staticDataBaseStore.GetByCountry(country);  
            return Ok(store);

        }

        [HttpGet("get/by/City")]
        public IActionResult GetByCity(string city)
        {
            List<Store> store = _staticDataBaseStore.GetByCity(city);
            return Ok(store);

        }

        [HttpGet("get/by/MonthlyIncome")]
        public IActionResult GetByMonthlyIncome()
        {
            List<Store> store = _staticDataBaseStore.GetByMonthlyIncome();
            return Ok(store);

        }

        [HttpGet("get/by/Oldest")]
        public IActionResult GetByOldest()
        {
            return Ok(_staticDataBaseStore.GetTheOldest());
        }

        [HttpPatch("get/by/SwitchOwnerName")]
        public IActionResult GetOwnerName(Store store)
        {
            return Ok(_staticDataBaseStore.SwitchOwnerName(store));
        }

        [HttpGet("get/by/MostRecent")]
        public IActionResult GetByMostRecent()
        {
            return Ok(_staticDataBaseStore.GetTheMostRecent());
        }

        [HttpGet("get/by/Year")]
        public IActionResult GetByYear(string year)
        {
            return Ok(_staticDataBaseStore.GetByYear(year));
        }

        [HttpPost("create")]
        public IActionResult Create(Store store)
        {
            return Ok(_staticDataBaseStore.createStore(store));
        }


        [HttpPatch("edit")]
        public IActionResult Edit(Store store)
        {
            return Ok(_staticDataBaseStore.editStore(store));
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Guid Id)
        {
            var store = _staticDataBaseStore.GetById(Id);
            if (store is null)
                return NotFound();

            return Ok(_staticDataBaseStore.removeStore(store));
        }
    }
}
