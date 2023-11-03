using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Ejercicio_04
{
    public partial class Form1 : Form
    {
        Cola cola1, colaM, colaF;
        public Form1()
        {
            InitializeComponent();

            cola1 = new Cola();
            colaM = new Cola();
            colaF = new Cola();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = Interaction.InputBox("Ingrese un Nombre");
            string genero = Interaction.InputBox("Ingrese el Genero M/F");

            cola1.agregarNodo(nombre, genero);
            dgvCola1.Rows.Add(new string[] { nombre, genero });
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            cola1.eliminarNodo();
            int totalFilas = dgvCola1.Rows.Count;
            dgvCola1.Rows.RemoveAt(0);
        }
        private void btnSeparar_Click(object sender, EventArgs e)
        {
            dgvColaM.Rows.Clear();
            dgvColaF.Rows.Clear();

            Cola auxCola = new Cola();
            separarRecursivo(cola1, auxCola);
            cola1 = auxCola;
        }
        private void separarRecursivo(Cola original, Cola auxiliar)
        {
            if (!original.colaVacia())
            {
                Nodo tem = original.eliminarNodo();
                string nombre = tem.nombre;
                string genero = tem.genero;
                auxiliar.agregarNodo(nombre, genero);

                if (genero.CompareTo("M") == 0)
                {
                    colaM.agregarNodo(nombre, genero);
                    dgvColaM.Rows.Add(new string[] { nombre, genero });
                }
                else
                {
                    colaF.agregarNodo(nombre, genero);
                    dgvColaF.Rows.Add(new string[] { nombre, genero });
                }
                separarRecursivo(original, auxiliar);
            }
        }
    }
}
