﻿using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
   public class CN_Negocio
    {
        private CD_Negocio objcd_negocio = new CD_Negocio();

        public Negocio ObtenerDatos()
        {
            return objcd_negocio.ObtenerDatos();
        }

        public bool GuardarDatos(Negocio obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Nombre == "")
            {
                Mensaje += "Hace falta el nombre para el negocio\n";

            }

            if (obj.NIT == "")
            {
                Mensaje += "Hace falta el NIT del negocio\n";

            }

            if (obj.Direccion == "")
            {
                Mensaje += "Hace falta la dirección del negocio\n";

            }

            if (Mensaje != string.Empty)
            {
                return false;

            }
            else
            {
                return objcd_negocio.GuardarDatos(obj, out Mensaje);
            }
        }

        public byte[] ObtenerLogo(out bool obtenido)
        {
            return objcd_negocio.ObtenerLogo(out obtenido);
        }

        public bool ActualizarLogo(byte[] imagen,out string mensaje)
        {
            return objcd_negocio.ActualizarLogo(imagen,out mensaje);
        }

    }
}
