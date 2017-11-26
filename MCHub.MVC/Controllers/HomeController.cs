﻿
using MCHub.Data.Model;
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

            var list = repo.GetIMediaItems();

            List<MediaItem> files = context.MediaItems.ToList();

            return View(files);
        }
    }
}