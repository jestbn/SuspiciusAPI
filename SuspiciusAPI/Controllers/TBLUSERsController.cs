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
    public class TBLUSERsController : ApiController
    {
        private SuspiciusDBEntities db = new SuspiciusDBEntities();

        // GET: api/TBLUSERs
        public IQueryable<TBLUSER> GetTBLUSER()
        {
            return db.TBLUSER;
        }

        // GET: api/TBLUSERs/5
        [ResponseType(typeof(TBLUSER))]
        public IHttpActionResult GetTBLUSER(int id)
        {
            TBLUSER tBLUSER = db.TBLUSER.Find(id);
            if (tBLUSER == null)
            {
                return NotFound();
            }

            return Ok(tBLUSER);
        }

        // PUT: api/TBLUSERs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTBLUSER(int id, TBLUSER tBLUSER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tBLUSER.ID)
            {
                return BadRequest();
            }

            db.Entry(tBLUSER).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TBLUSERExists(id))
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

        // POST: api/TBLUSERs
        [ResponseType(typeof(TBLUSER))]
        public IHttpActionResult PostTBLUSER(TBLUSER tBLUSER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TBLUSER.Add(tBLUSER);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tBLUSER.ID }, tBLUSER);
        }

        // DELETE: api/TBLUSERs/5
        [ResponseType(typeof(TBLUSER))]
        public IHttpActionResult DeleteTBLUSER(int id)
        {
            TBLUSER tBLUSER = db.TBLUSER.Find(id);
            if (tBLUSER == null)
            {
                return NotFound();
            }

            db.TBLUSER.Remove(tBLUSER);
            db.SaveChanges();

            return Ok(tBLUSER);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TBLUSERExists(int id)
        {
            return db.TBLUSER.Count(e => e.ID == id) > 0;
        }
    }
}