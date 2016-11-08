using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
 
using UraApp.Models;
using UraApp.Services.Abstract;
using UraApp.Utility;

namespace UraApp.Controllers
{
    public class LoginController : Controller
    {

        public readonly IUserService ObjUserService;
        // public readonly ICompanyService CompanyService;


        public LoginController(IUserService objUserService)
        {
            ObjUserService = objUserService;
        }
        
        // GET: Login
        public IActionResult Index()
        {
            return View();
        }
        // GET: Login'
        [HttpPost]
        public IActionResult Index(User user)
        {

            if (HttpContext.Session.GetString("Captcha") == null || HttpContext.Session.GetString("Captcha") != user.Captcha)
            {
                foreach (var modelValue in ModelState.Values)
                {
                    modelValue.Errors.Clear();
                }
                ModelState.AddModelError("Captcha", "Wrong value of sum, please try again.");
                return View(user);
            }

            if (ObjUserService.CheckLogin(user))
            {
                SetLoginSession(user);
                //Need Refractor on this

                //Response.Redirect(FormsAuthentication.DefaultUrl, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Error", "Username or Password didnot match");
                return View();
            }
        }

        private void SetLoginSession(User user)
        {
            var session = new UserSession(user.Id, user.UserName);

            session.SetSession(session);
            int userid = session.GetSession().UserId;
            var claims = new List<Claim>
                {
                    new Claim("sub", user.UserName),
                    new Claim("name", user.Name),
                    new Claim("email", user.EmailId)
                };

            var id = new ClaimsIdentity(claims, "local", "name", "role");
            HttpContext.Authentication.SignInAsync("Cookies", new ClaimsPrincipal(id));

        }

        // GET: Login/Details/5
        public IActionResult Details(long id)
        {

            var user = ObjUserService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Login/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                ObjUserService.Add(user);

                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Login/Edit/5
        public IActionResult Edit(long id)
        {
            var user = ObjUserService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Login/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                ObjUserService.Update(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Login/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(long id)
        {
            var user = ObjUserService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Login/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = ObjUserService.GetById(id);
            ObjUserService.Delete(user);
            return RedirectToAction("Index");
        }
    }
}
