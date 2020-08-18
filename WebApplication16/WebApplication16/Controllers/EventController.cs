using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using WebApplication16.Models;

namespace WebApplication16.Controllers
{
    public class EventController : Controller
    {
        private readonly EventContext _context;

        public EventController(EventContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Events.ToListAsync());
        }
        public IActionResult AddorEdit(int id = 0)
        {
            if(id==0)
            return View(new Event());
            else
                return View(_context.Events.Find(id));


        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit([Bind("EventID,EventName,Detail,Start,End")] Event @event)
        {
            if (ModelState.IsValid)
            {
                if (@event.EventID ==0)
                   _context.Add(@event);
            else
                _context.Update(@event);
            await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

       
       
        public async Task<IActionResult> Delete(int? id)
        {
            var @event = await _context.Events.FindAsync(id);
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
