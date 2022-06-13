using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KcomoAPI.Models;

namespace KcomoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedoresController : ControllerBase
    {
        private readonly KcomoContext _context;

        public VendedoresController(KcomoContext context)
        {
            _context = context;
        }

        // GET: api/Vendedores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendedores>>> GetVendedores()
        {
            return await _context.Vendedores.Where(z => z.Habilitado == true).ToListAsync();
        }

        // GET: api/Vendedores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vendedores>> GetVendedores(Guid id)
        {
            var vendedores = await _context.Vendedores.FindAsync(id);

            if (vendedores == null)
            {
                return NotFound();
            }

            return vendedores;
        }

        // PUT: api/Vendedores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendedores(Guid id, VendedoresDTO vdto)
        {
            var vendedores = new Vendedores();
            vendedores.SetVendedoresByDTO(vdto);
            vendedores.IdVendedor = id;

            _context.Entry(vendedores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendedoresExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vendedores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vendedores>> PostVendedores(VendedoresDTO vdto)
        {
            var vendedores = new Vendedores();
            vendedores.SetVendedoresByDTO(vdto);

            _context.Vendedores.Add(vendedores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendedores", new { id = vendedores.IdVendedor }, vendedores);
        }

        // DELETE: api/Vendedores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendedores(Guid id)
        {
            var vendedores = await _context.Vendedores.FindAsync(id);
            if (vendedores == null)
            {
                return NotFound();
            }

            _context.Vendedores.Remove(vendedores);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VendedoresExists(Guid id)
        {
            return _context.Vendedores.Any(e => e.IdVendedor == id);
        }
    }
}
