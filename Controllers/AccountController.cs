using Microsoft.AspNetCore.Mvc;
using LoginDemoCore.Models;

namespace LoginDemoCore.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Username) || string.IsNullOrWhiteSpace(model.Password))
            {
                ViewBag.Message = "Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu";
                return View(model);
            }

            if (model.Username == "admin" && model.Password == "123")
            {
                ViewBag.Message = "Login success";
            }
            else
            {
                ViewBag.Message = "Login failed";
            }

            return View(model);
        }
    }
}
