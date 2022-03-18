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
    public class ColoursController : ApiController
    {
        private LightingAssistantContext db = new LightingAssistantContext();

        // GET: api/Colours
        public IQueryable<Colours> GetColours()
        {
            return db.Colours;
        }

        // GET: api/Colours/5
        [ResponseType(typeof(Colours))]
        public async Task<IHttpActionResult> GetColours(string id)
        {
            Colours colours = await db.Colours.FindAsync(id);
            if (colours == null)
            {
                return NotFound();
            }

            return Ok(colours);
        }

        // PUT: api/Colours/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutColours(string id, Colours colours)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != colours.Colour)
            {
                return BadRequest();
            }

            db.Entry(colours).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColoursExists(id))
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

        // POST: api/Colours
        [ResponseType(typeof(Colours))]
        public async Task<IHttpActionResult> PostColours(Colours colours)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Colours.Add(colours);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ColoursExists(colours.Colour))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = colours.Colour }, colours);
        }

        // DELETE: api/Colours/5
        [ResponseType(typeof(Colours))]
        public async Task<IHttpActionResult> DeleteColours(string id)
        {
            Colours colours = await db.Colours.FindAsync(id);
            if (colours == null)
            {
                return NotFound();
            }

            db.Colours.Remove(colours);
            await db.SaveChangesAsync();

            return Ok(colours);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ColoursExists(string id)
        {
            return db.Colours.Count(e => e.Colour == id) > 0;
        }
    }
}