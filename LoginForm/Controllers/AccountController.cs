using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.DirectoryServices.AccountManagement;
using System.Security.Claims;
using System.Web;

namespace LoginForm.Controllers
{
    
    public class AccountController : Controller
    {
       
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDto dto) {
            
            if (IsValidUser(dto.UserName, dto.Password))
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, dto.UserName)
            };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                HttpContext.Session.SetString("Username", dto.UserName);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid UserName Or Password.");
                return View();
            }
              
        }

        private bool IsValidUser(string username, string password)
        {
            using (var context = new PrincipalContext(ContextType.Domain, "RSADF.Com"))
            {
                return context.ValidateCredentials(username, password);
            }
        }


        [HttpGet]
        public ActionResult GetData()
        {
            var username = HttpContext.Session.GetString("Username");
            var user = ActiveDirectoryHelper.GetUserDetails(username);
            if (user != null)
            {
                ViewBag.Username = username;    
                ViewBag.Id = user.Sid;
                ViewBag.FullName = user.DisplayName;
                ViewBag.Email = user.EmailAddress;
                ViewBag.Phone = user.VoiceTelephoneNumber;
            }
            else
            {
                ViewBag.Message = "User not found.";
            }
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
           
             HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

           
            return RedirectToAction("Login", "Account");
        }




    }
}
