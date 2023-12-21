using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoServicoSaude.Data;
using GestaoServicoSaude.Models;

namespace GestaoServicoSaude.Controllers
{
    public class TipoEnderecoesController : Controller
    {
        private readonly Context _context;

        public TipoEnderecoesController(Context context)
        {
            _context = context;
        }

        // GET: TipoEnderecoes
        public async Task<IActionResult> Index()
        {

              return _context.TipoEndereco != null ? 
                          View(await _context.TipoEndereco.ToListAsync()) :
                          Problem("Entity set 'Context.TipoEndereco'  is null.");
        }

        // GET: TipoEnderecoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoEndereco == null)
            {
                return NotFound();
            }

            var tipoEndereco = await _context.TipoEndereco
                .FirstOrDefaultAsync(m => m.Id == id);
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
                _context.Add(tipoEndereco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoEndereco);
        }

        // GET: TipoEnderecoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoEndereco == null)
            {
                return NotFound();
            }

            var tipoEndereco = await _context.TipoEndereco.FindAsync(id);
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
                    _context.Update(tipoEndereco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoEnderecoExists(tipoEndereco.Id))
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
            if (id == null || _context.TipoEndereco == null)
            {
                return NotFound();
            }

            var tipoEndereco = await _context.TipoEndereco
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoEndereco == null)
            {
                return NotFound();
            }

            return View(tipoEndereco);
        }

        // POST: TipoEnderecoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoEndereco == null)
            {
                return Problem("Entity set 'Context.TipoEndereco'  is null.");
            }
            var tipoEndereco = await _context.TipoEndereco.FindAsync(id);
            if (tipoEndereco != null)
            {
                _context.TipoEndereco.Remove(tipoEndereco);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoEnderecoExists(int id)
        {
          return (_context.TipoEndereco?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
