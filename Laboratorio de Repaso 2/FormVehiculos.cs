using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio_de_Repaso_2
{
    public partial class FormVehiculos : Form
    {
        public FormVehiculos()
        {
            InitializeComponent();
        }

        private void btnVehiculo_Click(object sender, EventArgs e)
        {
            FormClientes formClientes = new FormClientes();
            formClientes.Show();
            this.Close();
        }

        private void btnAlquiler_Click(object sender, EventArgs e)
        {
            FormAlquiler formAlquiler = new FormAlquiler();
            formAlquiler.Show();
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
