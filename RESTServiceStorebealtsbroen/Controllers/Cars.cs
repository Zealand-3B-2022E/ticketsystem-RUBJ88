using System.ComponentModel;
using CarLbrary;
using Microsoft.AspNetCore.Mvc;
using RESTServiceStorebealtsbroen.Model;
using RESTServiceStorebealtsbroen.StorebealtsbroenManager;
using TicketClass1;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTServiceStorebealtsbroen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cars : ControllerBase
    {

        private IStorebealtcs tb = new CarManager();


        // GET: api/<Cars>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]


        public IActionResult Get()
        {
            String rangeValue = Request.Headers["Range"];
            if (rangeValue == null)
            {
                List<Car> list = tb.Get();
                return (list.Count == 0) ? NoContent() : Ok(list);
            }

            String[] values = rangeValue.Split("-");
            int lowIx = int.Parse(values[0]);
            int highIx = int.Parse(values[1]);


            IEnumerable<Car> list2 = tb.GetRange(lowIx, highIx);

            Response.Headers.Add("Content-Range", $"{lowIx}-{highIx}/*");

            return Ok(list2);
        }


        // GET api/<Cars>/5

        [HttpGet]
        [Route("{Licensplate}")] // URI
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]


        public IActionResult Get(string platenumber)
        {
            try
            {
                Car animal = tb.Get(platenumber);
                return Ok(platenumber);
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
        }


        // GET api/<Cars>
        [HttpGet]
        [Route("licensplate/{licensplate}")] // URI
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetPlate(String plateNumber)
        {
            Car car = tb.Get(plateNumber);

            return (plateNumber.Length > 0) ? Ok(car) : NoContent();
        }




        // POST api/<Cars>/5

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult Post([FromBody] Car plateNumber )
        {
            try
            {
                Car newPlates = tb.Create(plateNumber);
                String uri = "api/Platelicens/" + plateNumber.Licenseplate;
                return Created(uri, plateNumber);
            }
            catch (ArgumentException ae)
            {
                return Conflict(ae.Message);
            }

        }

        [HttpPut]
        [Route("{PlateNumner}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(string platenumber, [FromBody] Car licensplate)
        {
            try
            {
                return Ok(tb.Update(platenumber, licensplate));
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }

        }


        // DELETE api/<Cars>/5
        [HttpDelete]
        [Route("{PlateNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        

        public IActionResult Delete(string plateNumber)
        {
            try
            {
                return Ok(tb.Delete(plateNumber));
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
        }


        [HttpGet]
        [HttpGet]
        [Route("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Get([FromQuery] CarEndAndSrart filter)

        {
            
            List<Car> liste = tb.SearchDate(filter.Start, filter.End);
            return (liste.Count == 0) ? NoContent() : Ok(liste);

            
        }





    }

}




