using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VM.Main.Web.Models;

namespace VM.Main.Web.Controllers
{
    public class FaceRecognitionController : Controller
    {
        // GET: FaceRecognition
        public ActionResult Index()
        {
            var fakeFace = new List<FaceRecoViewModel>
            {
                new FaceRecoViewModel
                {
                    Id = new Guid(),
                    Author = "Ed",
                    QuestionTitle = "Boring Dude",
                    CopyrightDisclaimer = "1020",
                    LastModified = new DateTime(2011, 03, 03)
                }, 
                new FaceRecoViewModel
                {
                    Id = new Guid(),
                    Author = "DEad",
                    QuestionTitle = "Boring Dude Part 2",
                    CopyrightDisclaimer = "1021",
                    LastModified = new DateTime(2011, 03, 03)
                }
            };
            return View(fakeFace);
        }
    }
}