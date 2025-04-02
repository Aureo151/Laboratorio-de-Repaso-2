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
    public partial class FormAlquiler : Form
    {
        List<Cliente> clientes = new List<Cliente>();
        List<Vehiculo> vehiculos = new List<Vehiculo>();
        List<Alquiler> alquilers = new List<Alquiler>();
        public FormAlquiler()
        {
            InitializeComponent();
        }

        private void FormAlquiler_Load(object sender, EventArgs e)
        {
            
            ClienteArchivo clienteArchivo = new ClienteArchivo();
            List<Cliente> clientes = clienteArchivo.Leer("../../Clientes.json");

            cmbNIT.DataSource = clientes;
            cmbNIT.DisplayMember = "nit";
            
         
            VehiculoArchivo vehiculoArchivo = new VehiculoArchivo();
            List<Vehiculo> vehiculos = vehiculoArchivo.Leer("../../Vehiculos.json");

            cmbPlaca.DisplayMember = "placa";
            cmbPlaca.DataSource = vehiculos;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClienteArchivo clienteArchivo = new ClienteArchivo();
            List<Cliente> clientes = clienteArchivo.Leer("../../Clientes.json");

            VehiculoArchivo vehiculoArchivo = new VehiculoArchivo();
            List<Vehiculo> vehiculos = vehiculoArchivo.Leer("../../Vehiculos.json");

            foreach (var cliente in clientes)
            {
                foreach (var vehiculo in vehiculos)
                {
                    if(cmbNIT.Text == cliente.nit)
                    {
                        Alquiler alquiler = new Alquiler();
                        alquiler.nit = cmbNIT.Text;
                        alquiler.placa = cmbPlaca.Text;
                        alquiler.fecha_alquiler = dateTimePickerAlquiler.Value.Date;
                        alquiler.fecha_devolucion = dateTimePickerDevolucion.Value.Date;
                        alquiler.kilometros_recorridos = Convert.ToInt16(txtKmRecorridos.Text);
                        alquiler.costo_alquiler = vehiculo.precio_kilometro * alquiler.kilometros_recorridos;
                        
                        alquilers.Add(alquiler);

                        AlquilerArchivo alquilerArchivo = new AlquilerArchivo();

                        alquilerArchivo.Guardar("../../Alquilers.json", alquilers);

                        txtKmRecorridos.Clear();
                    }
                    
                }
            }
        }
    }
}
