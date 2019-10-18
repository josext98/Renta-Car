using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ProyectoFinal
{
    public class CommonUtil
    {

        public static Boolean ValidaCedula(String Cedula)
        {
            if (Cedula == null) return false;

            Cedula = Regex.Replace(Cedula, "[^0-9]", string.Empty); // Only keep #s.          

            if (Cedula.Equals(null) || !Cedula.Length.Equals(11) || long.Parse(Cedula).Equals(0))
            {
                return false;
            }

            // Validate.
            int sum = 0;
            for (int i = 0; i < 10; ++i)
            {
                int n = ((i + 1) % 2 != 0 ? 1 : 2) * int.Parse(Cedula.Substring(i, 1));
                sum += (n <= 9 ? n : n % 10 + 1);
            }
            int dig = ((10 - sum % 10) % 10);
            return (dig.Equals(int.Parse(Cedula.Substring(10, 1))) ? true : false);
        }

        /// <summary>
        /// Metodo para validar si un RNC es Valido.
        /// </summary>
        /// <param name="Rnc">Numero de RNC</param>
        /// <returns>Resultado</returns>
        public static Boolean ValidaRNC(String Rnc)
        {
            Rnc = Regex.Replace(Rnc, "[^0-9]", string.Empty);

            if (!Rnc.Length.Equals(9) || long.Parse(Rnc).Equals(0))
            {
                return false;
            }

            // Validate.
            int sum = 0;
            for (int i = 0; i < 8; ++i)
            {
                sum += int.Parse(Rnc.Substring(i, 1)) * int.Parse("79865432".Substring(i, 1));
            }
            int div = sum / 11;
            int res = sum - (div * 11);
            int dig = (res > 1 ? 11 - res : (res.Equals(0) ? 2 : 1));
            return (dig.Equals(int.Parse(Rnc.Substring(8, 1))) ? true : false);
        }
    }
}