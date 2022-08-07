using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PDXBandIndex.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace PDXBandIndex.Controllers
{

  [Authorize]
  public class ShowsController : Controller
  {
    private readonly PDXBandIndexContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public ShowsController(UserManager<ApplicationUser> userManager, PDXBandIndexContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index(bool Favorite, int id)
    {
      List<Show> model = _db.Shows.OrderBy(show => show.Date).Where(show => show.Date >= System.DateTime.Today).ToList();
      // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      // var currentUser = await _userManager.FindByIdAsync(userId);
      // var favShows = _db.Shows.Where(entry => entry.User.Id == currentUser.Id).OrderBy(thisShow => thisShow.Date).Where(thisShow => thisShow.Favorite == true);
      var favShows = _db.Shows.OrderBy(x => x.Date).Where(thisShow => thisShow.Favorite == true);
      ViewBag.Shows = favShows.OrderBy(x => x.Date).Where(x => x.Date >= System.DateTime.Today);
      return View(model);
    }

    [HttpPost]
    public ActionResult Index(Show show)
    {
      _db.Entry(show).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Show show)
    {
      _db.Shows.Add(show);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisShow = _db.Shows
          .Include(show => show.JoinEntities)
          .ThenInclude(join => join.Band)
          .FirstOrDefault(show => show.ShowId == id);
      return View(thisShow);
    }

    public ActionResult Edit(int id)
    {
      var thisShow = _db.Shows.FirstOrDefault(show => show.ShowId == id);
      return View(thisShow);
    }

    [HttpPost]
    public ActionResult Edit(Show show)
    {
      _db.Entry(show).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisShow = _db.Shows.FirstOrDefault(show => show.ShowId == id);
      
      return View(thisShow);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisShow = _db.Shows.FirstOrDefault(show => show.ShowId == id);
      _db.Shows.Remove(thisShow);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Favorite(int id)
    {
      var thisShow = _db.Shows.FirstOrDefault(show => show.ShowId == id);
      return View(thisShow);
    }

    [HttpPost]
    public ActionResult Favorite(Show show)
    {
      _db.Entry(show).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}