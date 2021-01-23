using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using cinema.Dal;
using cinema.Models;

namespace cinema.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult Gallery(string filterValue)
        {
            
            var moviesGalleryObj = new CinemaDal();
            var galleryList = moviesGalleryObj.movies.ToList();
            var screeningList = moviesGalleryObj.screenings.ToList();
            if (filterValue == "Price increase")
            {
                galleryList = galleryList.OrderBy(o => (o.currentPrice)).ToList<Movies>();
            }
            if (filterValue == "Price decrease")
            {
                galleryList = galleryList.OrderBy(o => (o.currentPrice)).ToList<Movies>();
                galleryList.Reverse();
            }
            if (filterValue == "Safe Content")
            {
                //string ageLimit = Request.Form["age"].ToString();
                galleryList = (from x in moviesGalleryObj.movies where x.ageLimit < 16 select x).ToList<Movies>();
            }
            if (filterValue == "Pegi 16")
            {
                //string ageLimit = Request.Form["age"].ToString();
                galleryList = (from x in moviesGalleryObj.movies where x.ageLimit >= 16 select x).ToList<Movies>();
            }
            if (filterValue == "Most Popular")
            {
                //לקחת מטבלת טיקטים את הסרט שמופיע הכי הרבה פעמים
                Dictionary<string, int> mostPopMovie = new Dictionary<string, int>();
                foreach (var item in moviesGalleryObj.movies)
                {
                    mostPopMovie.Add(item.movieName, 0);
                }
                foreach (var item in moviesGalleryObj.tickets)
                {
                    mostPopMovie[item.movieName] += 1;
                }
                var maxValue = mostPopMovie.Values.Max();
                var tempList = new List<Movies>();
                foreach (var item in moviesGalleryObj.movies)
                {
                    if(mostPopMovie[item.movieName] == maxValue)
                    {
                        tempList.Add(item);
                    }
                }
                galleryList = tempList;
                
            }
            if (filterValue == "Category")
            {
                string cat = Request.Form["category"].ToString();
                galleryList = (from x in moviesGalleryObj.movies where x.category.Equals(cat) select x).ToList<Movies>();
            }
            if (filterValue == "On Sale")
            {
                galleryList = (from x in moviesGalleryObj.movies where x.currentPrice < x.previousPrice select x).ToList<Movies>();
            }
            if(filterValue == "Date")
            {
                Movies movieItem = new Movies();
                var newStringList = new List<String>();
                var tempGalleryList = new List<Movies>();
                int i = 0;
                string dateString = Request.Form["date"].ToString();
                newStringList = (from x in moviesGalleryObj.screenings where x.sDate.Equals(dateString) select x.movieName).ToList<String>();
                galleryList = (from x in moviesGalleryObj.movies where newStringList.Contains(x.movieName) select x).ToList<Movies>();

                //screeningList = (from x in moviesGalleryObj.screenings where x.sDate.Equals(dateString) select x).ToList<Screenings>();
                //foreach (var item in screeningList)
                //{
                //    movieItem = (from x in moviesGalleryObj.movies where x.movieName.Equals(item.movieName) select x).ToList<Movies>()[i];
                //    tempGalleryList.Add(movieItem);
                //    i++;
                //}
                //galleryList = tempGalleryList;
            }
            if (filterValue == "Hour")
            {
                Movies movieItem = new Movies();
                var newStringList = new List<String>();
                var tempGalleryList = new List<Movies>();
                int i = 0;
                string hourString = Request.Form["hour"].ToString();
                newStringList = (from x in moviesGalleryObj.screenings where x.sHour.Equals(hourString) select x.movieName).ToList<String>();
                galleryList = (from x in moviesGalleryObj.movies where newStringList.Contains(x.movieName) select x).ToList<Movies>();
            }
            if (filterValue == "Price Range")
            {
                int priceRangeString = Int32.Parse(Request.Form["priceRange"]);
                galleryList = (from x in moviesGalleryObj.movies where x.currentPrice <= priceRangeString select x).ToList<Movies>();

            }
            return View(galleryList);
        }

        public ActionResult ViewScreenings(string movieName, string filterValue="def")
        {
            var moviesViewScreeningsObj = new CinemaDal();
            var screeningsList = new List<Screenings>();
            int i = 0;
            //var galleryList = moviesViewScreeningsObj.screenings.ToList();
            foreach (var item in moviesViewScreeningsObj.screenings.ToList<Screenings>())
            {
                if (item.movieName == movieName)
                {
                    Screenings s = (from x in moviesViewScreeningsObj.screenings where x.movieName.ToString().Equals(movieName.ToString()) select x).ToList<Screenings>()[i];
                    string[] dateSplit = s.sDate.Split('-');
                    DateTime now = new DateTime(Int32.Parse(dateSplit[0]), Int32.Parse(dateSplit[1]), Int32.Parse(dateSplit[2]));
                    if(now > DateTime.Now)
                    {
                        screeningsList.Add(s);
                    }

                    i++;
                }
            }
            if (filterValue == "lastDate")
            {

                if (screeningsList.Count > 1)
                {
                    var tempScreenList = new List<Screenings>();
                    Screenings maxScreening = new Screenings();
                    Screenings minScreening = new Screenings();
                    maxScreening = screeningsList[0];
                    string[] maxSplit = maxScreening.sDate.Split('-');
                    string[] minSplit;
                    string[] maxSplitHour = maxScreening.sHour.Split(':');
                    string[] minSplitHour;
                    for (i = 1; i < screeningsList.Count; i++)
                    {
                        minScreening = screeningsList[i];
                        minSplit = minScreening.sDate.Split('-');
                        if (Int32.Parse(minSplit[0]) > Int32.Parse(maxSplit[0]))
                        {
                            maxScreening = minScreening;
                            maxSplit = maxScreening.sDate.Split('-');
                        }
                        else if ((Int32.Parse(minSplit[0]) == Int32.Parse(maxSplit[0])) && (Int32.Parse(minSplit[1]) > Int32.Parse(maxSplit[1])))
                        {
                            maxScreening = minScreening;
                            maxSplit = maxScreening.sDate.Split('-');
                        }
                        else if ((Int32.Parse(minSplit[0]) == Int32.Parse(maxSplit[0])) && (Int32.Parse(minSplit[1]) == Int32.Parse(maxSplit[1])) && (Int32.Parse(minSplit[2]) > Int32.Parse(maxSplit[2])))
                        {
                            maxScreening = minScreening;
                            maxSplit = maxScreening.sDate.Split('-');
                        }
                        else if ((Int32.Parse(minSplit[2]) == Int32.Parse(maxSplit[2])) && (Int32.Parse(minSplit[1]) == Int32.Parse(maxSplit[1])) && (Int32.Parse(minSplit[0]) == Int32.Parse(maxSplit[0])))
                        {
                            minSplitHour = minScreening.sHour.Split(':');
                            if (Int32.Parse(minSplitHour[0]) > Int32.Parse(maxSplitHour[0]))
                            {
                                maxScreening = minScreening;
                                maxSplitHour = maxScreening.sHour.Split(':');
                                maxSplit = maxScreening.sDate.Split('-');
                            }
                            else if ((Int32.Parse(minSplitHour[0]) == Int32.Parse(maxSplitHour[0])) && Int32.Parse(minSplitHour[1]) > Int32.Parse(maxSplitHour[1]))
                            {
                                maxScreening = minScreening;
                                maxSplitHour = maxScreening.sHour.Split(':');
                                maxSplit = maxScreening.sDate.Split('-');
                            }
                        }
                    }
                    tempScreenList.Add(maxScreening);
                    return View(tempScreenList);
                }
            }
            return View(screeningsList);
        }



        public ActionResult Buy(string movieName, string sDate, string sHour, string hall)
        {
            var buyATicketDb = new CinemaDal();
            var listOfTicets = new List<Tickets>(); //list of tickets - this seat will shows as not available
            var takenSits = (from x in buyATicketDb.tickets where x.sDate.ToString().Contains(sDate) && x.sHour.ToString().Equals(sHour) && x.hall.ToString().Equals(hall) select x).ToList<Tickets>();
            var hallObj = (from y in buyATicketDb.hall where y.hall.Equals(hall) select y).First();
            var seats = new List<ViewTicket>();
            int numOfRows = Int32.Parse(hallObj.numOfRows);
            int numOfSeats = Int32.Parse(hallObj.numOfSeats);
            string temp = "";
            for (int i = 1; i <= numOfRows; i++)
            {
                for (int j = 1; j <= numOfSeats; j++)
                {
                    if (takenSits.Where(s => Int32.Parse(s.numOfRow) == i && Int32.Parse(s.numOfSeat) == j).Any())
                    {
                        temp = "Occupied";
                    }
                    else
                    {
                        temp = "Unoccupied";
                    }
                    seats.Add(new ViewTicket
                    {
                        row = i,
                        col = j,
                        taken = temp,
                        movieName = movieName,
                        sHour = sHour,
                        sDate = sDate,
                        hall = hall
                    });
                }
            }
            return View("Buy", seats);
        }

        public ActionResult AddToCart(string movieName, string sDate, string sHour, string hall, string numOfRow, string numOfSeat)
        {
            var cartDb = new CinemaDal();
            Cart addTtoCart = new Cart();
            var isInCart = (from x in cartDb.cart where x.sDate.ToString().Contains(sDate) && x.sHour.ToString().Equals(sHour) && x.hall.ToString().Equals(hall) && x.numOfRow.ToString().Equals(numOfRow) && x.numOfSeat.ToString().Equals(numOfSeat) select x).ToList<Cart>();
            if (isInCart.Where(y => y.sDate == sDate && y.sHour == sHour && y.numOfRow == numOfRow && y.numOfSeat == numOfSeat).Any())
            {
                string text = "This seat is already in your cart, please try another one";
                MessageBox.Show(text);
            }
            else
            {
                Screenings s = (from x in cartDb.screenings where x.sDate.ToString().Contains(sDate) && x.sHour.ToString().Equals(sHour) && x.hall.ToString().Equals(hall) select x).ToList<Screenings>()[0];
                Movies m = (from tmp in cartDb.movies where s.movieName.Equals(tmp.movieName) select tmp).ToList<Movies>()[0];
                //var t = (from x in cartDb.tickets where x.sDate.ToString().Contains(sDate) && x.sHour.ToString().Equals(sHour) && x.hall.ToString().Equals(hall) select x).ToList<Tickets>();
                addTtoCart.hall = hall;
                addTtoCart.sDate = sDate;
                addTtoCart.sHour = sHour;
                addTtoCart.numOfRow = numOfRow;
                addTtoCart.numOfSeat = numOfSeat;
                addTtoCart.movieName = s.movieName;
                addTtoCart.price = m.currentPrice;
                cartDb.cart.Add(addTtoCart);
                cartDb.SaveChanges();
                string text = "Your ticket has been successfully added to the cart";
                MessageBox.Show(text);
            }
            return Buy(movieName,sDate, sHour, hall);
        }

        public ActionResult SignUp()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SignUp1(Users userObj)
        {
            var newDal = new CinemaDal();
            if (userObj != null)
            {
                if(newDal.users.Where(s => s.userName == userObj.userName).Any())
                {
                    string text = "This username is already exist, please choose another one";
                    MessageBox.Show(text);
                    return RedirectToAction("SignUp");
                }
                newDal.users.Add(userObj);
                newDal.SaveChanges(); // לדאוג לולדיציות
            }
            return RedirectToAction("Gallery");
        }

        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login1()
        {

            string userNameGetter = Request.Form["userName"];
            string passwordGetter = Request.Form["userPassword"];
            var newDal = new CinemaDal();
            foreach (var item in newDal.cart.ToList<Cart>()) // remove from cart while new user is loged in
            {
                newDal.cart.Remove(item);
                newDal.SaveChanges();

            }
                //Users u = (from x in newDal.users where x.userName.ToString().Equals(userNameGetter) && x.userPassword.ToString().Equals(passwordGetter) select x).ToList<Users>().First();
                if (newDal.users.Where(s => s.userName == userNameGetter && s.userPassword == passwordGetter && s.permission == "regular").Any())
            {
                Session["login"] = "true";
                
                return RedirectToAction("Gallery", "Home");
            }
            if(newDal.users.Where(s => s.userName == userNameGetter && s.userPassword == passwordGetter && s.permission == "admin").Any())
            {
                    return RedirectToAction("AdminHome", "Admin");
            }
            else
            {
                string text = "You are not a registered user, Please sign up before Login";
                MessageBox.Show(text);
            }
            return RedirectToAction("Login");
        }
        public ActionResult Cart()
        {
            var newDal = new CinemaDal();
            var ticketList = newDal.cart.ToList();

            return View(ticketList);
        }

        public ActionResult DeleteFromCart(string sDate, string sHour, string hall, string numOfSeat, string numOfRow)
        {
            var newDal = new CinemaDal();
            Cart c = (from x in newDal.cart where x.sDate.ToString().Equals(sDate.ToString()) && x.sHour.ToString().Equals(sHour.ToString()) && x.hall.ToString().Equals(hall.ToString()) && x.numOfSeat.ToString().Equals(numOfSeat.ToString()) && x.numOfRow.ToString().Equals(numOfRow.ToString()) select x).ToList<Cart>()[0];
            newDal.cart.Remove(c);
            newDal.SaveChanges();
            return RedirectToAction("Cart");
        }

        public ActionResult Payment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Payment1()
        {
            var newDal = new CinemaDal();
            Tickets t = new Tickets();
            int i = 0;
            
            foreach (var item in newDal.cart.ToList<Cart>())
            {
                t.hall = item.hall;
                t.movieName = item.movieName;
                t.numOfRow = item.numOfRow;
                t.numOfSeat = item.numOfSeat;
                t.sDate = item.sDate;
                t.sHour = item.sHour;
                newDal.tickets.Add(t);
                newDal.SaveChanges();
                t = new Tickets();
                newDal.cart.Remove(item);
                newDal.SaveChanges();
            }
            Random random = new Random();
            int randNum = random.Next(0,2);
            if(randNum == 0)
            {
                string text = "Your order has been successfully received";
                MessageBox.Show(text);
                return RedirectToAction("Gallery", "Home");
            }
            else
            {
                string text = "The Credit card company declined your card, please try another one";
                MessageBox.Show(text);
                return View("Payment");
            }
        }
        public ActionResult PayDirectly(string movieName, string sDate, string sHour, string hall, string numOfRow, string numOfSeat)
        {
            var newDal = new CinemaDal();
            Tickets t = new Tickets();
            t.hall = hall;
            t.movieName = movieName;
            t.numOfRow = numOfRow;
            t.numOfSeat = numOfSeat;
            t.sDate = sDate;
            t.sHour = sHour;
            foreach (var item in newDal.cart.ToList<Cart>())
            { // במידה ויש מישהו שמשלם ישיר, וקיים כרטיס כזה בעגלת קניות, הכרטיס ימחק מעגלת הקניות על-מנת שאותו מישהו שמשלם באופן ישיר, יוכל לשלם
                if(t.hall == item.hall && t.numOfRow == item.numOfRow && t.numOfSeat == item.numOfSeat && t.sDate == item.sDate && t.sHour == item.sHour)
                {
                    newDal.cart.Remove(item);
                    newDal.SaveChanges();
                }
            }
            newDal.tickets.Add(t);
            newDal.SaveChanges();
            return View();
        }
        [HttpPost]
        public ActionResult PayDirectly1()
        {
            Random random = new Random();
            int randNum = random.Next(0, 2);
            if (randNum == 0)
            {
                string text = "Your order has been successfully received";
                MessageBox.Show(text);
                return RedirectToAction("Gallery", "Home");
            }
            else
            {
                string text = "The Credit card company declined your card, please try another one";
                MessageBox.Show(text);
                return View("PayDirectly");
            }
        }

        public ActionResult Logout()
        {
            Session["login"] = null;
            return RedirectToAction("Gallery");
        }
    }
}
