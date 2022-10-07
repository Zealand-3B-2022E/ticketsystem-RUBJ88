using System.Collections;
using CarLbrary;
using MCLibrary;
using Microsoft.AspNetCore.Mvc;
using RESTServiceStorebealtsbroen.Model;
using RESTServiceStorebealtsbroen.StorebealtsbroenManager;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTServiceStorebealtsbroen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MCs : ControllerBase
    {

        private IMC mc = new MCManager();


        // GET: api/<MCs>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]


        public IActionResult Get()
        {
            String rangeValue = Request.Headers["Range"];
            if (rangeValue == null)
            {
                List<MC> list = mc.Get();
                return (list.Count == 0) ? NoContent() : Ok(list);
            }

            String[] values = rangeValue.Split("-");
            int lowIx = int.Parse(values[0]);
            int highIx = int.Parse(values[1]);


            IEnumerable<MC> list2 = mc.GetRange(lowIx, highIx);

            Response.Headers.Add("Content-Range", $"{lowIx}-{highIx}/*");

            return Ok(list2);
        }


        // GET api/<MCs>/5

        [HttpGet]
        [Route("{Licensplate}")] // URI
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]


        public IActionResult Get(string platenumber)
        {
            try
            {
                MC animal = mc.Get(platenumber);
                return Ok(platenumber);
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
        }


        // GET api/<MCs>
        [HttpGet]
        [Route("licensplate/{licensplate}")] // URI
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetPlate(String plateNumber)
        {
            MC ms = mc.Get(plateNumber);

            return (plateNumber.Length > 0) ? Ok(ms) : NoContent();
        }




        // POST api/<MCs>/5

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult Post([FromBody] MC plateNumber)
        {
            try
            {
                MC newPlates = mc.Create(plateNumber);
                String uri = "api/Platelicens/" + plateNumber.Licensplate;
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
        public IActionResult Put(string platenumber, [FromBody] MC licensplate)
        {
            try
            {
                return Ok(mc.Update(platenumber, licensplate));
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }

        }


        // DELETE api/<MCs>/5
        [HttpDelete]
        [Route("{PlateNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]


        public IActionResult Delete(string plateNumber)
        {
            try
            {
                return Ok(mc.Delete(plateNumber));
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

            List<MC> liste = mc.SearchDate(filter.Start, filter.End);
            return (liste.Count == 0) ? NoContent() : Ok(liste);


        }
    }
}
