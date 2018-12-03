using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RandomPassword.Models;
using Microsoft.AspNetCore.Http;

namespace RandomPassword.Controllers
{
  public class HomeController : Controller
    {
        public string FindRandomPassword()
        {
        Random Rand = new Random();    
        string RandomPassword = "";
        string[] CharArray = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        for (int i = 0; i < 15; i++)
            {
                
                
                int RandomIntForArray = Rand.Next(0, CharArray.Length - 1);
                string RandomLetter = CharArray[RandomIntForArray];
                RandomPassword += RandomLetter;

                
            }
            return RandomPassword;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            
            HttpContext.Session.SetString("RandomPassword", FindRandomPassword());
            string RandomPassword = HttpContext.Session.GetString("RandomPassword");
            int? NumGeneratedPasswords = HttpContext.Session.GetInt32("NumPasswordsGenerated");
            System.Console.WriteLine("******{0}******", NumGeneratedPasswords);
            if(NumGeneratedPasswords == null)
            {
                HttpContext.Session.SetInt32("NumPasswordsGenerated", 0);
                NumGeneratedPasswords = HttpContext.Session.GetInt32("NumPasswordsGenerated");
                System.Console.WriteLine("******2222{0}2222******", NumGeneratedPasswords);
                
            }
            
            
            NumGeneratedPasswords ++;
            HttpContext.Session.SetInt32("NumPasswordsGenerated", (int)NumGeneratedPasswords);
            System.Console.WriteLine("******3333{0}3333******", NumGeneratedPasswords);
            ViewBag.NumGeneratedPasswords = NumGeneratedPasswords;
            ViewBag.RandomPassword = RandomPassword;
        

            return View();
        }

        [HttpGet]
        [Route("/Generate")]

        public JsonResult Generate()
        {
            HttpContext.Session.SetString("RandomPassword", FindRandomPassword());
            string RandomPassword = HttpContext.Session.GetString("RandomPassword");
            int? NumGeneratedPasswords = HttpContext.Session.GetInt32("NumPasswordsGenerated");
            NumGeneratedPasswords++;
            HttpContext.Session.SetInt32("NumPasswordsGenerated", (int)NumGeneratedPasswords);

            var response = new
            {
                randomPassword = RandomPassword,
                numGeneratedPasswords = NumGeneratedPasswords,
            };

            return Json(response);
        }


    }
}
