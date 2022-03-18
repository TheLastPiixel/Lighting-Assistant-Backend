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
    public class MovementsController : ApiController
    {
        private LightingAssistantContext db = new LightingAssistantContext();

        // GET: api/Movements
        public IQueryable<Movements> GetMovements()
        {
            return db.Movements;
        }

        // GET: api/Movements/5
        [ResponseType(typeof(Movements))]
        public async Task<IHttpActionResult> GetMovements(string id)
        {
            Movements movements = await db.Movements.FindAsync(id);
            if (movements == null)
            {
                return NotFound();
            }

            return Ok(movements);
        }

        // PUT: api/Movements/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMovements(string id, Movements movements)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movements.Movement)
            {
                return BadRequest();
            }

            db.Entry(movements).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovementsExists(id))
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

        // POST: api/Movements
        [ResponseType(typeof(Movements))]
        public async Task<IHttpActionResult> PostMovements(Movements movements)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Movements.Add(movements);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MovementsExists(movements.Movement))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = movements.Movement }, movements);
        }

        // DELETE: api/Movements/5
        [ResponseType(typeof(Movements))]
        public async Task<IHttpActionResult> DeleteMovements(string id)
        {
            Movements movements = await db.Movements.FindAsync(id);
            if (movements == null)
            {
                return NotFound();
            }

            db.Movements.Remove(movements);
            await db.SaveChangesAsync();

            return Ok(movements);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovementsExists(string id)
        {
            return db.Movements.Count(e => e.Movement == id) > 0;
        }
    }
}