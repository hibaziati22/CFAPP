using CfAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CfAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitreFoncierController : ControllerBase
    {
       
        private readonly DataContext _context;

        public TitreFoncierController(DataContext context)
        {
            _context = context;
        }

    
        [HttpGet]
        public async Task<ActionResult<List<TitreFoncier>>> Get()
        {
            var titres = await _context.Titres.Include(t => t.Cf).ToListAsync();
            return Ok(titres);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TitreFoncier>> Get(int id)
        {
            var Titre = await _context.Titres.FindAsync(id);
            if (Titre == null)
                return BadRequest("Titre not found");
            return Ok(Titre);
        }

        [HttpPost]
        public async Task<ActionResult<List<TitreFoncier>>> AddTitre(TitreFoncier Titre)
        {
            _context.Titres.Add(Titre);
            await _context.SaveChangesAsync();

            return Ok(await _context.Titres.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<TitreFoncier>>> UpdateTitre(TitreFoncier request)
        {
            var dbTitre = await _context.Titres.FindAsync(request.Id);
            if (dbTitre == null)
                return BadRequest("Titre not found");

            dbTitre.Numero = request.Numero;

            dbTitre.Type = request.Type;


            dbTitre.Indice = request.Indice;

            dbTitre.IndiceSpecial = request.IndiceSpecial;

            await _context.SaveChangesAsync();

            return Ok(await _context.Titres.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TitreFoncier>>> Delete(int id)
        {
            var dbTitre = await _context.Titres.FindAsync(id);
            if (dbTitre == null)
                return BadRequest("Titre not found");

            _context.Titres.Remove(dbTitre);
            await _context.SaveChangesAsync();
            return Ok(await _context.Titres.ToListAsync());
        }

    }
}
