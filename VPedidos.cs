using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PedidosApp.Listados;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PedidosApp
{
    public partial class VPedidos : Form
    {
        public VPedidos()
        {
            InitializeComponent();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void VPedidos_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add(TiposDeEntregas.camion.ToString());
            comboBox1.Items.Add(TiposDeEntregas.bicicleta.ToString());
            comboBox1.Items.Add(TiposDeEntregas.dron.ToString());
            comboBox1.Items.Add(TiposDeEntregas.motocicleta.ToString());
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string metodoViaje = comboBox1.SelectedItem.ToString();// Obtén el texto a buscar
            var pedidos = RegistroPedidos.Instancia.Pedidos;
            var elementosFiltrados = pedidos
                .Where(item => item.MetodoEntrega.TipoEntrega().Trim().ToLower() == metodoViaje.Trim().ToLower())
                .ToList();


            foreach (var pedido in elementosFiltrados)
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

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CaragarDatos();
        }
    }
}