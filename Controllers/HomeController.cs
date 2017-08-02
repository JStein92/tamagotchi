using Microsoft.AspNetCore.Mvc;
using TamagochiMaker.Models;
using System.Collections.Generic;
using System;

namespace TamagochiMaker.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet("/NewTamaGochi")]
    public ActionResult NewTamaGochi()
    {
      return View();
    }

    [HttpPost("/TamagochiDetails")]
    public ActionResult GetTamagochiDetails()
    {
      Tamagochi newTamaGochi = new Tamagochi(Request.Form["name"]);

      return View("TamagochiDetails",newTamaGochi);
    }

    [HttpGet("/TamagochiDetails/{id}/Fed")]
    public ActionResult Fed(int id)
    {
        Tamagochi newTamaGochi = Tamagochi.Find(id);
        newTamaGochi.Feed();
        return View("TamagochiDetails",newTamaGochi);
    }

    [HttpGet("/TamagochiDetails/{id}/Attention")]
    public ActionResult Attention(int id)
    {
      Tamagochi newTamagochi = Tamagochi.Find(id);
      newTamagochi.Attention();
      return View("TamagochiDetails",newTamagochi);
    }

    [HttpGet("/TamagochiDetails/{id}/Rest")]
    public ActionResult Rest(int id)
    {
      Tamagochi newTamagochi = Tamagochi.Find(id);
      newTamagochi.Rest();
      return View("TamagochiDetails", newTamagochi);
    }

    [HttpGet("/TamagochiDetails/{id}")]
    public ActionResult TamagochiDetails(int id)
    {
        Tamagochi newTamaGochi = Tamagochi.Find(id);
        return View(newTamaGochi);
    }

    [HttpGet("/AllTamagochis")]
    public ActionResult AllTamagochis()
    {
      List<Tamagochi> allTamagochis = Tamagochi.GetAll();
      return View(allTamagochis);
    }
  }
}
