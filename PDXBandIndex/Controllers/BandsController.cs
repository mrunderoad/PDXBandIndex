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

namespace PDXBandIndex.Controllers
{

  [Authorize]
  public class BandsController : Controller
  {
    private readonly PDXBandIndexContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public BandsController(UserManager<ApplicationUser> userManager, PDXBandIndexContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Index()
    {
      // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      // var currentUser = await _userManager.FindByIdAsync(userId);
      // var userBands = _db.Bands.Where(entry => entry.User.Id == currentUser.Id).ToList();
      // return View(userBands);
      var bands = _db.Bands;
      return View(bands);
    }

    public ActionResult Create()
    {
      ViewBag.GenreId = new SelectList(_db.Genres, "GenreId", "Name");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Band band, int GenreId, int ShowId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      band.User = currentUser;
      _db.Bands.Add(band);
      _db.SaveChanges();
      if (GenreId != 0)
      {
        _db.GenreBand.Add(new GenreBand() { GenreId = GenreId, BandId = band.BandId });
      }
      if (ShowId != 0)
      {
        _db.BandShow.Add(new BandShow() {
          ShowId = ShowId, BandId = band.BandId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisBand = _db.Bands
          .Include(band => band.JoinEntities)
          .ThenInclude(join => join.Genre)
          .Include(band => band.JoinEntities2)
          .ThenInclude(join => join.Show)
          .FirstOrDefault(band => band.BandId == id);
          var sortedShows = _db.Bands.Include(band => band.JoinEntities2).ThenInclude(join => join.OrderBy(join => join.Date));
          ViewBag.SortedShows = sortedShows;

      return View(thisBand);
    }

    public ActionResult Edit(int id)
    {
      var thisBand = _db.Bands.FirstOrDefault(band => band.BandId == id);
      ViewBag.GenreId = new SelectList(_db.Genres, "GenreId", "Name");
      return View(thisBand);
    }

    [HttpPost]
    public ActionResult Edit(Band band, int GenreId, int ShowId)
    {
      if (GenreId != 0)
      {
        _db.GenreBand.Add(new GenreBand() { GenreId = GenreId, BandId = band.BandId });
      }
      if (ShowId != 0)
      {
        _db.BandShow.Add(new BandShow() { ShowId = ShowId, BandId = band.BandId });
      }
      _db.Entry(band).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddGenre(int id)
    {
      var thisBand = _db.Bands.FirstOrDefault(band => band.BandId == id);
      ViewBag.GenreId = new SelectList(_db.Genres, "GenreId", "Name");
      return View(thisBand);
    }

    [HttpPost]
    public ActionResult AddGenre(Band band, int GenreId)
    {
      if (GenreId != 0)
      {
        _db.GenreBand.Add(new GenreBand() { GenreId = GenreId, BandId = band.BandId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddShow(int id)
    {
      var thisBand = _db.Bands.FirstOrDefault(band => band.BandId == id);
      ViewBag.ShowId = new SelectList(_db.Shows, "ShowId", "Venue");
      return View(thisBand);
    }

    [HttpPost]
    public ActionResult AddShow(Band band, int ShowId)
    {
      if (ShowId != 0)
      {
        _db.BandShow.Add(new BandShow() { ShowId = ShowId, BandId = band.BandId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisBand = _db.Bands.FirstOrDefault(band => band.BandId == id);
      return View(thisBand);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisBand = _db.Bands.FirstOrDefault(band => band.BandId == id);
      _db.Bands.Remove(thisBand);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteGenre(int joinId)
    {
      var joinEntry = _db.GenreBand.FirstOrDefault(entry => entry.GenreBandId == joinId);
      _db.GenreBand.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteShow(int joinId)
    {
      var joinEntry = _db.BandShow.FirstOrDefault(entry => entry.BandShowId == joinId);
      _db.BandShow.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}