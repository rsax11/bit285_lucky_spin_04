using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LuckySpin.Models;

namespace LuckySpin.Controllers
{
    public class SpinnerController : Controller
    {
        Random random = new Random(); //For use in the SpinIt Action
        /***
         * Entry Page Action
         **/
        [HttpGet]
        public IActionResult Index()
        {
                return View(); //Returns the empty Index.cshtml form
        }
        [HttpPost]
        public IActionResult Index(int luck)
        { //TODO: Prepare Index action to receive a Player object instead of an integer

            //TODO: Pass the Player object to SpinIt using RedirectToAction("SpinIt", object)
            return RedirectToAction("SpinIt");
        }

        /***
         * Spin Action
         **/  
        [HttpGet]
        public IActionResult SpinIt(int luck = 3) //TODO: Prepare this method to receive a Player
        {
            //Load up a Spin object with data
            Spin spin = new Spin();
            spin.Luck = luck; //TODO: Edit this to assign Player's lucky number to spin.Luck
            spin.A = random.Next(1, 10);
            spin.B = random.Next(1, 10);
            spin.C = random.Next(1, 10);

            // Test to see if a winner
            if (spin.A == spin.Luck || spin.B == spin.Luck || spin.C == spin.Luck)
                spin.Display = "block";
            else
                spin.Display = "none";

            //Send the spin object to the View
            return View(spin);
        }
    }
}

