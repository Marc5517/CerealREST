using CerealREST.DBUtil;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CerealREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CerealImagesController : ControllerBase
    {
        //// GET: api/<CerealImagesController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<CerealImagesController>/5
        [HttpGet]
        [Route("{imgId}")]
        public IActionResult Get(int imgId)
        {
            ManageCerealImage mci = new ManageCerealImage();
            if (mci.GetById(imgId).ImgId > 0)
            {
                return File(mci.GetById(imgId).ImgData, "image/jpeg");
            }
            return null;
        }


        //// POST api/<CerealImagesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<CerealImagesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CerealImagesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
