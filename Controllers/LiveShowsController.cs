using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LiveMusicFinder.Data;
using LiveMusicFinder.Models;
using Microsoft.AspNetCore.Authorization;

namespace Controllers
{
  public class LiveShowsController : Controller
  {
    private readonly ApplicationDbContext _context;

    public LiveShowsController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: LiveShows
    public async Task<IActionResult> Index()
    {
      return View(await _context.LiveShows.ToListAsync());
    }

    // GET: LiveShows/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var liveShow = await _context.LiveShows
          .FirstOrDefaultAsync(m => m.Id == id);
      if (liveShow == null)
      {
        return NotFound();
      }

      return View(liveShow);
    }

    // GET: LiveShows/Create
    [Authorize]
    public IActionResult Create()
    {
      return View();
    }

    // POST: LiveShows/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> Create([Bind("Id,Artist,Venue,ShowDate")] LiveShow liveShow)
    {
      liveShow.EnteredBy = User.Identity.Name;
      if (ModelState.IsValid)
      {
        _context.Add(liveShow);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(liveShow);
    }

    // GET: LiveShows/Edit/5
    [Authorize]
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var liveShow = await _context.LiveShows.FindAsync(id);
      if (liveShow == null)
      {
        return NotFound();
      }
      return View(liveShow);
    }

    // POST: LiveShows/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Artist,Venue,ShowDate")] LiveShow liveShow)
    {
      liveShow.EnteredBy = User.Identity.Name;
      if (id != liveShow.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(liveShow);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!LiveShowExists(liveShow.Id))
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
      return View(liveShow);
    }

    // GET: LiveShows/Delete/5
    [Authorize]
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var liveShow = await _context.LiveShows
          .FirstOrDefaultAsync(m => m.Id == id);
      if (liveShow == null)
      {
        return NotFound();
      }

      return View(liveShow);
    }

    // POST: LiveShows/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var liveShow = await _context.LiveShows.FindAsync(id);
      _context.LiveShows.Remove(liveShow);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool LiveShowExists(int id)
    {
      return _context.LiveShows.Any(e => e.Id == id);
    }
  }
}
