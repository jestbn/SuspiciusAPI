using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AccesoDatos;

namespace SuspiciusAPI.Controllers
{
    public class TBLEVENTOesController : ApiController
    {
        private SuspiciusDBEntities db = new SuspiciusDBEntities();

        // GET: api/TBLEVENTOes
        public IQueryable<TBLEVENTO> GetTBLEVENTO()
        {
            return db.TBLEVENTO;
        }

        // GET: api/TBLEVENTOes/5
        [ResponseType(typeof(TBLEVENTO))]
        public IHttpActionResult GetTBLEVENTO(int id)
        {
            TBLEVENTO tBLEVENTO = db.TBLEVENTO.Find(id);
            if (tBLEVENTO == null)
            {
                return NotFound();
            }

            return Ok(tBLEVENTO);
        }

        // PUT: api/TBLEVENTOes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTBLEVENTO(int id, TBLEVENTO tBLEVENTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tBLEVENTO.id_evento)
            {
                return BadRequest();
            }

            db.Entry(tBLEVENTO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TBLEVENTOExists(id))
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

        // POST: api/TBLEVENTOes
        [ResponseType(typeof(TBLEVENTO))]
        public IHttpActionResult PostTBLEVENTO(TBLEVENTO tBLEVENTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TBLEVENTO.Add(tBLEVENTO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tBLEVENTO.id_evento }, tBLEVENTO);
        }

        // DELETE: api/TBLEVENTOes/5
        [ResponseType(typeof(TBLEVENTO))]
        public IHttpActionResult DeleteTBLEVENTO(int id)
        {
            TBLEVENTO tBLEVENTO = db.TBLEVENTO.Find(id);
            if (tBLEVENTO == null)
            {
                return NotFound();
            }

            db.TBLEVENTO.Remove(tBLEVENTO);
            db.SaveChanges();

            return Ok(tBLEVENTO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TBLEVENTOExists(int id)
        {
            return db.TBLEVENTO.Count(e => e.id_evento == id) > 0;
        }
    }
}