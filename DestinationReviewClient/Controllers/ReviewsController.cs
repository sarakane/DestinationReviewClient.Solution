using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DestinationReviewClient.Models;

namespace DestinationReviewClient.Controllers
{
  public class ReviewsController : Controller
  {
    public IActionResult Index()
    {
      var allReviews = Review.GetReviews();
      return View(allReviews);
    }

    public IActionResult Details(int id)
    {
      var review = Review.GetDetails(id);
      ViewBag.User = ApplicationUser.GetDetails(review.UserId);
      return View(review);
    }
  }
}