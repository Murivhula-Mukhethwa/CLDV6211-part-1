using Event_EaseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Event_EaseApp.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var Event = await _context.Event.ToListAsync();
            return View(Event);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Event eventModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventModel = await _context.Event.FirstOrDefaultAsync(m => m.EventID == id);
            if (eventModel == null)
            {
                return NotFound();
            }
            return View(eventModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventModel = await _context.Event.FirstOrDefaultAsync(m => m.EventID == id);
            if (eventModel == null)
            {
                return NotFound();
            }
            return View(eventModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventModel = await _context.Event.FindAsync(id);
            _context.Event.Remove(eventModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.EventID == id);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventModel = await _context.Event.FindAsync(id);
            if (eventModel == null)
            {
                return NotFound();
            }
            return View(eventModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("EventName,EventID,VenueID,EventDate,Description")] Event eventModel)
        {
            if (id != eventModel.EventID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(eventModel.EventID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(eventModel);
        }
    }
}





