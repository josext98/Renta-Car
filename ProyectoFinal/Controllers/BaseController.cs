using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class BaseController: Controller
    {
        public DataBaseConection Conection;

        public BaseController()
        {
            if(Conection == null)
            {
                Conection = new DataBaseConection();
            }
        }
    }
}