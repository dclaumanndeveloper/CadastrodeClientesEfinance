using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastrodeClientes.Data;
using CadastrodeClientes.Models;

namespace CadastrodeClientes.Controllers
{
    public class CidadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CidadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cidades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cidade.Include(e=> e.Estado).ToListAsync());
        }

        // GET: Cidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidade
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cidade == null)
            {
                return NotFound();
            }

            return View(cidade);
        }

        // GET: Cidades/Create
        public IActionResult Create()
        {
            ViewBag.Estados = new SelectList(_context.Estado.Where(e=> e.Ativo.Equals('S')).OrderBy(e=>e.Nome), "ID", "Nome");
            return View();
        }

        // POST: Cidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cidade cidade)
        {
                cidade.Estado = await _context.Estado.Where(e => e.ID == cidade.Estado.ID).FirstOrDefaultAsync();
                cidade.Ativo = 'S';
                _context.Add(cidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }

        // GET: Cidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidade.Include(e => e.Estado).Where( c=> c.ID == id).FirstOrDefaultAsync();
            if (cidade == null)
            {
                return NotFound();
            }
            ViewBag.Estados = new SelectList(_context.Estado.Where(e => e.Ativo.Equals('S')).OrderBy(e => e.Nome), "ID", "Nome",cidade.Estado.ID);
            return View(cidade);
        }

        // POST: Cidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cidade cidade)
        {
            if (id != cidade.ID)
            {
                return NotFound();
            }


            try
            {
                cidade.Estado = _context.Estado.Where(e => e.ID == cidade.Estado.ID).FirstOrDefault();
                _context.Update(cidade);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CidadeExists(cidade.ID))
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

        // GET: Cidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidade
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cidade == null)
            {
                return NotFound();
            }

            return View(cidade);
        }

        // POST: Cidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cidade = await _context.Cidade.FindAsync(id);
            cidade.Ativo = 'N';
            _context.Update(cidade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CidadeExists(int id)
        {
            return _context.Cidade.Any(e => e.ID == id);
        }
    }
}
