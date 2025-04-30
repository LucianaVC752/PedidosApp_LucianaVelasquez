using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedidosApp
{
    public partial class VPedidos : Form
    {
        public VPedidos()
        {
            InitializeComponent();
            CaragarDatos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void VPedidos_Load(object sender, EventArgs e)
        {

        }

        private void CaragarDatos()
        {
            dataGridView1.Rows.Clear(); // Limpiamos antes de cargar
            var pedidos = RegistroPedidos.Instancia.Pedidos;

            foreach (var pedido in pedidos)
            {
                dataGridView1.Rows.Add(
                    pedido.Id,
                    pedido.Cliente,
                    pedido.Producto,
                    pedido.MetodoEntrega.TipoEntrega(),
                    pedido.Urgente ? "Sí" : "No",
                    pedido.ObtenerCosto().ToString("0.00"));
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalcularPedido calcularPedido = new CalcularPedido();
            calcularPedido.Show();
            this.Hide();
        }
    }
}