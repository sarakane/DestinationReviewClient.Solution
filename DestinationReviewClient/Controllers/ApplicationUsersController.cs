using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DestinationReviewClient.Models;

namespace DestinationReviewClient.Controllers
{
  public class ApplicationUsersController : Controller
  {
    public IActionResult Index()
    {
      var allUsers = ApplicationUser.GetUsers();
      return View(allUsers);
    }

    public IActionResult Details(int id)
    {
      var user = ApplicationUser.GetDetails(id);
      return View(user);
    }

    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(ApplicationUser user)
    {
      ApplicationUser.Post(user);
      return RedirectToAction("Index");
    }
  }
}