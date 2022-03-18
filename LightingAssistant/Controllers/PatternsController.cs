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
    public class PatternsController : ApiController
    {
        private LightingAssistantContext db = new LightingAssistantContext();

        // GET: api/Patterns
        public IQueryable<Patterns> GetPatterns()
        {
            return db.Patterns;
        }

        // GET: api/Patterns/5
        [ResponseType(typeof(Patterns))]
        public async Task<IHttpActionResult> GetPatterns(string id)
        {
            Patterns patterns = await db.Patterns.FindAsync(id);
            if (patterns == null)
            {
                return NotFound();
            }

            return Ok(patterns);
        }

        // PUT: api/Patterns/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPatterns(string id, Patterns patterns)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patterns.Pattern)
            {
                return BadRequest();
            }

            db.Entry(patterns).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatternsExists(id))
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

        // POST: api/Patterns
        [ResponseType(typeof(Patterns))]
        public async Task<IHttpActionResult> PostPatterns(Patterns patterns)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Patterns.Add(patterns);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PatternsExists(patterns.Pattern))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = patterns.Pattern }, patterns);
        }

        // DELETE: api/Patterns/5
        [ResponseType(typeof(Patterns))]
        public async Task<IHttpActionResult> DeletePatterns(string id)
        {
            Patterns patterns = await db.Patterns.FindAsync(id);
            if (patterns == null)
            {
                return NotFound();
            }

            db.Patterns.Remove(patterns);
            await db.SaveChangesAsync();

            return Ok(patterns);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatternsExists(string id)
        {
            return db.Patterns.Count(e => e.Pattern == id) > 0;
        }
    }
}