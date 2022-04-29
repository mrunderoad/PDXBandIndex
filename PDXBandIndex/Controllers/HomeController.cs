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
      var bands = _db.Bands;
      ViewBag.Bands = bands;
      var shows = _db.Shows;
      ViewBag.Shows = shows;
      return View();
    }
  }
}