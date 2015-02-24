using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemo.Models;

namespace MvcDemo.Controllers
{ 
    public class TestController : Controller
    {
        private TestingContext db = new TestingContext();

        //
        // GET: /Test/

        public ViewResult Index()
        {
            return View(db.TestDBs.ToList());
        }

        //
        // GET: /Test/Details/5

        public ViewResult Details(int id)
        {
            TestDB testdb = db.TestDBs.Find(id);
            return View(testdb);
        }

        //
        // GET: /Test/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Test/Create

        [HttpPost]
        public ActionResult Create(TestDB testdb)
        {
            if (ModelState.IsValid)
            {
                db.TestDBs.Add(testdb);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(testdb);
        }
        
        //
        // GET: /Test/Edit/5
 
        public ActionResult Edit(int id)
        {
            TestDB testdb = db.TestDBs.Find(id);
            return View(testdb);
        }

        //
        // POST: /Test/Edit/5

        [HttpPost]
        public ActionResult Edit(TestDB testdb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testdb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testdb);
        }

        //
        // GET: /Test/Delete/5
 
        public ActionResult Delete(int id)
        {
            TestDB testdb = db.TestDBs.Find(id);
            return View(testdb);
        }

        //
        // POST: /Test/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            TestDB testdb = db.TestDBs.Find(id);
            db.TestDBs.Remove(testdb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}