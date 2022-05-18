using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PDXBandIndex.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PDXBandIndex.Controllers
{

  public class ContactController : Controller
  {

    public IActionResult Index() 
    {
      return View();
    }
  }
}