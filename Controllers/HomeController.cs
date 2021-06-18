using AzureWebApplication.Data;
using AzureWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Crypto.Generators;
using System.Text;
using System.Data.Entity;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using SqlConnection = Microsoft.Data.SqlClient.SqlConnection;
using SqlDataAdapter = Microsoft.Data.SqlClient.SqlDataAdapter;
using System.Data;

namespace AzureWebApplication.Controllers
{

    public class HomeController : Controller
    {
       private readonly ILogger<HomeController> logger;

        private LoginContext db = null;
        public HomeController(LoginContext db, ILogger<HomeController> logger)
        {
            this.db = db;
            this.logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ChangePW_Page()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Login(string id, string password)
        {
            var account = checkAccount(id, password);
            if (account == null)
            {
                ViewBag.error = "Login Failed: Invaild Password(ID: admin)";
                return View("Index");
            }
            else
            {
                HttpContext.Session.SetString("id", id);
                return Redirect("/manageproduct_table/Manage");
            }            
        }
        private admintable checkAccount(string id, string password)
        {
            var account = db.admintable.SingleOrDefault(a => a.Id.Equals(id));
            if (account != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, account.password))
                {
                    return account;
                }
            }
            return null;
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("id");
            return RedirectToAction("Index");
        }

        public IActionResult Signup_Page()
        {
            return View();
        }

        public IActionResult Signup(admintable account)
        {
            if (account.Id == null)
            {
                account.Id = "admin";
                account.password = BCrypt.Net.BCrypt.HashPassword(account.password);
                db.admintable.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }


        public IActionResult ChangePassword(admintable account)
        {
            account.Id = "admin";
            account.password = BCrypt.Net.BCrypt.HashPassword(account.password);
            db.admintable.Update(account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
      
    }
}
