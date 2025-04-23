using PedidosApp.Clases;
using PedidosApp.Interfaces;
using PedidosApp.Listados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosApp.Factory
{
    public static class EntregaFactory
    {
        public static IMetodoEntrega CrearEntrega(string tipoProducto, bool urgente, double
        peso)
        {
            if (tipoProducto == NombreProductos.tecnologia.ToString() && urgente)
                return new EntregaDron();
            else if (tipoProducto == NombreProductos.componente.ToString() || peso > 10)
                return new EntregaCamion();
            else if (tipoProducto == NombreProductos.accesorio.ToString())
                return new EntregaMoto();
            else
                return new EntregaMoto(); 
        }
    }
}
