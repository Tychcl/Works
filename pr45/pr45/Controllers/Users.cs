using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace pr45.Controllers
{
    [Route("api/UserController")]
    [ApiExplorerSettings(GroupName = "v2")]
    public class UsersCont : Controller
    {
        private const int SaltSize = 16; // 128 бит
        private const int KeySize = 32; // 256 бит
        private const int Iterations = 10000;
        public string token = "";
        Models.Context _context;
        public UsersCont(Models.Context context)
        {
            _context = context;
        }

        [Route("SignIn")]
        [HttpPost]
        public async Task<IActionResult> SignIn(string Login, string Password)
        {
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
                return BadRequest("Invalid input");

            if (_context.Users.FirstOrDefault(u => u.Login == Login) is Models.Users user
                && VerifyPassword(Password, user.Password))
            {
                var token = user.Token;

                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddDays(1)
                };

                Response.Cookies.Append("AuthToken", token, cookieOptions);

                return Ok(new { Message = "Authentication successful" });
            }
            return Unauthorized();
        }

        [Route("RegIn")]
        [HttpPost]
        public async Task<IActionResult> RegIn(string Login, string Password)
        {
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
                return BadRequest("Invalid input");

            if (await _context.Users.AnyAsync(u => u.Login == Login))
                return Conflict("Username taken");

            var tokenBytes = RandomNumberGenerator.GetBytes(32);
            string token = Convert.ToBase64String(tokenBytes);

            var newUser = new Models.Users
            {
                Login = Login,
                Password = HashPassword(Password),
                Token = token
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok(new { Token = token }); // Return token only
        }
        public static string HashPassword(string password)
        {
            using var algorithm = new Rfc2898DeriveBytes(
                password,
                SaltSize,
                Iterations,
            HashAlgorithmName.SHA256);

            var key = Convert.ToBase64String(algorithm.GetBytes(KeySize));
            var salt = Convert.ToBase64String(algorithm.Salt);

            return $"{Iterations}.{salt}.{key}";
        }
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            var parts = hashedPassword.Split('.', 3);

            if (parts.Length != 3)
            {
                throw new FormatException("Unexpected hash format.");
            }

            var iterations = Convert.ToInt32(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);
            var key = Convert.FromBase64String(parts[2]);

            using var algorithm = new Rfc2898DeriveBytes(
                password,
                salt,
                iterations,
            HashAlgorithmName.SHA256);

            var keyToCheck = algorithm.GetBytes(KeySize);

            return keyToCheck.SequenceEqual(key);
        }
    }
}
