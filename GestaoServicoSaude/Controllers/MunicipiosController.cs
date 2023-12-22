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
    public class MunicipiosController : Controller
    {
        private readonly Context _context;
        private readonly MunicipioService _service;

        public MunicipiosController(Context context, MunicipioService service)
        {
            _context = context;
            _service = service;
        }

        // GET: Municipios
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        // GET: Municipios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var municipio = await _service.GetByIdAsync(id.Value);

            if (municipio == null)
            {
                return NotFound();
            }

            return View(municipio);
        }

        // GET: Municipios/Create
        public IActionResult Create()
        {
            ViewData["PaisId"] = new SelectList(_context.Pais, "Id", "Nome",1);
            ViewData["ProvinciaId"] = new SelectList(_context.Provincia, "Id", "Nome", 1, "PaisId");
            return View();
        }

        // POST: Municipios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Nome,ProvinciaId")] Municipio municipio)
        {
            if (ModelState.IsValid)
            {

                await _service.AddAsync(municipio);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProvinciaId"] = new SelectList(_context.Provincia, "Id", "Nome", municipio.ProvinciaId);
            return View(municipio);
        }

        // GET: Municipios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipio = await _service.GetByIdAsync(id.Value);

            if (municipio == null)
            {
                return NotFound();
            }
            ViewData["ProvinciaId"] = new SelectList(_context.Provincia, "Id", "Nome", municipio.ProvinciaId);
            return View(municipio);
        }

        // POST: Municipios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Nome,ProvinciaId")] Municipio municipio)
        {
            if (id != municipio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(municipio);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _service.MunicipioExists(municipio.Id))
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
            ViewData["ProvinciaId"] = new SelectList(_context.Provincia, "Id", "Id", municipio.ProvinciaId);
            return View(municipio);
        }

        // GET: Municipios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            /*if (id == null || _context.Municipio == null)
            {
                return NotFound();
            }

            var municipio = await _context.Municipio
                .Include(m => m.Provincia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (municipio == null)
            {
                return NotFound();
            }

            return View(municipio);*/
            throw new NotImplementedException();
        }

        // POST: Municipios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*if (_context.Municipio == null)
            {
                return Problem("Entity set 'Context.Municipio'  is null.");
            }
            var municipio = await _context.Municipio.FindAsync(id);
            if (municipio != null)
            {
                _context.Municipio.Remove(municipio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));*/
            throw new NotImplementedException();
        }

        /* Requests Adicionais */

        [HttpGet]
        public IActionResult GetProvinciasPorPaisId(int paisId)
        {
            // Consulta no banco de dados para obter as províncias com base no PaisId
            var provincias = _service.GetProvinciasByPaisIdAsync(paisId);

            // Retorna as províncias no formato JSON
            return Json(provincias);
        }
    }
}
