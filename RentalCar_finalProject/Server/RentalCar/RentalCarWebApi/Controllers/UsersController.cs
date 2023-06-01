using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using RentalCarWebApi.DTO;
using RentalCarWebApi.Utils;

namespace RentalCarWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        TokensManager _TokensManager;
        RentalCarDbContext _RentalCarDbContext;

        public UsersController(TokensManager tokensManager, RentalCarDbContext rentalCarDbContext)
        {
            _TokensManager = tokensManager;
            _RentalCarDbContext = rentalCarDbContext;
        }

        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            var userInDb = _RentalCarDbContext.Users.FirstOrDefault(u => u.UserName == user.UserName);
            if (userInDb == null)
                return Unauthorized("invalid user name or password");
            else
            {
                var ph = new PasswordHasher<User>();
                var result = ph.VerifyHashedPassword(userInDb, userInDb.Password, user.Password);
                if (userInDb == null || result == PasswordVerificationResult.Failed)
                    return Unauthorized("invalid user name or password");
                else
                {
                    LoginResponse lr = new LoginResponse()
                    {
                        TokensData = GetNewTokensAndSave2DB(userInDb),
                        UserResponse = new UserResponse(userInDb)
                    };
                    return Ok(lr);
                }
            }
        }


        TokensData GetNewTokensAndSave2DB(User user)
        {
            TokensData td = _TokensManager.GetInitializedTokens(user);
            //SaveCookiesToResponse(td);
            SaveRefreshToken2DB(user, td);
            return td;
        }

        void SaveRefreshToken2DB(User userInDb, TokensData td)
        {
            userInDb.RefreshToken = td.RefreshToken;
            userInDb.RefreshTokenExpires = td.RefreshTokenExpires;
            _RentalCarDbContext.SaveChanges();
        }
    }
}
