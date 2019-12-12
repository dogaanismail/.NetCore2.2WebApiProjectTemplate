using System;
using System.Linq;
using System.Threading.Tasks;
using CompanyName.Core.Security;
using CompanyName.Domain.Api;
using CompanyName.Domain.Common;
using CompanyName.Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CompanyName.Api.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        #region Ctor
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(ITokenService tokenService, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        #endregion

        /// <summary>
        /// Member Login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<JsonResult> Login([FromBody] LoginApiRequest model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            var user = _userManager.FindByNameAsync(model.Username);
            if (result.Succeeded && user != null)
            {

                var token = _tokenService.GenerateToken(new Domain.Dto.AppUserDto
                {
                    AppUserId = user.Result.Id,
                    UserName = user.Result.UserName
                });

                return OkResponse(token);
            }

            return BadResponse(ResultModel.Error("Username or password are wrong !"));
        }

        /// <summary>
        /// Member Register
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<JsonResult> Register([FromBody] RegisterApiRequest model)
        {
            AppUser userEntity = new AppUser
            {
                UserName = model.UserName,
                Email = model.Email,
                CreatedDate = DateTime.Now
            };
            IdentityResult result = await _userManager.CreateAsync(userEntity, model.Password);

            if (!result.Succeeded)
            {
                Result.Status = false;
                Result.Message = string.Join(",", result.Errors.Select(x => x.Description));
            }

            return OkResponse(Result);
        }
    }
}