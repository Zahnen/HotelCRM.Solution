using Microsoft.AspNetCore.Mvc;
using HotelCRM.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelCRM.Controllers
{
  public class PropertiesController : Controller
  {
    private readonly HotelCRMContext _db;

    public PropertiesController(HotelCRMContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Property> model = _db.Properties.ToList();
      return View(_db.Properties.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Property Property)
    {
      _db.Properties.Add(Property);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Property thisProperty = _db.Properties
        .Include(Property => Property.Guests)
        .ThenInclude(join => join.Guest)
        .FirstOrDefault(Property => Property.PropertyId == id);
      return View(thisProperty);
    }

    public ActionResult Edit(int id)
    {
      var thisProperty = _db.Properties.FirstOrDefault(property => property.PropertyId == id);
      return View(thisProperty);
    }

    [HttpPost]
    public ActionResult Edit(Property property)
    {
      _db.Entry(property).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisProperty = _db.Properties.FirstOrDefault(property => property.PropertyId == id);
      return View(thisProperty);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisProperty = _db.Properties.FirstOrDefault(property => property.PropertyId == id);
      _db.Properties.Remove(thisProperty);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
