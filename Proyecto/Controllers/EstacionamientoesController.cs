using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class EstacionamientoesController : Controller
    {
        private EstacionamientoDB db = new EstacionamientoDB();

        // GET: Estacionamientoes
        public async Task<ActionResult> Index()
        {
            return View(await db.Estacionamiento.ToListAsync());
        }

        // GET: Estacionamientoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estacionamiento estacionamiento = await db.Estacionamiento.FindAsync(id);
            if (estacionamiento == null)
            {
                return HttpNotFound();
            }
            return View(estacionamiento);
        }

        // GET: Estacionamientoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estacionamientoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EstacionamientoID,Fecha,Nivel")] Estacionamiento estacionamiento)
        {
            if (ModelState.IsValid)
            {
                db.Estacionamiento.Add(estacionamiento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(estacionamiento);
        }

        // GET: Estacionamientoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estacionamiento estacionamiento = await db.Estacionamiento.FindAsync(id);
            if (estacionamiento == null)
            {
                return HttpNotFound();
            }
            return View(estacionamiento);
        }

        // POST: Estacionamientoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EstacionamientoID,Fecha,Nivel")] Estacionamiento estacionamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estacionamiento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(estacionamiento);
        }

        // GET: Estacionamientoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estacionamiento estacionamiento = await db.Estacionamiento.FindAsync(id);
            if (estacionamiento == null)
            {
                return HttpNotFound();
            }
            return View(estacionamiento);
        }

        // POST: Estacionamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Estacionamiento estacionamiento = await db.Estacionamiento.FindAsync(id);
            db.Estacionamiento.Remove(estacionamiento);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
