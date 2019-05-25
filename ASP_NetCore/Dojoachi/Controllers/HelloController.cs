using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Dojodachi.Controllers
{
    public class HelloController : Controller
    {
        public static Dachi dojoachi; // ------- CREATING A DACHI ------- MAKE HER NOW 
        public static Random rnd = new Random(); //  ------- CREATING RANDOM OBJECT --------
        // =========== FOR VIEWS ========
        // ======= ResultText: SHOWS THE STATUS OF YOUR DACHI =====
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if (dojoachi == null) // -- CHECKING FOR dojoachi ---
            {
                dojoachi = new Dachi(); 
                ViewBag.ResultText = "Hello, I'm your dojoachi!"; 
            }
            else // ------- IF dojoachi ALREADY EXITS --------
            {
                ViewBag.ResultText = TempData["ResultText"]; // ------ SHOWING dojoachi ACTIVITY -------
            }
            if (dojoachi.Happy) 
            {
                ViewBag.ResultPic = "/images/happy.png"; // ---- SETTING MY SONIC DACHI HAPPY GIF -----
            }
            else 
            {
                ViewBag.ResultPic = "/images/sad.png"; // ---- SETTING MY SONIC DACHI SAD GIF -----
            }
            if (!dojoachi.Alive && dojoachi.Win) // ---- DISPLAY RESET IF dojoachi ISN'T ALIVE ----
            {
                ViewBag.ResultText = "Congratulations, you won!"; 
            }
            else if (!dojoachi.Alive && !dojoachi.Win) // --- IF dojoachi IS DEAD ---
            {
                ViewBag.ResultPic = "/images/dead.png"; 
                ViewBag.ResultText = "Oh no, your dojoachi has passed away..."; 
            }
            ViewBag.Fullness = dojoachi.Fullness; // -- LISTING ALL dojoachi VALUES --
            ViewBag.Happiness = dojoachi.Happiness;
            ViewBag.Meals = dojoachi.Meals;
            ViewBag.Energy = dojoachi.Energy;
            ViewBag.Alive = dojoachi.Alive;
            
            return View("Index");

        }

        [HttpGet]
        [Route("Feed")]
        public IActionResult Feed()
        {
            if (!dojoachi.Alive) // --- IF DEAD --
            {
                return RedirectToAction("Index"); // --- RETURN TO INDEX --
            }
            if (dojoachi.Meals == 0) // --- IF THERE ISN'T ENOUGH MEALS ---
            {
                TempData["ResultText"] = "Work for more meals! Not enough meals for dojoachi."; 
                return RedirectToAction("Index"); 
            }
            dojoachi.HappyCheck(); // --- CHECK TO SEE dojoachi IS HAPPY ---
            if (dojoachi.Happy) 
            {
                int fill = rnd.Next(5, 11); // -- A NUMBER BETWEEN 5-11 --
                dojoachi.Fullness += fill; // --- ADD THE RANDOM NUMBER FOR FULLNESS --
                TempData["ResultText"] = $"Your dojoachi is full! Fullness +{fill}, Meals -1."; // --- FULLNESS LEVEL/STATUS --
            }
            else 
            {
                TempData["ResultText"] = "You fed your Dachi but he didn't like it...Meals -1."; 
            }
            dojoachi.Meals -= 1; // --- DECREASE MEAL BY 1 --
            dojoachi.DeathCheck(); // -- DEATH CHECK --
            return RedirectToAction("Index"); 
        }

        [HttpGet]
        [Route("Play")]
        public IActionResult Play()
        {
            if (!dojoachi.Alive) 
            {
                return RedirectToAction("Index");
            }
            if (dojoachi.Energy == 0) 
            {
                TempData["ResultText"] = "Your dojoachi needs more sleep in order to play!"; 
                return RedirectToAction("Index"); 
            }
            dojoachi.HappyCheck();
            if (dojoachi.Happy) 
            {
                int fill = rnd.Next(5, 11); 
                dojoachi.Happiness += fill; // -- ADD NUMBER TO HAPPINESS --
                TempData["ResultText"] = $"YAY! Your dojoachi is happy! Happiness +{fill}, Energy -5."; 
            }
            else 
            {
                TempData["ResultText"] = "Whoa! What happen?! Your dojoachi doesn't like this!"; // -- dojoachi LIKES TO PLAY BUT NOT HAPPY --
            }
            dojoachi.Energy -= 5; // --- DECREASE BY 5 ENERGY --
            dojoachi.DeathCheck(); 
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Work")]
        public IActionResult Work()
        {
            if (!dojoachi.Alive)
            {
                return RedirectToAction("Index"); 
            }
            if (dojoachi.Energy == 0)
            {
                TempData["ResultText"] = "Your dojoachi needs sleep in order to work!"; 
                return RedirectToAction("Index"); 
            }
            int fill = rnd.Next(1, 4);
            dojoachi.Meals += fill; 
            TempData["ResultText"] = $"Your Dachi worked! Meals +{fill}, Energy -5."; 
            dojoachi.Energy -= 5; 
            dojoachi.Happy = true; // --- SETTING DACHI TO HAPPINESS --
            dojoachi.DeathCheck();
            return RedirectToAction("Index"); 
        }

        [HttpGet]
        [Route("Sleep")]
        public IActionResult Sleep()
        {
            if (!dojoachi.Alive) 
            {
                return RedirectToAction("Index"); 
            }
            dojoachi.Energy += 15; // -- INCREASE ENERGY BY 15 --
            dojoachi.Fullness -= 5; // -- DECREASE ENERGY BY 5 --
            dojoachi.Happiness -= 5; //-- DECREASE ENERGY BY 5 --
            TempData["ResultText"] = "YAY! Your dojoachi slept! Energy +15, Happiness -5, Fullness -5."; 
            dojoachi.DeathCheck(); 
            dojoachi.Happy = true; 
            return RedirectToAction("Index"); 
        }

        [HttpGet]
        [Route("Reset")]
        public IActionResult Reset()
        {
            dojoachi = null; // --- RESETTING dojoachi: SETTING dojoachi TO NULL (RUN THE FIRST INDEX TO CREATE NEW DACI) ---
            return RedirectToAction("Index"); 
        }
    // } 


        public class Dachi
        {
            public static Random rnd = new Random(); // --- CREATE RANDOM OBJECTS ---
            public int Fullness, // --- ALL dojoachiS FEELINGS -- (ATTRIBUTES)
            Happiness,
            Meals,
            Energy;
            public bool Alive,
            Happy,
            Win;
            public Dachi()
            {
                Fullness = 20; // "Your Dojodachi should start with 20 happiness, 20 fullness, 50 energy, and 3 meals."
                Happiness = 20;
                Meals = 3;
                Energy = 50;
                Alive = true;
                Happy = true;
                Win = false;
            }
            public void DeathCheck()
            {
                if (Fullness <= 0 || Happiness <= 0) // HOW TO INDICATE WHETHER dojoachi IS ALIVE: HAPPINESS OR FULLNESS LESS THAN 0
                {
                    Alive = false; // SET TO FALSE
                }
                else if (Energy >= 100 && Fullness >= 100 && Happiness >= 100) 
                {
                    Alive = false; //set alive to false (unhides restart button and hides other buttons)??
                    Win = true; 
                }
            }
            public void HappyCheck()
            {
                int num = rnd.Next(1, 5); 
                if (num == 2) 
                {
                    Happy = false; 
                }
                else 
                {
                    Happy = true; 
                }
            }
        }

    }
}