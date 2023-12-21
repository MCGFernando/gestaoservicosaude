using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoServicoSaude.Data;
using GestaoServicoSaude.Models;
using GestaoServicoSaude.Services;

namespace GestaoServicoSaude.Controllers
{
    public class ProvinciasController : Controller
    {
        private readonly ProvinciaService _service;
        private readonly Context _context;

        public ProvinciasController( ProvinciaService service, Context context)
        {
            _service = service;
            _context = context; 
        }

        // GET: Provincias
        public async Task<IActionResult> Index()
        {
            
            return View(await _service.GetAllAsync());
        }

        // GET: Provincias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var provincia = await _service.GetByIdAsync(id.Value);

            if (provincia == null)
            {
                return NotFound();
            }

            return View(provincia);
        }

        // GET: Provincias/Create
        public IActionResult Create()
        {
            ViewData["PaisId"] = new SelectList(_context.Pais, "Id", "Nome");
            return View();
        }

        // POST: Provincias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Nome,PaisId")] Provincia provincia)
        {
            if (ModelState.IsValid)
            {
               
                await _service.AddAsync(provincia);
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaisId"] = new SelectList(_context.Pais, "Id", "Nome", provincia.PaisId);
            return View(provincia);
        }

        // GET: Provincias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provincia = await _service.GetByIdAsync(id.Value);
            if (provincia == null)
            {
                return NotFound();
            }
            ViewData["PaisId"] = new SelectList(_context.Pais, "Id", "Nome", provincia.PaisId);
            return View(provincia);
        }

        // POST: Provincias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Nome,PaisId")] Provincia provincia)
        {
            if (id != provincia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(provincia);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _service.ProvinciaExists(provincia.Id))
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
            ViewData["PaisId"] = new SelectList(_context.Pais, "Id", "Nome", provincia.PaisId);
            return View(provincia);
        }

        // GET: Provincias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            /*if (id == null || _context.Provincia == null)
            {
                return NotFound();
            }

            var provincia = await _context.Provincia
                .Include(p => p.Pais)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (provincia == null)
            {
                return NotFound();
            }

            return View(provincia);*/
            throw new NotImplementedException();
        }

        // POST: Provincias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*if (_context.Provincia == null)
            {
                return Problem("Entity set 'Context.Provincia'  is null.");
            }
            var provincia = await _context.Provincia.FindAsync(id);
            if (provincia != null)
            {
                _context.Provincia.Remove(provincia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));*/
            throw  new NotImplementedException(nameof(DeleteConfirmed));
        }

        
    }
}
