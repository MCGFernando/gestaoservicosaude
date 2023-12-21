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
    public class TipoContactosController : Controller
    {
        //private readonly Context _context;
        private readonly TipoContactoService _service;
        public TipoContactosController(TipoContactoService service)
        {
            //_context = context;
            _service = service;
        }

        // GET: TipoContactoes
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        // GET: TipoContactoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoContacto = await _service.GetByIdAsync(id.Value);
            
            if (tipoContacto == null)
            {
                return NotFound();
            }

            return View(tipoContacto);
        }

        // GET: TipoContactoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoContactoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,Descricao")] TipoContacto tipoContacto)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(tipoContacto);    
                return RedirectToAction(nameof(Index));
            }
            return View(tipoContacto);
        }

        // GET: TipoContactoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoContacto = await _service.GetByIdAsync(id.Value);
            if (tipoContacto == null)
            {
                return NotFound();
            }
            return View(tipoContacto);
        }

        // POST: TipoContactoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo,Descricao")] TipoContacto tipoContacto)
        {
            if (id != tipoContacto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    await _service.UpdateAsync(tipoContacto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _service.TipoContactoExists(tipoContacto.Id))
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
            return View(tipoContacto);
        }

        // GET: TipoContactoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            /*if (id == null )
            {
                return NotFound();
            }

            var tipoContacto = await _context.TipoContacto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoContacto == null)
            {
                return NotFound();
            }
            
            return View(tipoContacto);*/
            throw new NotImplementedException();
        }

        // POST: TipoContactoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*if (_context.TipoContacto == null)
            {
                return Problem("Entity set 'Context.TipoContacto'  is null.");
            }
            var tipoContacto = await _context.TipoContacto.FindAsync(id);
            if (tipoContacto != null)
            {
                _context.TipoContacto.Remove(tipoContacto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));*/
            throw new NotImplementedException();
        }

        
    }
}
