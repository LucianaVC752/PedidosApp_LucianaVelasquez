using PedidosApp.Listados;
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
    public partial class CalcularPedido : Form
    {
        public CalcularPedido()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void CalcularPedido_Load(object sender, EventArgs e)
        {
            cmbProducto.Items.Add(NombreProductos.componente.ToString());
            cmbProducto.Items.Add(NombreProductos.accesorio.ToString());
            cmbProducto.Items.Add(NombreProductos.tecnologia.ToString());
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {

            try
            {
                double pesoProducto;
                int recorridoProducto;
                if (string.IsNullOrEmpty(txtIdenficacion.Text) || string.IsNullOrEmpty(txtNombre.Text))
                {
                    MessageBox.Show("No puede dejar campos sin rellenar");
                    return;
                }
                if (cmbProducto.SelectedItem == null)
                {
                    MessageBox.Show("No puede dejar campos sin rellenar");
                    return;
                }
                if (!double.TryParse(nudPeso.Value.ToString(), out double peso) || peso < 1 ||
                    !int.TryParse(nudRecorrido.Value.ToString(), out int recorrido)|| recorrido <1)
                {
                    MessageBox.Show("Por favor recuerde que el peso y el recorrido debe ser mayor a 0");
                    return;
                }

                string identificacionC = txtIdenficacion.Text, 
                       nombreC = txtNombre.Text, 
                       tipoProduct = cmbProducto.SelectedItem.ToString();
                pesoProducto = Convert.ToDouble(nudPeso.Value); 
                recorridoProducto =Convert.ToInt32(nudRecorrido.Value) ;
                bool urgente = chkUrgencia.Checked;

                Pedido pedido = new Pedido(identificacionC,nombreC,tipoProduct, urgente, pesoProducto,recorridoProducto );
                RegistroPedidos.Instancia.AgregarPedido(pedido);

                lbMostrarTotal.Text = $"Entrega: {pedido.MetodoEntrega.TipoEntrega()} " +
                                    $"Costo: ${pedido.ObtenerCosto():0.00}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtIdenficacion.Text = "";
            txtNombre.Text = "";
            cmbProducto.SelectedIndex = -1; 
            chkUrgencia.Checked = false;
            nudPeso.Value = nudPeso.Minimum; 
            nudRecorrido.Value = nudRecorrido.Minimum;
            lbMostrarTotal.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
