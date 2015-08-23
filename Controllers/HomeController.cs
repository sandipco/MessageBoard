﻿using MessageBoard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MessageBoard.Controllers
{
    public class HomeController : Controller
    {
        private IMessageBoardRepository _repo;
        public HomeController(IMessageBoardRepository repo)
        {
            _repo = repo;
        }
        public ActionResult Index()
        {
            var topics = _repo.GetTopics().OrderByDescending(t => t.Created).Take(25).ToList();
            return View(topics);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            var msg = string.Format("Comment From:{1}{0}Email:{2}{0}Website:{3}{0}Comment:{4}{0}", Environment.NewLine,
                model.Name, model.Email, model.Website, model.Comment);

            
            return View();
        }

        public ActionResult MyMessages()
        {
            return View();
        }
    }
}