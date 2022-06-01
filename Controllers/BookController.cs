using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestAPIWithSwagger.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        /// <summary>
        /// گرفتن مشخصات کتاب جدید
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// ثبت کتاب جدید
        /// </summary>
        /// <remarks>
        /// نمونه مشخصات کتاب:
        ///
        ///     POST
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <response code="200">برگردوندن مشخصات کتاب</response>
        /// <response code="400">داه های ورودی را چک کنید</response>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

    }
}
