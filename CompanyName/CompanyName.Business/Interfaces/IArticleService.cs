using CompanyName.Domain.Dto;
using System.Collections.Generic;

namespace CompanyName.Business.Interfaces
{
    public interface IArticleService
    {
        /// <summary>
        /// Returns the article lists
        /// </summary>
        /// <returns></returns>
        IEnumerable<ArticleListDto> GetArticleList();
    }
}
