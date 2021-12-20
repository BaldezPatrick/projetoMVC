using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgenciaViagem.Models;

namespace AgenciaViagem.Controllers
{
    public class CompraClientesController : Controller
    {
        private readonly Context _context;

        public CompraClientesController(Context context)
        {
            _context = context;
        }

        // GET: CompraClientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.compraClientes.ToListAsync());
        }

        // GET: CompraClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraCliente = await _context.compraClientes
                .FirstOrDefaultAsync(m => m.Id_compra == id);
            if (compraCliente == null)
            {
                return NotFound();
            }

            return View(compraCliente);
        }

        // GET: CompraClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompraClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_compra,nome_cliente,sobrenome_cliente,local_partida,local_chegada,dia_ida,dia_chegada,qtd_passagem,num_assento")] CompraCliente compraCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compraCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(compraCliente);
        }

        // GET: CompraClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraCliente = await _context.compraClientes.FindAsync(id);
            if (compraCliente == null)
            {
                return NotFound();
            }
            return View(compraCliente);
        }

        // POST: CompraClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_compra,nome_cliente,sobrenome_cliente,local_partida,local_chegada,dia_ida,dia_chegada,qtd_passagem,num_assento")] CompraCliente compraCliente)
        {
            if (id != compraCliente.Id_compra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compraCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraClienteExists(compraCliente.Id_compra))
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
            return View(compraCliente);
        }

        // GET: CompraClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraCliente = await _context.compraClientes
                .FirstOrDefaultAsync(m => m.Id_compra == id);
            if (compraCliente == null)
            {
                return NotFound();
            }

            return View(compraCliente);
        }

        // POST: CompraClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compraCliente = await _context.compraClientes.FindAsync(id);
            _context.compraClientes.Remove(compraCliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraClienteExists(int id)
        {
            return _context.compraClientes.Any(e => e.Id_compra == id);
        }
    }
}
