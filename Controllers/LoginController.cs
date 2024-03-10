using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExpenseTracker.Controllers
{
    public class LoginController
    {
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult LogOn(string userName, string passwd, bool rememberMe)
        //{
          
        //    if (!ValidateLogOn(userName, passwd))
        //    {
                
        //    }

        //    //SignIn(userName, rememberMe);

        //    return RedirectToAction("Dashboard", "Index");
        //}

        //private bool ValidateLogOn(string userName,string passwd)
        //{
        //    if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(passwd)) 
        //        return false;

        //    return true;
        //}

        //private void SignIn(string userName, bool createPersistentCookie)
        //{
        //    int timeout = createPersistentCookie ? 43200 : 30; //43200 = 1 month
        //    var ticket = ClaimsPrincipal
        //    string encrypted = FormsAuthentication.Encrypt(ticket);
        //    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
        //    cookie.Expires = System.DateTime.Now.AddMinutes(timeout);
        //    HttpContext.Current.Response.Cookies.Add(cookie);
        //}
    }
}
