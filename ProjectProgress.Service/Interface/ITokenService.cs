using ProjectProgress.Domain;
using ProjectProgress.Domain.DTO.Shared;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProgress.Service.Interface
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);

        Task<RefreshToken> GetTokenAsync(Expression<Func<RefreshToken, bool>> expressions); 
        Task<MutationResult> AddTokenAsync(RefreshToken token);
        Task<MutationResult> UpdateTokenAsync(RefreshToken token);






    }
}
