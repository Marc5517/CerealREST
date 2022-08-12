using CerealREST.DBUtil;
using CerealREST.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CerealREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CerealsController : ControllerBase
    {
        private static readonly List<Cereal> Cereals = new List<Cereal>()
        {
            new Cereal(1, "Count Chocula", "N", "C", 121, 2, 3, 111, 3, 11, 13, 230, 0, 2, 3, 5, 4, "https://www.innit.com/public/products/images/00043000180327-vnixRi8UOOMAoo4-en-US-0_s500.jpg"),
            new Cereal(2, "Frankenberry", "K", "C", 141, 1, 4, 151, 2, 15, 3, 235, 0, 2, 3, 2, 3, ""),
            new Cereal(3, "Frosted Flakes", "N", "F", 121, 3, 7, 121, 3, 11, 13, 330, 0, 2, 3, 5, 5, ""),
            new Cereal(4, "Almond Delight", "R", "C", 110, 2, 2, 200, 1, 14, 8, -1, 25, 3, 1, 1, 3, ""),
            new Cereal(5, "Apple Cinnamon Cheerios", "G", "C", 110, 2, 2, 180, 2, 11, 10, 70, 25, 1, 1, 1, 3, ""),
            new Cereal(6, "Apple Jacks", "K", "C", 110, 2, 0, 125, 1, 11, 14, 30, 25, 2, 1, 1, 4, "")
        };

        // GET: api/<CerealsController>
        [HttpGet]
        public IEnumerable<Cereal> Get()
        {
            //return Cereals;
            ManageCereal mc = new ManageCereal();
            return mc.Get();
        }

        // GET api/<CerealsController>/5
        [HttpGet]
        [Route("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)] // http response statuscode
        [ProducesResponseType(StatusCodes.Status404NotFound)] // http response statuscode
        //public Cereal GetById(int id)
        public IActionResult GetById(int id)
        {
            ManageCereal mc = new ManageCereal();
            if (mc.GetById(id).Id > 0)
            {
                return Ok(mc.GetById(id));
            }
            return NotFound($"Cereal id {id} not found, meaning the object doesn't exist.");
            
            //try
            //{
            //    return Ok(mc.GetById(id));
            //}
            //catch (KeyNotFoundException knfe)
            //{
            //    return NotFound(knfe.Message);
            //}
        }

        // GET api/<CerealsController>/calories/120
        [HttpGet]
        [Route("calories/{calories}")]
        public IEnumerable<Cereal> GetByCalories(int calories)
        {
            //List<Cereal> lCereals = Cereals.FindAll(c => c.Calories == calories);
            //return lCereals;
            ManageCereal mc = new ManageCereal();
            return mc.GetByCalories(calories);
        }

        // GET api/<CerealsController>/type/D
        [HttpGet]
        [Route("type/{type}")]
        public IEnumerable<Cereal> GetByType(string type)
        {
            //List<Cereal> lCereals = Cereals.FindAll(c => c.Type == type);
            //return lCereals;
            ManageCereal mc = new ManageCereal();
            return mc.GetByType(type);
        }

        [HttpGet]
        [Route("sugars/{sugars}/fat/{fat}")]
        public IEnumerable<Cereal> GetBySugarsAndFat(int sugars, int fat)
        {
            ManageCereal mc = new ManageCereal();
            return mc.GetBySugarsAndFat(sugars, fat);
        }

        //// POST api/<CerealsController>
        //[HttpPost]
        //[Route("username/{username}/password/{password}")]
        //public IActionResult Post([FromBody] Cereal value, string username, int password)
        //{
        //    ManageCereal mc = new ManageCereal();
        //    //mc.Add(value);
        //    if (username == "Marc" && password == 1234)
        //    {
        //        mc.Add(value);
        //        return Ok(value);
        //    }
        //    else
        //    {
        //        return NotFound("Wrong password or username");
        //    }
        //}

        // POST api/<CerealsController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] Cereal value)
        {
            ManageCereal mc = new ManageCereal();
            mc.Add(value);
            
            return Ok(value);
            
        }

        // PUT api/<CerealsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<CerealsController>/5
        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            ManageCereal mc = new ManageCereal();
            try
            {
                return Ok(mc.DeleteCereal(id));
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
        }
    }
}
