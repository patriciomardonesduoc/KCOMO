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
    public class PublicacionesController : ControllerBase
    {
        private readonly KcomoContext _context;

        public PublicacionesController(KcomoContext context)
        {
            _context = context;
        }

        // GET: api/Publicaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publicaciones>>> GetPublicaciones()
        {
            return await _context.Publicaciones.ToListAsync();
        }


        // GET: api/Publicaciones/5
        [HttpGet("Id/{id}")]
        public async Task<ActionResult<Publicaciones>> GetPublicaciones(Guid id)
        {
            var publicaciones = await _context.Publicaciones.FindAsync(id);

            if (publicaciones == null)
            {
                return NotFound();
            }

            return publicaciones;
        }

                // GET: api/Publicaciones/5
        [HttpGet("Vendedor/{idVendedor}")]
        public async Task<ActionResult<IEnumerable<Publicaciones>>> GetPublicacionesByVendedor(Guid idVendedor)
        {
            var publicaciones = await _context.Publicaciones.Where(x => x.IdVendedor == idVendedor && x.Habilitado == true).ToListAsync();

            if (publicaciones == null)
            {
                return NotFound();
            }

            return publicaciones;
        }

        // PUT: api/Publicaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublicaciones(Guid id, PublicacionesDTO pdto)
        {

            var publicaciones = new Publicaciones();
            publicaciones.SetPublicacionByDTO(pdto);
            publicaciones.IdPublicacion = id;


            _context.Entry(publicaciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicacionesExists(id))
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

        // POST: api/Publicaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Publicaciones>> PostPublicaciones(PublicacionesDTO publicacionesDTO)
        {
            var publicaciones = new Publicaciones();
            publicaciones.SetPublicacionByDTO(publicacionesDTO);

            _context.Publicaciones.Add(publicaciones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublicaciones", new { id = publicaciones.IdPublicacion }, publicaciones);
        }

        // DELETE: api/Publicaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublicaciones(Guid id)
        {
            var publicaciones = await _context.Publicaciones.FindAsync(id);
            if (publicaciones == null)
            {
                return NotFound();
            }

            _context.Publicaciones.Remove(publicaciones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PublicacionesExists(Guid id)
        {
            return _context.Publicaciones.Any(e => e.IdPublicacion == id);
        }
    }
}
