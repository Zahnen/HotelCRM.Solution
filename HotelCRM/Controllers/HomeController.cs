using Microsoft.AspNetCore.Mvc;

namespace HotelCRM.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}