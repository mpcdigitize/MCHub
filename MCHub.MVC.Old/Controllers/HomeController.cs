using MCHub.Data.Model;
using MCHub.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WMCHub.Data;

namespace MCHub.MVC.Controllers
{
    public class HomeController : Controller
    {
        AppContext context = new AppContext();
        
        
        // GET: Home
        public ActionResult Index()
        {
            var repo = new AppRepo();


            var list = repo.GetMetadataItems();

            List<MediaItem> files = context.MediaItems.ToList();

            //var cars = HelloModel.GetCars();

            //ViewBag.PeterCreatedThisValue = "My value";

            return View(files);
        }
    }
}