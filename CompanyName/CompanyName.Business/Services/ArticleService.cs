using CompanyName.Business.Interfaces;
using CompanyName.Domain.Dto;
using CompanyName.Entities.Entities;
using CompanyName.Repository.Extensions;
using CompanyName.Repository.Generic;
using CompanyName.Repository.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace CompanyName.Business.Services
{
    public class ArticleService : IArticleService
    {
        #region Ctor
        private readonly IRepository<Article> _articleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork,
            IRepository<Article> articleRepository)
        {
            _articleRepository = articleRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion

        public IEnumerable<ArticleListDto> GetArticleList()
        {
            IEnumerable<ArticleListDto> data = _articleRepository.GetList(null, x => x.Include(s => s.CreatedUser).ThenInclude(t => t.UserDetail))
               .Select(p => new ArticleListDto
               {
                   ArticleId = p.Id,
                   ArticleTitle = p.ArticleTitle,
                   Text = p.Text
               }).ToList();
            return data;
        }
    }
}
