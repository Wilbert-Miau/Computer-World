using Computer_World.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_World.Win
{
    public partial class Form2 : Form
    {
        ReporteVentasPorProductoBL _reporteVentasPorProducto;
        public Form2()
        {
            InitializeComponent();
            _reporteVentasPorProducto = new ReporteVentasPorProductoBL();
            RefrescarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            RefrescarDatos();
        }

        private void RefrescarDatos()
        {
            var listadeVentasPorProducto = _reporteVentasPorProducto.ObtenerVentasPorProducto();
            listadeVentasPorProductoBindingSource.DataSource = listadeVentasPorProducto;
            listadeVentasPorProductoBindingSource.ResetBindings(false);
        }
    }
}
