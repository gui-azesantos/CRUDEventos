using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudBandas.Data;
using CrudBandas.Models;
using Microsoft.AspNetCore.Authorization;

namespace CrudBandas.Controllers
{
    [Authorize (Policy = "Auth")]
    public class CasasDeShow : Controller
    {
        private readonly ApplicationDbContext _context;

        public CasasDeShow(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CasasDeShow
        public async Task<IActionResult> Index()
        {
            return View(await _context.CasaDeShow.ToListAsync());
        }

        // GET: CasasDeShow/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casaDeShow = await _context.CasaDeShow
                .FirstOrDefaultAsync(m => m.Id == id);
            if (casaDeShow == null)
            {
                return NotFound();
            }

            return View(casaDeShow);
        }

        // GET: CasasDeShow/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CasasDeShow/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Endereco")] CasaDeShow casaDeShow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(casaDeShow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(casaDeShow);
        }

        // GET: CasasDeShow/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casaDeShow = await _context.CasaDeShow.FindAsync(id);
            if (casaDeShow == null)
            {
                return NotFound();
            }
            return View(casaDeShow);
        }

        // POST: CasasDeShow/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Endereco")] CasaDeShow casaDeShow)
        {
            if (id != casaDeShow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(casaDeShow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CasaDeShowExists(casaDeShow.Id))
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
            return View(casaDeShow);
        }

        // GET: CasasDeShow/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casaDeShow = await _context.CasaDeShow
                .FirstOrDefaultAsync(m => m.Id == id);
            if (casaDeShow == null)
            {
                return NotFound();
            }

            return View(casaDeShow);
        }

        // POST: CasasDeShow/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var casaDeShow = await _context.CasaDeShow.FindAsync(id);
            _context.CasaDeShow.Remove(casaDeShow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CasaDeShowExists(int id)
        {
            return _context.CasaDeShow.Any(e => e.Id == id);
        }
    }
}
