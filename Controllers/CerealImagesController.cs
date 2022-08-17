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
                Image image = ByteArrayToImage(mci.GetById(imgId).ImgData);
                //return Ok(mci.GetById(imgId));
                return Ok(image);
            }
            return NotFound($"Cereal id {imgId} not found, meaning the object doesn't exist.");
        }

        private Image ByteArrayToImage(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
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
