using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using MvcDemo.Models;

namespace MvcDemo.Controllers
{
    public class QuizController : Controller
    {

        private QuizContext db1 = new QuizContext();
        private TestingContext db = new TestingContext();

        public ActionResult TakeQuiz()
        {
            return View(db.TestDBs.ToList());
        }

        public ViewResult Index()
        {
            return View(db.TestDBs.ToList());
        }

        public ActionResult CreateQuiz()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateQuiz(QuizModel model)
        {
            if (ModelState.IsValid)
            {
                db1.QuizModels.Add(model);
                db1.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            using (var db1 = new QuizContext())
            {
                var blog = new QuizModel { QuestionId = id };
                db1.QuizModels.Add(blog);
                db1.SaveChanges();

                // Display all Blogs from the database 
                var query = from b in db1.QuizModels
                            orderby b.QuestionId
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {

                }
            }
            return View();
        }

    }
}
