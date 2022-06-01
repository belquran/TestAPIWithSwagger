using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestAPIWithSwagger.Controllers
{
    //[ApiExplorerSettings(IgnoreApi = true)] //این ایپی ای داخل داکیومنت سواگر قرار نگیرد 
    //[ApiVersion("2")]
    [ApiExplorerSettings(GroupName = "v2")]
    [Produces("application/json")]
    [Route("api/v2/User")]
    [ApiController]
    public class UserV2Controller : ControllerBase
    {
        /// <summary>
        /// توضیحات
        /// </summary>
        /// <returns></returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>  
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "ali 222", "reza 222" };
        }

        /// <summary>
        /// گرفتن مشخصات یک  کاربر
        /// </summary>
        /// <param name="id">ایدی کاربر</param>
        /// <remarks>
        /// نمونه داده ورودی:
        ///
        ///     POST 
        ///     {
        ///        "id": 1
        ///     }
        /// مثال است
        /// </remarks>
        /// <response code="200">با موفقیت انجام شده</response>
        /// <response code="404">این کاربر یافت نشد</response>
        /// <returns>مشخصات یک کاربر</returns>
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "IdV2: " + id;
        }

        /// <summary>
        /// ثبت نام
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <param name="item"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>  
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

    }

    //[ApiVersion("1")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Produces("application/json")]
    [Route("api/v1/User")]
    //[Route("api/v{version:apiVersion}/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Dessssss
        /// </summary>
        /// <returns></returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>  
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "ali", "reza" };
        }

        /// <summary>
        /// گرفتن مشخصات یک  کاربر
        /// </summary>
        /// <param name="id">ایدی کاربر</param>
        /// <remarks>
        /// نمونه داده ورودی:
        ///
        ///     POST 
        ///     {
        ///        "id": 1
        ///     }
        /// مثال است
        /// </remarks>
        /// <response code="200">با موفقیت انجام شده</response>
        /// <response code="404">این کاربر یافت نشد</response>
        /// <returns>مشخصات یک کاربر</returns>
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Id " + id;
        }

        /// <summary>
        /// ثبت نام
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <param name="item"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>  
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

    }



}
