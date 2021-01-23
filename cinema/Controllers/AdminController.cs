using cinema.Dal;
using cinema.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;

namespace cinema.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminHome()
        {
            return View();
        }
        public ActionResult Movies()
        {
            var moviesMandageObj = new CinemaDal();
            var galleryList = moviesMandageObj.movies.ToList();
            return View(galleryList);
        }

        public ActionResult Screenings()
        {
            var moviesMandageObj = new CinemaDal();
            var galleryList = moviesMandageObj.screenings.ToList();
            return View(galleryList);
        }

        //[HttpPost]
        //public ActionResult Delete(string movieName)
        //{
        //    Screenings screening = new Screenings();
        //    screening.DeleteScreening(movieName);
        //    Movies movie = new Movies();
        //    movie.DeleteMovie(movieName);
        //    return RedirectToAction("Movies");
        //}

        [HttpPost]
        public ActionResult Delete(string movieName)
        {
            var moviesManageObj = new CinemaDal();
            Movies m = (from x in moviesManageObj.movies where x.movieName.ToString().Contains(movieName.ToString()) select x).ToList<Movies>()[0];
            moviesManageObj.movies.Remove(m);
            moviesManageObj.SaveChanges();
            foreach (var item in moviesManageObj.screenings.ToList<Screenings>()) 
            {
                if (item.movieName == movieName) { 
                    Screenings s = (from x in moviesManageObj.screenings where x.movieName.ToString().Contains(movieName.ToString()) select x).ToList<Screenings>()[0];
                    moviesManageObj.screenings.Remove(s);
                    moviesManageObj.SaveChanges();
                }

            }
            return RedirectToAction("Movies");
        }
   
        public ActionResult InsertMovies()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertMovies(Movies movieObj)
        {
            if (movieObj.movieName != null && movieObj.poster != null && movieObj.previousPrice != null && movieObj.currentPrice != null && movieObj.ageLimit != null && movieObj.category != null)
            {
                var newDal = new CinemaDal();
                if(newDal.movies.Where(y => y.movieName == movieObj.movieName).Any())
                {
                    string text = "This movie is already exist!";
                    MessageBox.Show(text);
                    return View("InsertMovies");
                }
                else {
                newDal.movies.Add(movieObj);
                newDal.SaveChanges(); // לדאוג לולדיציות
                }
            }
            else
            {
                string text = "There is values that stay empty, please full all the inputs";
                MessageBox.Show(text);
                return View("InsertMovies");
            }
            return RedirectToAction("Movies");
        }
        public ActionResult EditPrice()
        {
            var moviesMandageObj = new CinemaDal();
            var galleryList = moviesMandageObj.movies.ToList();

            return View("EditPrice" ,galleryList);
        }


        [HttpPost]
        public ActionResult EditPrice1(string movieName)
        {
            string price_string = Request.Form["EditPrice"];
            int price = int.Parse(price_string);
            var moviesMandageObj = new CinemaDal();
            Movies m = (from x in moviesMandageObj.movies where x.movieName.ToString().Contains(movieName.ToString()) select x).ToList<Movies>()[0];
            Movies newM = new Movies();
            newM.movieName = m.movieName;
            newM.movieName = m.movieName;
            newM.poster = m.poster;
            newM.previousPrice = m.currentPrice;
            newM.ageLimit = m.ageLimit;
            newM.category = m.category;
            newM.currentPrice = price;
            moviesMandageObj.movies.Remove(m);
            moviesMandageObj.SaveChanges();
            moviesMandageObj.movies.Add(newM);
            moviesMandageObj.SaveChanges();


            /*
            Movies mov = newDal.movies.Find(movieId);
            mov.previousPrice = mov.currentPrice;
            mov.currentPrice = price;*/
            return EditPrice();
        }

        public ActionResult EditHalls()
        {
            var moviesMandageObj = new CinemaDal();
            var galleryList = moviesMandageObj.screenings.ToList();

            return View("EditHalls", galleryList);
        }

        [HttpPost]
        public ActionResult EditHalls1(string sDate, string sHour, string hall)
        {
            string newHall = Request.Form["EditHalls"];
            //string newHall = int.Parse(price_string);
            var moviesMandageObj = new CinemaDal();
            Screenings s = (from x in moviesMandageObj.screenings where x.sDate.ToString().Equals(sDate.ToString()) && x.sHour.ToString().Equals(sHour.ToString()) && x.hall.ToString().Equals(hall.ToString()) select x).ToList<Screenings>()[0];
            var screeen = (from x in moviesMandageObj.screenings where x.sDate.ToString().Equals(sDate.ToString()) && x.sHour.ToString().Equals(sHour.ToString()) select x).ToList<Screenings>();
            Screenings newS = new Screenings();
            if (screeen.Where(y => y.sDate == sDate && y.sHour == sHour && y.hall == newHall).Any())
            {
                string text = "There is another screening at the same date and hour in this hall, try to change to another hall";
                MessageBox.Show(text);
            }
            else if (!(moviesMandageObj.hall.Where(y => y.hall == newHall).Any()))
            {
                string text = "You are trying to change this screening to hall that does not exist in the cinema";
                MessageBox.Show(text);
            }
            else
            {
                newS.movieName = s.movieName;
                newS.sDate = s.sDate;
                newS.sHour = s.sHour;
                newS.hall = newHall;
                moviesMandageObj.screenings.Remove(s);
                moviesMandageObj.SaveChanges();
                moviesMandageObj.screenings.Add(newS);
                moviesMandageObj.SaveChanges();
            }
            return EditHalls();
        }
        public ActionResult EditSeats()
        {
            var moviesMandageObj = new CinemaDal();
            var galleryList = moviesMandageObj.hall.ToList();

            return View("EditSeats", galleryList);
        }


        [HttpPost]
        public ActionResult EditSeats1(string numOfSeats, string hall)
        {
            string newNumOfSeat = Request.Form["EditSeats"];
            //string newHall = int.Parse(price_string);
            var moviesMandageObj = new CinemaDal();
            Hall h = (from x in moviesMandageObj.hall where x.hall.ToString().Equals(hall.ToString()) select x).ToList<Hall>()[0];
            Hall newH = new Hall();
            newH.hall = h.hall;
            newH.numOfSeats = newNumOfSeat;
            newH.numOfRows = h.numOfRows;
            moviesMandageObj.hall.Remove(h);
            moviesMandageObj.SaveChanges();
            moviesMandageObj.hall.Add(newH);
            moviesMandageObj.SaveChanges();
            return EditSeats();
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Gallery", "Home");
        }
    }
}