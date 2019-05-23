﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyCinema.Models;

namespace MyCinema.Controllers
{
    public class TimetablesController : Controller
    {
        private MyModel db = new MyModel();

        // GET: Timetables
        public ActionResult Index()
        {
            ViewBag.Movies = db.Movies.ToList();
            ViewBag.Rooms = db.Rooms.ToList();
            return View(db.Timetables.ToList());
        }

        // GET: Timetables/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.Movies = db.Movies.ToList();
            ViewBag.Rooms = db.Rooms.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timetable timetable = db.Timetables.Find(id);
            if (timetable == null)
            {
                return HttpNotFound();
            }
            return View(timetable);
        }

        // GET: Timetables/Create
        public ActionResult Create()
        {
            ViewBag.Movies = db.Movies.ToList();
            ViewBag.Rooms = db.Rooms.ToList();
            return View();
        }

        // POST: Timetables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,MovieId,RoomId,Date,StartTime")] Timetable timetable)
        {
            
            if (ModelState.IsValid)
            {
                db.Timetables.Add(timetable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timetable);
        }

        // GET: Timetables/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Movies = db.Movies.ToList();
            ViewBag.Rooms = db.Rooms.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timetable timetable = db.Timetables.Find(id);
            if (timetable == null)
            {
                return HttpNotFound();
            }
            return View(timetable);
        }

        // POST: Timetables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,MovieId,RoomId,Date,StartTime")] Timetable timetable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timetable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timetable);
        }

        // GET: Timetables/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.Movies = db.Movies.ToList();
            ViewBag.Rooms = db.Rooms.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timetable timetable = db.Timetables.Find(id);
            if (timetable == null)
            {
                return HttpNotFound();
            }
            return View(timetable);
        }

        // POST: Timetables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Timetable timetable = db.Timetables.Find(id);
            db.Timetables.Remove(timetable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


       

        public ActionResult DisplayProgram(MyModel model)
        {
            List<int> list_of_Movies_Id= new List<int>();
            foreach(var item in model.Movies)
            {
                list_of_Movies_Id.Add(item.MovieId);
            }
            
            ViewBag.data = list_of_Movies_Id;
            return View();
        }
    }
}
