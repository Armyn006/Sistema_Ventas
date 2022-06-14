using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
   public class CN_Proveedor
    {

        private CD_Proveedor objcd_Proveedor = new CD_Proveedor();

        public List<Proveedor> Listar()
        {
            return objcd_Proveedor.Listar();
        }

        public int Registrar(Proveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Hace falta el Documento para el Proveedor\n";

            }

            if (obj.RazonSocial == "")
            {
                Mensaje += "Hace falta la razon social del Proveedor\n";

            }

            if (obj.Telefono == "")
            {
                Mensaje += "Hace falta un Telefono para el Proveedor\n";

            }

            if (Mensaje != string.Empty)
            {
                return 0;

            }
            else
            {
                return objcd_Proveedor.Registrar(obj, out Mensaje);
            }

        }

        public bool Editar(Proveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Hace falta el Documento para el Proveedor\n";

            }

            if (obj.RazonSocial == "")
            {
                Mensaje += "Hace falta la razon social del Proveedor\n";

            }

            if (obj.Correo == "")
            {
                Mensaje += "Hace falta un Correo para el Proveedor\n";

            }

            if (Mensaje != string.Empty)
            {
                return false;

            }
            else
            {
                return objcd_Proveedor.Editar(obj, out Mensaje);
            }

        }


        public bool Eliminar(Proveedor obj, out string Mensaje)
        {
            return objcd_Proveedor.Eliminar(obj, out Mensaje);
        }
    }

}

