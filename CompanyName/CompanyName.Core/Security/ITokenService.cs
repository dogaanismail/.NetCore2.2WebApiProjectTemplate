using CompanyName.Domain.Api;
using CompanyName.Domain.Dto;
using System.Collections.Generic;
using System.Security.Claims;

namespace CompanyName.Core.Security
{
    public interface ITokenService
    {
        TokenApiResponse GenerateToken(AppUserDto appUserDto);

        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
    }
}
