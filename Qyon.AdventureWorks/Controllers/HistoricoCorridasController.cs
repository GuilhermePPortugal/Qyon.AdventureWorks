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
    public class HistoricoCorridasController : Controller
    {
        private readonly Contexto _context;

        public HistoricoCorridasController(Contexto context)
        {
            _context = context;
        }

        // GET: HistoricoCorridas
        public async Task<IActionResult> Index()
        {
            var contexto = _context.HistoricoCorrida.Include(h => h.Competidores).Include(h => h.PistaCorrida);
            return View(await contexto.ToListAsync());
        }

        // GET: HistoricoCorridas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historicoCorrida = await _context.HistoricoCorrida
                .Include(h => h.Competidores)
                .Include(h => h.PistaCorrida)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historicoCorrida == null)
            {
                return NotFound();
            }

            return View(historicoCorrida);
        }

        // GET: HistoricoCorridas/Create
        public IActionResult Create()
        {
            ViewData["Id_Competidores"] = new SelectList(_context.Competidores, "Id_Competidores", "Nome");
            ViewData["Id_PistaCorrida"] = new SelectList(_context.PistaCorrida, "Id_PistaCorrida", "Descricao");
            return View();
        }

        // POST: HistoricoCorridas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_Competidores,Id_PistaCorrida,DataCorrida,TempoGasto")] HistoricoCorrida historicoCorrida)
        {
         //   if (ModelState.IsValid)
         //   {
                _context.Add(historicoCorrida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
          ///  }
            ViewData["Id_Competidores"] = new SelectList(_context.Competidores, "Id_Competidores", "Nome", historicoCorrida.Id_Competidores);
            ViewData["Id_PistaCorrida"] = new SelectList(_context.PistaCorrida, "Id_PistaCorrida", "Descricao", historicoCorrida.Id_PistaCorrida);
            return View(historicoCorrida);

        }
        

        // GET: HistoricoCorridas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historicoCorrida = await _context.HistoricoCorrida.FindAsync(id);
            if (historicoCorrida == null)
            {
                return NotFound();
            }
            ViewData["Id_Competidores"] = new SelectList(_context.Competidores, "Id_Competidores", "Nome", historicoCorrida.Id_Competidores);
            ViewData["Id_PistaCorrida"] = new SelectList(_context.PistaCorrida, "Id_PistaCorrida", "Descricao", historicoCorrida.Id_PistaCorrida);
            return View(historicoCorrida);
        }

        // POST: HistoricoCorridas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_Competidores,Id_PistaCorrida,DataCorrida,TempoGasto")] HistoricoCorrida historicoCorrida)
        {
            if (id != historicoCorrida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historicoCorrida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoricoCorridaExists(historicoCorrida.Id))
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
            ViewData["Id_Competidores"] = new SelectList(_context.Competidores, "Id_Competidores", "Nome", historicoCorrida.Id_Competidores);
            ViewData["Id_PistaCorrida"] = new SelectList(_context.PistaCorrida, "Id_PistaCorrida", "Descricao", historicoCorrida.Id_PistaCorrida);
            return View(historicoCorrida);
        }

        // GET: HistoricoCorridas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historicoCorrida = await _context.HistoricoCorrida
                .Include(h => h.Competidores)
                .Include(h => h.PistaCorrida)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historicoCorrida == null)
            {
                return NotFound();
            }

            return View(historicoCorrida);
        }

        // POST: HistoricoCorridas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historicoCorrida = await _context.HistoricoCorrida.FindAsync(id);
            _context.HistoricoCorrida.Remove(historicoCorrida);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoricoCorridaExists(int id)
        {
            return _context.HistoricoCorrida.Any(e => e.Id == id);
        }
    }
}
