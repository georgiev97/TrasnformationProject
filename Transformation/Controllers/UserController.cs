using Data.Entity;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
namespace Transformation.Controllers
{
    public class UserController : BaseController
    {

        private UserRepository userRepository = null;
        private TrainingUserRepository trainingUser = null;

        public UserController()
        {
            userRepository = new UserRepository(Context);
            trainingUser = new TrainingUserRepository(Context);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var isEmailExist = userRepository.IsEmailExist(user.Username);
            var isUsernameExist = userRepository.IsUsernameExist(user.Username);
            var tryLogin = userRepository.GetUser(user);

            if (isEmailExist !=null || isUsernameExist!=null)
            {             
                if (string.Compare(Util.Crypto.Hash(user.Password), tryLogin.Password) == 0)
                {

                    string provided;
                    User userForView;
                    if(user.Email==null)
                    {
                        userForView = userRepository.GetByUsernameAndPassword(user.Username, Util.Crypto.Hash(user.Password));
                        provided = user.Username;
                    }
                    else
                    {
                         userForView = userRepository.GetByEmailAndPassword(user.Email, Util.Crypto.Hash(user.Password));
                        provided = user.Email;
                    }

                    int timeout = user.RememberMe ? 525600 : 20;
                    var ticket = new FormsAuthenticationTicket(provided, user.RememberMe, timeout);
                    string encrypted = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                    cookie.Expires = DateTime.Now.AddMinutes(timeout);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);
                    FormsAuthentication.SetAuthCookie(user.Username, user.RememberMe);
                    return RedirectToAction("TopUsers", "Profile", new { id=userForView.Username});
                }
                else
                {
                    ModelState.AddModelError("Username", "Invalid credential provided");
                    return View();
                }
            }

            ModelState.AddModelError("Username", "Invalid credential provided");
            return View();
        }


        [HttpGet]
        public ActionResult SignUp()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {

            var isEmailExist = userRepository.IsEmailExist(user.Email);
            var isUsernameExist = userRepository.IsEmailExist(user.Username);
            if (isEmailExist !=null && isUsernameExist!=null)
            {
                ModelState.AddModelError("Email", "Email or Username already exist");
                return View(user);
            }

            if (!userRepository.passwordMatches(user.Password, user.ConfirmPassword))
            {
                ModelState.AddModelError("Password", "The two passwords are different!");
            }

            user.Password = Util.Crypto.Hash(user.Password);
            user.ConfirmPassword = Util.Crypto.Hash(user.ConfirmPassword);

            userRepository.Add(user);

            return RedirectToAction("SignUp2", "User");
        }


        [HttpGet]
        public ActionResult SignUp2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp2(TrainingUser user)
        {
            trainingUser.Add(user);
            return RedirectToAction("Login", "User");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }
    }
}