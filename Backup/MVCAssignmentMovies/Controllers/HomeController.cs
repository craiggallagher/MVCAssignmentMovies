using MVCAssignmentMovies.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace MVCAssignmentMovies.Controllers
{
    public class HomeController : Controller
    {
        private MoviesDb db = new MoviesDb();
        //
        // GET: /Home/

        public ActionResult Index(string sortOrder,int ?id)
        {


            if (sortOrder == null) sortOrder = "ascNumber";
            ViewBag.NameSort = (sortOrder == "name_asc") ? "name_desc" : "name_asc";


            IQueryable<Movie> Movie = db.Movies;
            switch (sortOrder)
            {
                case "name_desc":
                    Movie = Movie.OrderByDescending(m => m.MovieName);
                    break;
                case "name_asc":
                    Movie = Movie.OrderBy(m => m.MovieName);
                    break;
                default:
                    Movie = Movie.OrderByDescending(m => m.MovieName);
                    break;
            }
            ViewBag.PageTitle = "List of Movies (Total " + db.Movies.Count() + " )";

            
               
                ViewBag.GenreAction =db.Movies.Count(mv => mv.genre == Genre.Action);
                ViewBag.GenreComedy = db.Movies.Count(mv => mv.genre == Genre.Comedy);
                ViewBag.GenreThriller = db.Movies.Count(mv => mv.genre == Genre.Thriller);
                ViewBag.GenreHorror = db.Movies.Count(mv => mv.genre == Genre.Horror);
                ViewBag.GenreCrime = db.Movies.Count(mv => mv.genre == Genre.Crime);

            
           
            return View(Movie.ToList());

            


            //if (sortOrder == null) sortOrder = "ascNumber";
            //ViewBag.NoActors = (sortOrder == "ascNumber") ? "descNumber" : "ascNumber";

            //IQueryable<Movie> movies = db.Movies;
            //switch (sortOrder)
            //{
               
            //    case "descNumber":
            //        ViewBag.NoActors = "ascNumber";
            //        movies = movies.OrderByDescending(c => c.Actors.Count).Include("Actors");
            //        break;
               
            //    case "ascNumber":
            //        ViewBag.NoActors = "descNumber";
            //        movies = movies.OrderBy(c => c.Actors.Count).Include("Actors");
            //        break;
            //    default:
            //        ViewBag.NoActors = "ascNumber";
            //        movies = movies.OrderBy(c => c.Actors.Count).Include("Actors");
            //        break;
            //}

           
           
           
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            var q = db.Movies.Find(id);
            if (q == null)
            {
            }
            return View(q);
        }


       
        //
        // GET: /Home/Create

        public PartialViewResult ActorsByID(int id)
        {
            
            return PartialView("_ActorsInMovie", db.Movies.Find(id).Actors);
        }

        public ActionResult Create()
        {
            ViewBag.leadersList = db.Actors.ToList();
            return View();
        }
        public ActionResult CreateActor()
        {
            return View();
        }
        [HttpPost, ActionName("CreateActor")]
        public ActionResult CreateActor2(Actor incomingActor)
        {

            if (ModelState.IsValid)
            {
                db.Actors.Add(incomingActor);
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }
            return null;

         
        }
    
       

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(Movie incomingMovie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db2 = new MoviesDb())
                    {
                        db.Movies.Add(incomingMovie);
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");   
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        [HttpPost ]
        public HttpStatusCodeResult UpdateActor(Actor Actors)
        {
            try
            {
                db.Entry(Actors).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
        }


        //
        // GET: /Home/Edit/5

        //public ActionResult Edit(int id)
        //{
        //    ViewBag.leadersList = db.Actors.ToList();
        //    return View(db.Movies.Find(id));
        //}

        //
        // POST: /Home/Edit/5
        public PartialViewResult EditMoviesID(int id)
        {
            return PartialView("_EditMovies", db.Movies.Find(id));
        }

        [HttpPost, ActionName("EditMoviesID")]
        public ActionResult Edit(Movie editMovie)
        {
            try
            {
                
                db.Entry(editMovie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //public ActionResult DeleteMovie(int id)
        //{

        //    return View(db.Movies.Find(id));
        //}

        //
        // POST: /Home/Delete/5
        //
        // GET: /Home/Delete/5
        public PartialViewResult MoviesByID(int id)
        {
            return PartialView("_DeleteMovies", db.Movies.Find(id));
        }
       
     

        [HttpPost, ActionName("MoviesByID")]
       public ActionResult DeleteConfirmed(int id)
        {
            db.Movies.Remove(db.Movies.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteActors(int id)
        {
            return View(db.Actors.Find(id));
        }
        [HttpPost, ActionName("DeleteActors")]
        public ActionResult DeleteConfirmed2(int id)
        {
            db.Actors.Remove(db.Actors.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EditActor(int id)
        {
            return View(db.Actors.Find(id));
        }
        [HttpPost, ActionName("EditActor")]
        public ActionResult EditActor(Actor EditActor)
        {
            try
            {

                db.Entry(EditActor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}

