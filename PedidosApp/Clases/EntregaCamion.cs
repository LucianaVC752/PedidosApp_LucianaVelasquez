using PedidosApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosApp.Clases
{
    public class EntregaCamion : IMetodoEntrega
    {
        public double CalcularCosto(int km) => 5 * km;
        public string TipoEntrega() => "camion";
    }
}
