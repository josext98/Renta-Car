using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class PersonasController : BaseController
    {
        // GET: Personas
        public ActionResult Index()
        {
            return View(Conection.Clientes.ToList());
        }

        // GET: Personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = Conection.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonaId,Nombre,Cedula,Telefono,NoTarjetaCr,LímiteCredito,TipoPersona,Email")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                Conection.Clientes.Add(clientes);
                Conection.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientes);
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = Conection.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonaId,Nombre,Cedula,Telefono,NoTarjetaCr,LímiteCredito,TipoPersona,Email")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                Conection.Entry(clientes).State = EntityState.Modified;
                Conection.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientes);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = Conection.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clientes clientes = Conection.Clientes.Find(id);
            Conection.Clientes.Remove(clientes);
            Conection.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult ListadoClientes()
        {
            return View(Conection.Clientes.ToList());
        }

        public ActionResult ListadoEmpleados()
        {
            return View(Conection.Empleados.ToList());
        }

    
        public ActionResult SaveEmpleado(Empleados emp)
        {

            if (ModelState.IsValid)
            {
                emp.FechaIngreso = DateTime.Now;
                Conection.Empleados.Add(emp);
                Conection.SaveChanges();
            }

            return RedirectToAction("ListadoEmpleados");
        }

        public ActionResult SaveCliente(Clientes emp)
        {
            if (ModelState.IsValid)
            {
                Conection.Clientes.Add(emp);
                Conection.SaveChanges();
            }

            return RedirectToAction("ListadoClientes");
        }
        public ActionResult CreateCliente()
        {
            return View();
        }
        public ActionResult CreateEmpleado(Empleados emp)
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Conection.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
