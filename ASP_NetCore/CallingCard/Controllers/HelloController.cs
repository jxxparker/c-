using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Calling_Card.Controllers
{
    public class HelloController : Controller
    {

//  ===================== MAIN PAGE ====================
        // A GET method
        [HttpGet]
        [Route("")]
        public string Front()
        {
            return "Jihun's first calling card asp netcore assignment";
        }
//  ===================== ASSIGNMENT ====================
        [HttpGet]
        [Route("jihun/jihun")]
        public JsonResult Ji()
        {
            var AnonObject = new
            {
                FirstName = "jihun",
                LastName = "park",
                Age = "24",
                FavoriteColor = "blue",
            };
            return Json(AnonObject);
        }

// OTHER WAY OF DOING IT... 

        [HttpGet]
        [Route("/{FirstName}/{LastName}/{Age}/{FavColor}")]
        public JsonResult DisplayInt(string FirstName, string LastName, int Age, string FavColor)
        {
            return Json(new { FirstName = FirstName, LastName = LastName, Age = Age, FavoriteColor = FavColor });
        }

//  ===================== END OF ASSIGNMENT ====================


        // [HttpGet]
        // [Route("displayint")]
        // public JsonResult DisplayInt()
        // {
        //     return Json(34);
        // }

        // [HttpGet]
        // [Route("displayhuman")]
        // public JsonResult DisplayHuman()
        // {
        //     return Json(new Human());
        // }

        // [HttpGet]
        // [Route("displayint")]
        // public JsonResult DisplayInt()
        // {
        //     var AnonObject = new
        //     {
        //         FirstName = "Raz",
        //         LastName = "Aquato",
        //         Age = 10
        //     };
        //     return Json(AnonObject);
        // }

        // Other code
        // [HttpGet]
        // [Route("template/{Name}")]
        // public IActionResult Method(string Name)
        // {
        //     // Method body
        // }


        // A POST method
        // [HttpPost]
        // [Route("")]
        // public IActionResult Other()
        // {
        //     // Return a view (We'll learn how soon!)
        // }
    }
}