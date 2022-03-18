using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LightingAssistant.Models;
using System.Web.Http.Cors;

namespace LightingAssistant.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class PositionsController : ApiController
    {
        private LightingAssistantContext db = new LightingAssistantContext();

        // GET: api/Positions
        public IQueryable<Positions> GetPositions()
        {
            return db.Positions;
        }

        // GET: api/Positions/5
        [ResponseType(typeof(Positions))]
        public async Task<IHttpActionResult> GetPositions(string id)
        {
            Positions positions = await db.Positions.FindAsync(id);
            if (positions == null)
            {
                return NotFound();
            }

            return Ok(positions);
        }

        // PUT: api/Positions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPositions(string id, Positions positions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != positions.Position)
            {
                return BadRequest();
            }

            db.Entry(positions).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PositionsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Positions
        [ResponseType(typeof(Positions))]
        public async Task<IHttpActionResult> PostPositions(Positions positions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Positions.Add(positions);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PositionsExists(positions.Position))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = positions.Position }, positions);
        }

        // DELETE: api/Positions/5
        [ResponseType(typeof(Positions))]
        public async Task<IHttpActionResult> DeletePositions(string id)
        {
            Positions positions = await db.Positions.FindAsync(id);
            if (positions == null)
            {
                return NotFound();
            }

            db.Positions.Remove(positions);
            await db.SaveChangesAsync();

            return Ok(positions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PositionsExists(string id)
        {
            return db.Positions.Count(e => e.Position == id) > 0;
        }
    }
}