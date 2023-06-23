using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Repository.AccountRepo;
using MVCProject.ViewModel;
using System.Security.Claims;

namespace MVCProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public IActionResult Login(AccountViewModel acc)
        {
            if(ModelState.IsValid)
            {
                if(acc.LoginType==LoginType.Employee.ToString())
                {
                    return RedirectToAction(nameof(LoginAsEmployee), 
                        new { email = acc.Email, password = acc.Password });
                }
                else if(acc.LoginType == LoginType.Employee.ToString())
                {
                    return RedirectToAction(nameof(LoginAsTrader),
                        new { email = acc.Email, password = acc.Password });
                }
                else
                {
                    return RedirectToAction(nameof(LoginAsRepresentative),
                        new { email = acc.Email, password = acc.Password });
                }
            }
            return View(acc);
        }
        public IActionResult LoginAsEmployee(string email, string password)
        {

                var employee = accountRepository.FindEmployee(email, password);
                if (employee == null)
                    return View("Login");

                ClaimsIdentity claims = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                claims.AddClaim(new Claim("Id", employee.Id.ToString()));
                claims.AddClaim(new Claim(ClaimTypes.Name, employee.Name));
                claims.AddClaim(new Claim(ClaimTypes.Email, employee.Email));
                claims.AddClaim(new Claim(ClaimTypes.Role, employee.Role));

                ClaimsPrincipal principal = new ClaimsPrincipal(claims);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Employee");

        }
        public IActionResult LoginAsTrader(string email, string password)
        {
            
                var trader = accountRepository.FindTrader(email, password);
                if (trader == null)
                    return View("Login");

                ClaimsIdentity claims = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                claims.AddClaim(new Claim("Id", trader.Id.ToString()));
                claims.AddClaim(new Claim(ClaimTypes.Name, trader.Name));
                claims.AddClaim(new Claim(ClaimTypes.Email, trader.Email));
                claims.AddClaim(new Claim(ClaimTypes.Role, trader.Role));

                ClaimsPrincipal principal = new ClaimsPrincipal(claims);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Trader");
            
        }
        public IActionResult LoginAsRepresentative(string email, string password)
        {
           
                var rerpresentative = accountRepository.FindRepresentative(email, password);
                if (rerpresentative == null)
                    return View("Login");

                ClaimsIdentity claims = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                claims.AddClaim(new Claim("Id", rerpresentative.Id.ToString()));
                claims.AddClaim(new Claim(ClaimTypes.Name, rerpresentative.Name));
                claims.AddClaim(new Claim(ClaimTypes.Email, rerpresentative.Email));
                claims.AddClaim(new Claim(ClaimTypes.Role, rerpresentative.Role));

                ClaimsPrincipal principal = new ClaimsPrincipal(claims);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Representative");

          
        }

        public IActionResult Signout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("index", "Home");
        }
    }
}
