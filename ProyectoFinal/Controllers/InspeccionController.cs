﻿using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IronPdf;
using System.IO;

namespace ProyectoFinal.Controllers
{
    public class InspeccionController : BaseController
    {
        // GET: Inspeccion
        public ActionResult Index()
        {
            return View(Conection.Pedido.ToList().Where(x=> x.Estado == PedidoRenta.RentaEstado.Rentado));
        }

        public ActionResult AddRentar(int id)
        {
            //ViewBag.Matricula = 

            //ViewBag.Matriculas = Conection.Vehiculos.ToList();
            ViewBag.Empleados = Conection.Empleados.ToList();
            ViewBag.Clientes = Conection.Clientes.ToList();

            var model = new PedidoRenta()
            {
                MatriculaVehiculo = Conection.Vehiculos.Where(x => x.Id == id).First().NoChasis
            };

            return View(model);
        }

        public ActionResult SaveRent(PedidoRenta pedidoRenta)
        {
            {
                pedidoRenta.Estado = PedidoRenta.RentaEstado.Rentado;
                pedidoRenta.FechaSalida = DateTime.Now.ToString("dd/mm/yyy");

                Conection.Pedido.Add(pedidoRenta);
                //Conection.SaveChanges();

                UpdatcarStatus(pedidoRenta.MatriculaVehiculo, Vehiculos.Status.Rentado, 1);
            }
            return Redirect("Index");
        }

        public ActionResult Inspeccion()
        {
            return View();
        }

        public ActionResult PantallaInspeccion(int id)
        {

            ViewBag.Empleados = Conection.Empleados.ToList();
            var Process = Conection.Pedido.Where(x => x.ProcesoId == id).FirstOrDefault();
            
            var model = new InspeccionTable()
            {
                Matricula = Process.MatriculaVehiculo,
                Cliente = Process.CodeCliente
            };

            return View(model);
        }

        public ActionResult ValidarCar(InspeccionTable Value)
        {
            if(Value.Frenos && Value.Gomas && Value.Puertas && Value.Combustible == InspeccionTable.EstadoTanque.Full)
            {
                Conection.InspeccionTable.Add(Value);
                Value.Fecha_Proceso = DateTime.Now;
                UpdatcarStatus(Value.Matricula, Vehiculos.Status.Disponible, 2);
            }
            else
            {
                UpdatcarStatus(Value.Matricula, Vehiculos.Status.Inspeccion, 2);
            }

            return RedirectToAction("Index","Mantenimiento");
        }


        public void UpdatcarStatus(string car, Vehiculos.Status status, int Step)
        {

            switch (Step)
            {
                case 1:
                    var carro = Conection.Vehiculos.Where(x => x.NoChasis == car).FirstOrDefault();
                    carro.Estado = status;
                    Conection.Entry(carro).State = System.Data.Entity.EntityState.Modified;

                    break;

                case 2:
                    var pedido = Conection.Pedido.Where(x => x.MatriculaVehiculo == car).FirstOrDefault();
                    pedido.Estado = PedidoRenta.RentaEstado.Liberado;
                    Conection.Entry(pedido).State = System.Data.Entity.EntityState.Modified;

                    carro = Conection.Vehiculos.Where(x => x.NoChasis == car).FirstOrDefault();
                    carro.Estado = status;
                    Conection.Entry(carro).State = System.Data.Entity.EntityState.Modified;

                    break;
                default:
                    break;
            }

  
            Conection.SaveChanges();
        }

        public ActionResult PdfPrinter()
        {
            var htmlToPdf = new HtmlToPdf();

            var html = @"<h1>Hello World!</h1><br><p>This is IronPdf.</p>";
            // turn html to pdf
            var pdf = htmlToPdf.RenderHtmlAsPdf(html);
            // save resulting pdf into file
            pdf.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "HtmlToPdf.Pdf"));


            return View();
        }
      
    }
}