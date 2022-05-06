using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PDXBandIndex.Models;
using System.Collections.Generic;
using System.Linq;

namespace PDXBandIndex.Controllers
{

  public class ShowsController : Controller
  {
    private readonly PDXBandIndexContext _db;

    public ShowsController(PDXBandIndexContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Show> model = _db.Shows.ToList();
      return View(model);
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

    // public ActionResult DeleteOldShow()
    // {
    //   var showToRemove = _db.Shows;
      
    // }
  }
}