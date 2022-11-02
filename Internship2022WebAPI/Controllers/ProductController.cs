using Internship2022WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace Internship2022WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IStaticDatabase _staticDatabase;
        public ProductController(IStaticDatabase staticDatabase)
        {
            _staticDatabase = staticDatabase;
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            return Ok(_staticDatabase.GetProducts());
        }

        [HttpGet("get/{keyword}")]
        public IActionResult GetByKeyword(string keyword)
        {
           List<Product> product = _staticDatabase.GetByKeyword(keyword);
            if (product is null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet("get/by/ratingAsc")]
        public IActionResult GetByRating()
        {
            List<Product> product = _staticDatabase.GetByRatingAsc();  
            return Ok(product);

        }

        [HttpGet("get/by/ratingDesc")]
        public IActionResult GetByRatingDesc()
        {
            List<Product> product = _staticDatabase.GetByRatingDesc();
            return Ok(product);

        }

        [HttpGet("get/by/dateTimeRecent")]
        public IActionResult GetTheRecent()
        {
            return Ok(_staticDatabase.GetTheMostRecent());


        }

        [HttpGet("get/by/dateTimeOldest")]
        public IActionResult GetTheOldest()
        {
            return Ok(_staticDatabase.GetTheOldest());
        }



        [HttpPost("create")]
        public IActionResult Create(Product product)
        {
            return Ok(_staticDatabase.AddProduct(product));
        }

        [HttpPatch("edit")]
        public IActionResult Edit(Product product)
        {
            return Ok(_staticDatabase.EditProduct(product));
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Guid Id)
        {
            var product = _staticDatabase.GetById(Id);
            if (product is null)
                return NotFound();

            return Ok(_staticDatabase.RemoveProduct(product));
        }
    }
}
