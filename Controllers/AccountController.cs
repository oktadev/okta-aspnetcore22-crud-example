using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Okta.AspNetCore;

namespace LiveMusicFinder.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
          if(!HttpContext.User.Identity.IsAuthenticated)
          {
            return Challenge(OktaDefaults.MvcAuthenticationScheme);
          }
          return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
          return new SignOutResult(new[]
          {
            OktaDefaults.MvcAuthenticationScheme,
            CookieAuthenticationDefaults.AuthenticationScheme
          });
        }

        public IActionResult PostLogout()
        {
          return RedirectToAction("Index", "Home");
        }
    }
}