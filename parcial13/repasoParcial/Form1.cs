using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using repasoParcial.Models;

namespace repasoParcial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Servicio registros = new Servicio();
        private void btnAgregarExpediente_Click(object sender, EventArgs e)
        {
            FormDatos formDatos = new FormDatos();
            while (formDatos.ShowDialog() == DialogResult.OK)
            {
                int nro = Convert.ToInt32(formDatos.tbNumeroDeCausa.Text);
                int dni = Convert.ToInt32(formDatos.tbDni.Text);
                int monto = Convert.ToInt32(formDatos.tbMonto.Text);
                registros.RegistarExpediente(nro, dni, monto);
                string tex = Convert.ToString(registros.VerContador());
                groupBox1.Text = $"expedientes: {tex}";
            }
        }

        private void btnVerListado_Click(object sender, EventArgs e)
        {
            FormVer formVer = new FormVer();
            registros.OrdenarExpedientes();
            int dni;
            double monto;
            int nro;
            for (int i = 0; i < registros.VerContador(); i++)
            {
                registros.VerExpedientes(i, out nro, out dni, out monto);
                formVer.lsbResultados.Items.Add($"{nro} - {dni} - {monto}");
            }
            formVer.ShowDialog();

        }

        private void btnMayores_Click(object sender, EventArgs e)
        {
            FormVer formVer = new FormVer();
            double prom = registros.CalcularMontoPromedio();
            int dni;
            double monto;
            int nro;
            for (int i = 0; i < registros.VerContador(); i++)
            {

                registros.VerExpedientes(i, out nro, out dni, out monto);
                if (monto > prom)
                {
                    formVer.lsbResultados.Items.Add($"{nro} - {dni} - {monto}");
                }
            }
            formVer.ShowDialog();
        }

        private void btnVerExpedientes_Click(object sender, EventArgs e)
        {
            FormVer formVer = new FormVer();
            int cantidad;
            int numero;
            double monto;
            int dni = Convert.ToInt32(tbDNI.Text);
            int[] inx =  new int[100];
            inx = registros.VerExpedientesPorDni(dni, out cantidad);


            for (int i = 0; i < cantidad; i++) 
            {   
                registros.VerExpedientes(inx[i], out numero, out dni, out monto);
                formVer.lsbResultados.Items.Add($"{numero} - {dni} - {monto}");

            }
            if (cantidad == 0) formVer.lsbResultados.Items.Add($"No se encontaron expedientes");
            formVer.ShowDialog();
        }

        private void btnVerCausaPorNro_Click(object sender, EventArgs e)
        {
            FormVer formVer = new FormVer();
            int dni;
            double monto;
            int nro=Convert.ToInt32(tbNroCausa.Text);
            int causa=registros.VerExpedientesPorNumero(nro);

            registros.VerExpedientes(causa, out nro, out dni, out monto);
            formVer.lsbResultados.Items.Add($"{nro} - {dni} - {monto}");
            formVer.ShowDialog();
        }
    }
}
