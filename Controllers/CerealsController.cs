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
            //new Cereal(1, "Count Chocula", "N", "C", 121, 2, 3, 111, 3, 11, 13, 230, 0, 2, 3, 5, 4, ),
            //new Cereal(2, "Frankenberry", "K", "C", 141, 1, 4, 151, 2, 15, 3, 235, 0, 2, 3, 2, 3, ),
            //new Cereal(3, "Frosted Flakes", "N", "F", 121, 3, 7, 121, 3, 11, 13, 330, 0, 2, 3, 5, 5, ),
            //new Cereal(4, "Almond Delight", "R", "C", 110, 2, 2, 200, 1, 14, 8, -1, 25, 3, 1, 1, 3, ),
            //new Cereal(5, "Apple Cinnamon Cheerios", "G", "C", 110, 2, 2, 180, 2, 11, 10, 70, 25, 1, 1, 1, 3, ""),
            //new Cereal(6, "Apple Jacks", "K", "C", 110, 2, 0, 125, 1, 11, 14, 30, 25, 2, 1, 1, 4, "")
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
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)] // http response statuscode
        [ProducesResponseType(StatusCodes.Status404NotFound)] // http response statuscode
        public IActionResult GetById(int id)
        {
            ManageCereal mc = new ManageCereal();
            if (mc.GetById(id).Id > 0)
            {
                return Ok(mc.GetById(id));
            }
            return NotFound($"Cereal id {id} not found, meaning the object doesn't exist.");
        }

        [HttpGet]
        [Route("{category}/{cate}")]
        public IEnumerable<Cereal> GetByCategory(string category, string cate)
        {
            ManageCereal mc = new ManageCereal();
            return mc.GetByCategory(category, cate);
        }

        [HttpGet]
        [Route("{category2}/{sort}/{cate2}")]
        public IEnumerable<Cereal> GetBySortingCategory(string category2, string sort, int cate2)
        {
            ManageCereal mc = new ManageCereal();
            return mc.GetBySortingCategory(category2, sort, cate2);
        }

        [HttpGet]
        [Route("Category/Result")]
        public IEnumerable<Cereal> GetByCategory(int? caloriesLT, string? type, int? fatGT)
        {
            ManageCereal mc = new ManageCereal();
            return mc.GetBySort(caloriesLT, type, fatGT);
        }

        //[HttpGet]
        //[Route("Sorting/Result")]
        //public IEnumerable<Cereal> GetBySortingCategory(string? sortby, string? name, string? mfr, string? type, int? calories, int? caloriesgt, int? calorieslt, int? caloriesgte, int? calorieslte, int? caloriesNot,
        //    int? protein, int? proteingt, int? proteinlt, int? proteingte, int? proteinlte, int? proteinNot, int? fat, int? fatgt, int? fatlt, int? fatgte, int? fatlte, int? fatNot,
        //    int? sodium, int? sodiumgt, int? sodiumlt, int? sodiumgte, int? sodiumlte, int? sodiumNot, double? fiber, double? fibergt, double? fiberlt, double? fibergte, double? fiberlte, double? fiberNot,
        //    double? carbo, double? carbogt, double? carbolt, double? carbogte, double? carbolte, double? carboNot, int? sugars, int? sugarsgt, int? sugarslt, int? sugarsgte, int? sugarslte, int? sugarsNot,
        //    int? potass, int? potassgt, int? potasslt, int? potassgte, int? potasslte, int? potassNot, int? vitamins, int? vitaminsgt, int? vitaminslt, int? vitaminsgte, int? vitaminslte, int? vitaminsNot,
        //    int? shelf, int? shelfgt, int? shelflt, int? shelfgte, int? shelflte, int? shelfNot, double? weight, double? weightgt, double? weightlt, double? weightgte, double? weightlte, double? weightNot,
        //    double? cups, double? cupsgt, double? cupslt, double? cupsgte, double? cupslte, double? cupsNot, double? rating, double? ratinggt, double? ratinglt, double? ratinggte, double? ratinglte, double? ratingNot)
        //{
        //    var result = new CerealFilter
        //    {
        //        Name = name,
        //        Mfr = mfr,
        //        Type = type,
        //        Calories = calories,
        //        CaloriesGT = caloriesgt,
        //        CaloriesLT = calorieslt,
        //        CaloriesGTE = caloriesgte,
        //        CaloriesLTE = calorieslte,
        //        CaloriesNot = caloriesNot,
        //        Protein = protein,
        //        ProteinGT = proteingt,
        //        ProteinLT = proteinlt,
        //        ProteinGTE = proteingte,
        //        ProteinLTE = proteinlte,
        //        ProteinNot = proteinNot,
        //        Fat = fat,
        //        FatGT = fatgt,
        //        FatLT = fatlt,
        //        FatGTE = fatgte,
        //        FatLTE = fatlte,
        //        FatNot = fatNot,
        //        Sodium = sodium,
        //        SodiumGT = sodiumgt,
        //        SodiumLT = sodiumlt,
        //        SodiumGTE = sodiumgte,
        //        SodiumLTE = sodiumlte,
        //        SodiumNot = sodiumNot,
        //        Fiber = fiber,
        //        FiberGT = fibergt,
        //        FiberLT = fiberlt,
        //        FiberGTE = fibergte,
        //        FiberLTE = fiberlte,
        //        FiberNot = fiberNot,
        //        Carbo = carbo,
        //        CarboGT = carbogt,
        //        CarboLT = carbolt,
        //        CarboGTE = carbogte,
        //        CarboLTE = carbolte,
        //        CarboNot = carboNot,
        //        Sugars = sugars,
        //        SugarsGT = sugarsgt,
        //        SugarsLT = sugarslt,
        //        SugarsGTE = sugarsgte,
        //        SugarsLTE = sugarslte,
        //        SugarsNot = sugarsNot,
        //        Potass = potass,
        //        PotassGT = potassgt,
        //        PotassLT = potasslt,
        //        PotassGTE = potassgte,
        //        PotassLTE = potasslte,
        //        PotassNot = potassNot,
        //        Vitamins = vitamins,
        //        VitaminsGT = vitaminsgt,
        //        VitaminsLT = vitaminslt,
        //        VitaminsGTE = vitaminsgte,
        //        VitaminsLTE = vitaminslte,
        //        VitaminsNot = vitaminsNot,
        //        Shelf = shelf,
        //        ShelfGT = shelfgt,
        //        ShelfLT = shelflt,
        //        ShelfGTE = shelfgte,
        //        ShelfLTE = shelflte,
        //        ShelfNot = shelfNot,
        //        Weight = weight,
        //        WeightGT = weightgt,
        //        WeightLT = weightlt,
        //        WeightGTE = weightgte,
        //        WeightLTE = weightlte,
        //        WeightNot = weightNot,
        //        Cups = cups,
        //        CupsGT = cupsgt,
        //        CupsLT = cupslt,
        //        CupsGTE = cupsgte,
        //        CupsLTE = cupslte,
        //        CupsNot = cupsNot,
        //        Rating = rating,
        //        RatingGT = ratinggt,
        //        RatingLT = ratinglt,
        //        RatingGTE = ratinggte,
        //        RatingLTE = ratinglte,
        //        RatingNot = ratingNot
        //    };

        //    ManageCereal mc = new ManageCereal();
        //    return mc.GetBySorting(result, sortby);
        //}

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
        //        return Unauthoized("Wrong password or username");
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
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Update(int id, [FromBody] Cereal c)
        {
            ManageCereal mc = new ManageCereal();
            try
            {
                mc.UpdateCereal(id, c);
                return Ok();
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
        }

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
