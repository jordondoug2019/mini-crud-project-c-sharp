using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GamesApi.Models;

namespace GamesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GamesContext _context;

        public GamesController(GamesContext context)
        {
            _context = context;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GamesModel>>> GetGamesList()
        {
            return await _context.GamesList.ToListAsync();
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GamesModel>> GetGamesModel(long id)
        {
            var gamesModel = await _context.GamesList.FindAsync(id);

            if (gamesModel == null)
            {
                return NotFound();
            }

            return gamesModel;
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGamesModel(long id, GamesModel gamesModel)
        {
            if (id != gamesModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(gamesModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GamesModelExists(id))
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

        // POST: api/Games
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<GamesModel>> PostGamesModel(GamesModel gamesModel)
        {
            _context.GamesList.Add(gamesModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGamesModel", new { id = gamesModel.Id }, gamesModel);
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GamesModel>> DeleteGamesModel(long id)
        {
            var gamesModel = await _context.GamesList.FindAsync(id);
            if (gamesModel == null)
            {
                return NotFound();
            }

            _context.GamesList.Remove(gamesModel);
            await _context.SaveChangesAsync();

            return gamesModel;
        }

        private bool GamesModelExists(long id)
        {
            return _context.GamesList.Any(e => e.Id == id);
        }
    }
}
