using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_05
{
    public partial class Form1 : Form
    {
        Cola colaConPrioridad;
        public Form1()
        {
            InitializeComponent();
            colaConPrioridad = new Cola();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Nodo nodoAgregar;
            string nombre = txtNombre.Text;
            int prioridad = Convert.ToInt16(txtPrioridad.Text);
            bool verificarPrioridad = (prioridad >= 1 && prioridad <= 3);

            if (!verificarPrioridad) { MessageBox.Show($"La prioridad {prioridad} ingresada es INVALIDA!!!.\nLa pririodad puede ser de 1, 2 o 3"); }
            else
            {
                dgvColaConPrioridad.Rows.Clear();
                nodoAgregar = new Nodo(nombre, prioridad, null);
                colaConPrioridad.agregarNodo(nodoAgregar);

                agregarEnLaGrilla();
            }
        }
        private void agregarEnLaGrilla()
        {
            Nodo temp = new Nodo();
            Cola aux = new Cola();
            while(!colaConPrioridad.colaVacia())
            {
                temp = colaConPrioridad.eliminarNodo();
                aux.agregarNodo(temp);
                dgvColaConPrioridad.Rows.Add(new string[] { temp.nombre, Convert.ToString(temp.prioridad) });
            }
            colaConPrioridad = aux;
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dgvColaConPrioridad.Rows.Count != 0)
            {
                colaConPrioridad.eliminarNodo();
                dgvColaConPrioridad.Rows.RemoveAt(0);
            }
            else { MessageBox.Show("No hay clientes para atender"); }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
