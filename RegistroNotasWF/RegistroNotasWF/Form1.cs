using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace RegistroNotasWF
{
    public partial class Form1 : Form
    {
        ArrayList RegNotas = new ArrayList();
        int indice, numCode = 0;
        string codigo;
        double promedio;

        public Form1()
        {
            InitializeComponent();
        }

        void Mostrar()
        {
            string RegDatos = "";

            for (int i = 0; i < RegNotas.Count; i+=7)
            {
                RegDatos = RegDatos + RegNotas[i] + " " +
                    RegNotas[i + 1] + " " +
                    RegNotas[i + 2] + " " +
                    RegNotas[i + 3] + " " +
                    RegNotas[i + 4] + " " +
                    RegNotas[i + 5] + " " +
                    RegNotas[i + 6] + "\n";
            }
            rtbListado.Text = RegDatos;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtName.Text != null && txtLastname != null && txtSubjet.Text != null && txtLab.Text != null && txtParcial != null)
                {
                    codigo = "ST-00" + numCode;
                    numCode++;

                    RegNotas.Add(codigo);
                    RegNotas.Add(txtName.Text);
                    RegNotas.Add(txtLastname.Text);
                    RegNotas.Add(txtSubjet.Text);
                    RegNotas.Add(txtLab.Text);
                    RegNotas.Add(txtParcial.Text);
                    promedio = (Double.Parse(txtLab.Text) + Double.Parse(txtParcial.Text)) / 2;
                    RegNotas.Add(txtPmd.Text);
                }
                else
                {
                    MessageBox.Show("Todos los campos son obligatorios!");
                }

                Mostrar();
                Limpiar();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error al insertar registro: " + exc.Message);
            }
        }

        void Limpiar()
        {
            txtName.Clear();
            txtLastname.Clear();
            txtSubjet.Clear();
            txtLab.Clear();
            txtParcial.Clear();
        }
    }
}
