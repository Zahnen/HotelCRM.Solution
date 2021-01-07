using Microsoft.AspNetCore.Mvc;
using HotelCRM.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelCRM.Controllers
{
  public class GuestsController : Controller
  {
    private readonly HotelCRMContext _db;

    public GuestsController(HotelCRMContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Guests.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.RoomId = new SelectList(_db.Rooms, "RoomId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Guest guest, int RoomId)
    {
      _db.Guests.Add(guest);
      if (RoomId != 0)
      {
        _db.GuestRoom.Add(new GuestRoom() { RoomId = RoomId, GuestId = guest.GuestId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Guest thisGuest = _db.Guests
        .Include(Guest => Guest.Rooms)
        .ThenInclude(join => join.Room)
        .FirstOrDefault(Guest => Guest.GuestId == id);
      return View(thisGuest);
    }

    public ActionResult Edit(int id)
    {
      var thisGuest = _db.Guests.FirstOrDefault(Guests => Guests.GuestId == id);
      ViewBag.RoomId = new SelectList(_db.Rooms, "RoomId", "Name");
      return View(thisGuest);
    }

    [HttpPost]
    public ActionResult Edit(Guest guest, int RoomId)
    {
      if (RoomId != 0)
      {
        _db.GuestRoom.Add(new GuestRoom() { RoomId = RoomId, GuestId = guest.GuestId });
      }
      _db.Entry(guest).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisGuest = _db.Guests.FirstOrDefault(Guests => Guests.GuestId == id);
      return View(thisGuest);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisGuest = _db.Guests.FirstOrDefault(guests => guests.GuestId == id);
      _db.Guests.Remove(thisGuest);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}