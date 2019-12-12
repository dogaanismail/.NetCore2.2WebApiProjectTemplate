using CompanyName.Domain.Api;
using CompanyName.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CompanyName.Api.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController : Controller
    {
        public ResultModel Result;

        public BaseController()
        {
            Result = ResultModel.Success();
        }

        protected JsonResult OkResponse<T>(T data) where T : class
        {
            var response = Response<T>.Create(HttpStatusCode.OK, data);

            return Json(response);
        }

        protected JsonResult BadResponse<T>(T data) where T : class
        {
            var response = Response<T>.Create(HttpStatusCode.BadRequest, data);

            return Json(response);
        }
    }
}
