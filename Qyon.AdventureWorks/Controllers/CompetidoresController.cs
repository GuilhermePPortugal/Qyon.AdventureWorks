#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Qyon.AdventureWorks.Models;

namespace Qyon.AdventureWorks.Controllers
{
    public class CompetidoresController : Controller
    {
        private readonly Contexto _context;

        public CompetidoresController(Contexto context)
        {
            _context = context;
        }

        // GET: Competidores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Competidores.ToListAsync());
        }

        // GET: Competidores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competidores = await _context.Competidores
                .FirstOrDefaultAsync(m => m.Id_Competidores == id);
            if (competidores == null)
            {
                return NotFound();
            }

            return View(competidores);
        }

        // GET: Competidores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Competidores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Competidores,Nome,Sexo,TemperaturaMediaCorpo,Peso,Altura")] Competidores competidores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(competidores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(competidores);
        }

        // GET: Competidores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competidores = await _context.Competidores.FindAsync(id);
            if (competidores == null)
            {
                return NotFound();
            }
            return View(competidores);
        }

        // POST: Competidores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Competidores,Nome,Sexo,TemperaturaMediaCorpo,Peso,Altura")] Competidores competidores)
        {
            if (id != competidores.Id_Competidores)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competidores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompetidoresExists(competidores.Id_Competidores))
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
            return View(competidores);
        }

        // GET: Competidores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competidores = await _context.Competidores
                .FirstOrDefaultAsync(m => m.Id_Competidores == id);
            if (competidores == null)
            {
                return NotFound();
            }

            return View(competidores);
        }

        // POST: Competidores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var competidores = await _context.Competidores.FindAsync(id);
            _context.Competidores.Remove(competidores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetidoresExists(int id)
        {
            return _context.Competidores.Any(e => e.Id_Competidores == id);
        }
    }
}
