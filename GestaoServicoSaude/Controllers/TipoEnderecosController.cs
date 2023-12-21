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
    public class TipoEnderecosController : Controller
    {
        
        private readonly TipoEnderecoService _service;

        public TipoEnderecosController(TipoEnderecoService service)
        {
            _service = service; 
        }

        // GET: TipoEnderecoes
        public async Task<IActionResult> Index()
        {
              return View(await _service.GetAllAsync());
        }

        // GET: TipoEnderecoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var tipoEndereco = await _service.GetByIdAsync(id.Value);

            if (tipoEndereco == null)
            {
                return NotFound();
            }

            return View(tipoEndereco);
        }

        // GET: TipoEnderecoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoEnderecoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,Descricao")] TipoEndereco tipoEndereco)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(tipoEndereco);
                return RedirectToAction(nameof(Index));
            }
            return View(tipoEndereco);
        }

        // GET: TipoEnderecoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var tipoEndereco = await _service.GetByIdAsync(id.Value);
            
            if (tipoEndereco == null)
            {
                return NotFound();
            }
            
            return View(tipoEndereco);
        }

        // POST: TipoEnderecoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo,Descricao")] TipoEndereco tipoEndereco)
        {
            if (id != tipoEndereco.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(tipoEndereco);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _service.TipoEnderecoExists(tipoEndereco.Id))
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
            return View(tipoEndereco);
        }

        // GET: TipoEnderecoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            /*if (id == null || _context.TipoEndereco == null)
            {
                return NotFound();
            }

            var tipoEndereco = await _context.TipoEndereco
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoEndereco == null)
            {
                return NotFound();
            }

            return View(tipoEndereco);*/
            throw new NotImplementedException();
        }

        // POST: TipoEnderecoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*if (_context.TipoEndereco == null)
            {
                return Problem("Entity set 'Context.TipoEndereco'  is null.");
            }
            var tipoEndereco = await _context.TipoEndereco.FindAsync(id);
            if (tipoEndereco != null)
            {
                _context.TipoEndereco.Remove(tipoEndereco);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));*/
            throw new NotImplementedException(nameof(Index));
        }
    }
}
