using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AgenciaViagem.Models
{
    public class ContatoClientesController : Controller
    {
        private readonly Context _context;

        public ContatoClientesController(Context context)
        {
            _context = context;
        }

        // GET: ContatoClientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.contatoClientes.ToListAsync());
        }

        // GET: ContatoClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contatoCliente = await _context.contatoClientes
                .FirstOrDefaultAsync(m => m.Id_contato == id);
            if (contatoCliente == null)
            {
                return NotFound();
            }

            return View(contatoCliente);
        }

        // GET: ContatoClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContatoClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_contato,nome_contato,sobrenome_contato,telefone_contato,cidade_contato,regiao_contato,email_contato,motivo_contato")] ContatoCliente contatoCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contatoCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contatoCliente);
        }

        // GET: ContatoClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contatoCliente = await _context.contatoClientes.FindAsync(id);
            if (contatoCliente == null)
            {
                return NotFound();
            }
            return View(contatoCliente);
        }

        // POST: ContatoClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_contato,nome_contato,sobrenome_contato,telefone_contato,cidade_contato,regiao_contato,email_contato,motivo_contato")] ContatoCliente contatoCliente)
        {
            if (id != contatoCliente.Id_contato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contatoCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContatoClienteExists(contatoCliente.Id_contato))
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
            return View(contatoCliente);
        }

        // GET: ContatoClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contatoCliente = await _context.contatoClientes
                .FirstOrDefaultAsync(m => m.Id_contato == id);
            if (contatoCliente == null)
            {
                return NotFound();
            }

            return View(contatoCliente);
        }

        // POST: ContatoClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contatoCliente = await _context.contatoClientes.FindAsync(id);
            _context.contatoClientes.Remove(contatoCliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContatoClienteExists(int id)
        {
            return _context.contatoClientes.Any(e => e.Id_contato == id);
        }
    }
}
