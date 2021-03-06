using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PDXBandIndex.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using System;

namespace PDXBandIndex.Controllers
{
  public class HomeController : Controller
  {
    private readonly PDXBandIndexContext _db;
    public HomeController(PDXBandIndexContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      var bands = _db.Bands.Where(band => band.BandId == 6);
      ViewBag.Bands = bands;
      var shows = _db.Shows.OrderBy(x => x.Date).Where(y => y.Date >= System.DateTime.Now.AddDays(1));
      ViewBag.Shows = shows.Take(4);
      var todayShows = _db.Shows.Where(x => x.Date == System.DateTime.Today);
      ViewBag.TodayShows = todayShows;
      var bandsOnShow = _db.BandShow;
      ViewBag.BandsOnShow = bandsOnShow;
      return View();
    }

    public ActionResult Search(string Search)
    {
      var bands = _db.Bands.Where(band => band.Name.Contains(Search) || (band.Name == Search)).ToList();
      var genres = _db.Genres.Where(genre => genre.Name.Contains(Search) || (genre.Name == Search)).ToList();
      var shows = _db.Shows.Where(show => show.Venue.Contains(Search) || (show.Venue == Search)).OrderBy(thisShow => thisShow.Date).Where(show => show.Date >= System.DateTime.Today).ToList();
      ViewBag.Bands = bands;
      ViewBag.Genres = genres;
      ViewBag.Shows = shows;
      return View();
    }
  }
}