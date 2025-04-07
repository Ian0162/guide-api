using AutoMapper;
using GuideAPI.Data.Config;
using GuideAPI.Dto;
using GuideAPI.Models;
using GuideAPI.Repositories.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GuideAPI.Repositories
{
    public class Authentication : IAuthentication
    {
        private readonly UserManager<ApplicationUser> manager;
        private readonly IConfiguration config;
        private readonly IMapper mapper;

        private ApplicationUser user;
        private const string provider = "GuideAPI";
        private const string refreshTkn = "RefreshToken";
        public Authentication(IMapper mapper, UserManager<ApplicationUser> manager, IConfiguration config) {
            this.manager = manager;
            this.config = config; 
            this.mapper = mapper;
        }
        public async Task<AuthResponseDto> Login(AuthRequestDto request)
        {
            user = await manager.FindByEmailAsync(request.Email);
            bool isValid = await manager.CheckPasswordAsync(user, request.Password);

            if(user == null || !isValid)
            {
                return null;
            }

            var token = await GenerateToken();

            return new AuthResponseDto
            {
                Token = token,
                Email = request.Email,
                RefreshToken = await CreateRefreshToken(),
            };
        }

        public async Task<IEnumerable<IdentityError>> Register(AuthRequestDto request)
        {
            user = mapper.Map<ApplicationUser>(request);
            user.UserName = request.Email;
            user.FirstName = "User";
            user.LastName = "User";

            var result = await manager.CreateAsync(user, request.Password);

            Console.WriteLine(result);

            if (result.Succeeded)
            {
                await manager.AddToRoleAsync(user, "User");
            }

            return result.Errors;
        }

        public async Task<string> CreateRefreshToken()
        {
            await manager.RemoveAuthenticationTokenAsync(user, provider, refreshTkn);
            var newRefreshToken = await manager.GenerateUserTokenAsync(user, provider, refreshTkn);
            var result = await manager.SetAuthenticationTokenAsync(user, provider, refreshTkn, newRefreshToken);
            return newRefreshToken;
        }

        public async Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto response)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(response.Token);
            var username = tokenContent.Claims.ToList().FirstOrDefault(q => q.Type == JwtRegisteredClaimNames.Email)?.Value;

            user = await manager.FindByEmailAsync(username);
            
            if(user == null || user.Email != response.Email)
            {
                return null;
            }

            var isValidRefreshToken = await manager.VerifyUserTokenAsync(user, provider, refreshTkn, response.RefreshToken);

            if (isValidRefreshToken)
            {
                var token = await GenerateToken();
                return new AuthResponseDto
                {
                    Token = token,
                    Email = user.Email,
                    RefreshToken = await CreateRefreshToken()
                };
            }

            await manager.UpdateSecurityStampAsync(user);
            return null;

        }

        private async Task<string> GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var role = await manager.GetRolesAsync(user);
            var roleClaims = role.Select(role => new Claim(ClaimTypes.Role, role)).ToList();
            var userClaims = await manager.GetClaimsAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims).Union(roleClaims);

            var token = new JwtSecurityToken(
                issuer: config["JwtSettings:Issuer"],
                audience: config["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(config["JwtSettings:DurationInMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
            
        } 
    }
}
