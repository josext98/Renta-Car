using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class MantenimientoController : BaseController
    {
        // GET: Mantenimiento
        public ActionResult Index()
        {
            var Marcas = Conection.Marcas.ToList();
            var Combustibles = Conection.Combustibles.ToList();
            var Modelos = Conection.Modelos.ToList();
            var tipodeVehiculos = Conection.TipodeVehiculo.ToList();

            var ListaVehiculos = Conection.Vehiculos.ToList().Where(c=> c.Estado == Vehiculos.Status.Disponible).Select(x => new Vehiculos()
            {
                Id = x.Id,
                NoChasis = x.NoChasis,
                Descripción = x.Descripción,
                NoPlaca = x.NoPlaca,
                Estado = x.Estado,
                TipoCombustibleName = Combustibles.Where(c => c.TipoId == x.TipoCombustibleId).Select(v => v.Descripcion).FirstOrDefault(),
                MarcaName = Marcas.Where(vc => vc.MarcaId == x.MarcaId).FirstOrDefault()?.MarcaName,
                TipoVehiculoName = tipodeVehiculos.Where(vc => vc.TipoId == x.TipoVehiculoId)?.FirstOrDefault().Descripcion,
                ModeloName = Modelos.Where(vc => vc.ModelosId == x.ModeloId).FirstOrDefault()?.ModelosName
            });

            return View(ListaVehiculos);
        }

        public ActionResult AddVehiculos()
        {
            ViewBag.Marca = Conection.Marcas.ToList();
            ViewBag.Modelo = Conection.Modelos.ToList();
            ViewBag.TipoVehiculo = Conection.TipodeVehiculo.ToList();
            ViewBag.TipoCombustible = Conection.Combustibles.ToList();

            return View();
        }


        public ActionResult AddModelos()
        {
            ViewBag.MarcaLista = Conection.Marcas.ToList();
            return View();
        }

        public ActionResult EditVehiculos(int? id, Boolean rent = false)
        {
            var veh = Conection.Vehiculos.Where(x => x.Id == id).First();

            ViewBag.Marca = Conection.Marcas.ToList();
            ViewBag.Modelo = Conection.Modelos.ToList();
            ViewBag.TipoVehiculo = Conection.TipodeVehiculo.ToList();
            ViewBag.TipoCombustible = Conection.Combustibles.ToList();

            return View(veh);
        }

        public ActionResult EditVehiculoAction(Vehiculos vh)
        {
            if (ModelState.IsValid)
            {
                Conection.Entry(vh).State = System.Data.Entity.EntityState.Modified;
                Conection.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult AddTiposCombustible()
        {
            return View();

        }

        public ActionResult AddMarcas()
        {
            return View();
        }

        public ActionResult AddTipoVehiculos()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateVehiculo(Vehiculos vh)
        {
            if (ModelState.IsValid)
            {
                if (Conection.Vehiculos.Any(x => x.NoPlaca == vh.NoPlaca || x.NoChasis == vh.NoChasis)) return View(vh); 

                Conection.Vehiculos.Add(new Vehiculos()
                {
                    NoChasis = vh.NoChasis,
                    Descripción = vh.Descripción,
                    NoPlaca = vh.NoPlaca,
                    TipoVehiculoId = vh.TipoVehiculoId,
                    MarcaId = vh.MarcaId,
                    ModeloId = vh.ModeloId,
                    TipoCombustibleId = vh.TipoCombustibleId,
                    Estado = vh.Estado
                });

                Conection.SaveChanges();
                return RedirectToAction("Index");
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Error por favor verifique informacion");
        }

        [HttpPost]
        public ActionResult CreateModelo(Modelos md)
        {
            if (ModelState.IsValid)
            {
                Conection.Modelos.Add(md);
            }

            Conection.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CreateMarcas(Marcas md)
        {

            if (ModelState.IsValid)
            {
                Conection.Marcas.Add(md);
            }

            Conection.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult CreateTipoCombustibles(Combustibles cb)
        {
            if (ModelState.IsValid)
            {
                Conection.Combustibles.Add(cb);
            }

            Conection.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CreateTipoVehiculos(TipodeVehiculo tp)
        {
            if (ModelState.IsValid)
            {
                Conection.TipodeVehiculo.Add(tp);
            }

            Conection.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Rentar(int id)
        {
           return EditVehiculos(id, true);
        }
    }
}