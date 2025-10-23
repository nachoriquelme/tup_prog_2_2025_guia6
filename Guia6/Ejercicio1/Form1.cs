using Ejercicio1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Persona> personas = new List<Persona>();
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Datos fDatos = new Datos();

            fDatos.ShowDialog();

            while (fDatos.DialogResult == DialogResult.OK)
            {
                string nombre = fDatos.tbNombre.Text;
                string cuit = fDatos.tbCUIT.Text;

                Persona persona = null;

                try
                {
                    if (fDatos.rbFisica.Checked)
                    {
                        persona = new Persona(nombre);
                    }
                    else if (fDatos.rbJuridica.Checked)
                    {
                        persona = new PersonaJuridica(nombre, cuit);
                    }

                    if (persona != null)
                    {
                        personas.Add(persona);
                    }
                    else
                        MessageBox.Show("Seleccione tipo de persona");
                }
                catch (FormatoNombreNoValidoException ex)
                {
                    fDatos.lbCUIT.Visible = true;
                    fDatos.lbNombre.Text = ex.Message;
                }
                catch (FormatoCUITNoValidoException ex)
                {
                    fDatos.lbNombre.Visible = true;
                    fDatos.lbCUIT.Text = ex.Message;
                }
                fDatos.ShowDialog();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Persona persona = lbxListado.SelectedItem as Persona;
            if (persona != null)
            {
                personas.Remove(persona);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            personas.Sort();

            lbxListado.Items.Clear();
            foreach (Persona p in personas)
            {
                lbxListado.Items.Add(p.Describir());
            }
        }
    }
}
