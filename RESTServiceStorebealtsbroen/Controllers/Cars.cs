using System.ComponentModel;
using CarLbrary;
using Microsoft.AspNetCore.Mvc;
using RESTServiceStorebealtsbroen.Model;
using RESTServiceStorebealtsbroen.StorebealtsbroenManager;
using TicketClass1;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTServiceStorebealtsbroen.Controllers
{

    /// <summary>
    /// The car controller contains GET, POST, PUT and DELETE API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class Cars : ControllerBase
    {
        /// <summary>
        /// Using Car manager
        /// </summary>

        private IStorebealtcs tb = new CarManager();


        // GET: api/<Cars>
        /// <summary>
        /// HttpGet - method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]


        public IActionResult Get()
        {
            // reading header field - if there is somethings 
            String rangeValue = Request.Headers["Range"];

            // Here is no header field
            if (rangeValue == null)
            {
                // Normal Get all request without paging
                List<Car> list = tb.Get();
                return (list.Count == 0) ? NoContent() : Ok(list);
            }
            // Here is paging using
            // finds from and to site

            String[] values = rangeValue.Split("-");
            int lowIx = int.Parse(values[0]);
            int highIx = int.Parse(values[1]);


            IEnumerable<Car> list2 = tb.GetRange(lowIx, highIx);

            Response.Headers.Add("Content-Range", $"{lowIx}-{highIx}/*");

            return Ok(list2);
        }


        // GET api/<Cars>/5
        /// <summary>
        /// Method HttpGet
        /// licensplate is URI
        /// </summary>
        /// <param name="platenumber">Get and try plate number by using try plate number and catch KeyNoFoundException</param>
        /// <returns> plate number if get is success and exception if the platen number is not found</returns>
        [HttpGet]
        [Route("{Licensplate}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]


        public IActionResult Get(string platenumber)
        {
            try
            {
                Car car = tb.Get(platenumber);
                return Ok(platenumber);
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
        }


        // GET api/<Cars>
        /// <summary>
        /// HttpGet method
        /// licensplate is URI
        /// </summary>
        /// <param name="plateNumber">Getplate from plate number</param>
        /// <returns>plate number lenght</returns>
        [HttpGet]
        [Route("licensplate/{licensplate}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetPlate(String plateNumber)
        {
            Car car = tb.Get(plateNumber);

            return (plateNumber.Length > 0) ? Ok(car) : NoContent();
        }




        // POST api/<Cars>/5
        /// <summary>
        /// HttpPost - method
        /// Create plate number from car
        /// </summary>
        /// <param name="plateNumber">try to create plate number, uri is api/platelicens plus. Catch an ArgumentException</param>
        /// <returns> created of uri and plate number, and return conflict with a message</returns>
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

        /// <summary>
        /// HttpPut - method
        /// platenumber - URI
        /// Update plate number
        /// </summary>
        /// <param name="platenumber">Update plate number, try return plate number ok and catch exception return not fount </param>
        /// <param name="licensplate">Update platelicens, try return plate number ok and catch exception return not fount</param>
        /// <returns>Ok update and NotFound</returns>
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
        /// <summary>
        /// HttpDelete - method
        /// PlateNumber - URI
        /// Delete plate number
        /// </summary>
        /// <param name="plateNumber">Delete plate number, try return plate number ok and catch exception return not fount</param>
        /// <returns>Ok Delete and NotFound</returns>

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

        /// <summary>
        /// HttpGet - method
        /// "search" URI
        /// Search for a special car by using filter
        /// </summary>
        /// <param name="filter">Setting a search filter there is start and end</param>
        /// <returns>lis count = 0, and not content ok</returns>
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




