using CompanyName.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyName.Api.Controllers
{
    public class ArticlesController : BaseController
    {
        #region Ctor
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        #endregion

        [HttpGet("articlelist")]
        [AllowAnonymous]
        public JsonResult GetArticleList()
        {
            var data = _articleService.GetArticleList();
            return OkResponse(data);
        }
    }
}
