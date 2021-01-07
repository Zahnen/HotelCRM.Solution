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
    public ActionResult Create(Property Property, int RoomId)
    {
      _db.Properties.Add(Property);
      if (RoomId != 0)
      {
        _db.RoomProperty.Add(new RoomProperty() { RoomId = RoomId, PropertyId = Property.PropertyId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisProperty = _db.Properties 
        .Include(property => property.Rooms)
        .ThenInclude(join => join.Room)
        .FirstOrDefault(property => property.PropertyId == id);
      return View(thisProperty);
    }

    public ActionResult Edit(int id)
    {
      var thisProperty = _db.Properties.FirstOrDefault(property => property.PropertyId == id);
      ViewBag.RoomId = new SelectList(_db.Rooms, "RoomId", "Name");
      return View(thisProperty);
    }

    [HttpPost]
    public ActionResult Edit(Property property, int RoomId)
    {
      if (RoomId != 0)
      {
        _db.RoomProperty.Add(new RoomProperty() { RoomId = RoomId, PropertyId = property.PropertyId });
      }
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
