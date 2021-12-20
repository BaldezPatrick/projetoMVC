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
    public class CadastrarClientesController : Controller
    {
        private readonly Context _context;

        public CadastrarClientesController(Context context)
        {
            _context = context;
        }

        // GET: CadastrarClientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.cadastrarClientes.ToListAsync());
        }

        // GET: CadastrarClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastrarCliente = await _context.cadastrarClientes
                .FirstOrDefaultAsync(m => m.Id_cliente == id);
            if (cadastrarCliente == null)
            {
                return NotFound();
            }

            return View(cadastrarCliente);
        }

        // GET: CadastrarClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastrarClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_cliente,nome_cliente,sobrenome_cliente,data_nasc_cliente,endereco_cliente,telefone_cliente,cidade_cliente,email_cliente")] CadastrarCliente cadastrarCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastrarCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastrarCliente);
        }

        // GET: CadastrarClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastrarCliente = await _context.cadastrarClientes.FindAsync(id);
            if (cadastrarCliente == null)
            {
                return NotFound();
            }
            return View(cadastrarCliente);
        }

        // POST: CadastrarClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_cliente,nome_cliente,sobrenome_cliente,data_nasc_cliente,endereco_cliente,telefone_cliente,cidade_cliente,email_cliente")] CadastrarCliente cadastrarCliente)
        {
            if (id != cadastrarCliente.Id_cliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastrarCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastrarClienteExists(cadastrarCliente.Id_cliente))
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
            return View(cadastrarCliente);
        }

        // GET: CadastrarClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastrarCliente = await _context.cadastrarClientes
                .FirstOrDefaultAsync(m => m.Id_cliente == id);
            if (cadastrarCliente == null)
            {
                return NotFound();
            }

            return View(cadastrarCliente);
        }

        // POST: CadastrarClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastrarCliente = await _context.cadastrarClientes.FindAsync(id);
            _context.cadastrarClientes.Remove(cadastrarCliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastrarClienteExists(int id)
        {
            return _context.cadastrarClientes.Any(e => e.Id_cliente == id);
        }
    }
}
