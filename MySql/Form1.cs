using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySql
{
    public partial class Form1 : Form
    {
        Conexion conexion = new Conexion();

        int id;
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string consulta = "insert into productos(DescripcionProducto,precioProducto) values('" +
txtBoxDescripcion.Text + "'," + txtBoxPrecio.Text + ")";

            if (conexion.ejecutarQuery(consulta))

            {

                MessageBox.Show("Producto registrado correctamente");

                cargar();

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string consulta = "delete from productos where idProducto =" + id;

            if (conexion.ejecutarQuery(consulta))

            {

                MessageBox.Show("Producto eliminado correctamente");

                cargar();

            }
        }
        public void cargar()

        {

            dataGridView1.DataSource = conexion.cargarDatos("select * from productos");

        }
    }
}
