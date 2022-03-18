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
    public class ShowsController : ApiController
    {
        private LightingAssistantContext db = new LightingAssistantContext();

        // GET: api/Shows
        public IQueryable<Show> GetShows()
        {
            return db.Shows;
        }

        // GET: api/Shows/5
        [ResponseType(typeof(Show))]
        public async Task<IHttpActionResult> GetShow(int id)
        {
            Show show = await db.Shows.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }

            return Ok(show);
        }

        // PUT: api/Shows/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutShow(int id, Show show)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != show.ShowID)
            {
                return BadRequest();
            }

            db.Entry(show).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowExists(id))
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

        // POST: api/Shows
        [ResponseType(typeof(Show))]
        public async Task<IHttpActionResult> PostShow(Show show)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Shows.Add(show);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = show.ShowID }, show);
        }

        // DELETE: api/Shows/5
        [ResponseType(typeof(Show))]
        public async Task<IHttpActionResult> DeleteShow(int id)
        {
            Show show = await db.Shows.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }

            db.Shows.Remove(show);
            await db.SaveChangesAsync();

            return Ok(show);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShowExists(int id)
        {
            return db.Shows.Count(e => e.ShowID == id) > 0;
        }
    }
}