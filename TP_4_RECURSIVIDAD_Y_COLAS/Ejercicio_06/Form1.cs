using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_06
{
    public partial class Form1 : Form
    {
        Cola colaOriginal, colaSinTicket;
        public Form1()
        {
            InitializeComponent();

            colaOriginal = new Cola();
            colaSinTicket = new Cola();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCombinar_Click(object sender, EventArgs e)
        {
            dgvColaSinTicket.Rows.Clear();
            Nodo temp = new Nodo();
            Cola aux = new Cola();
            int ticket = dgvColaOriginal.Rows.Count + 1;

            while (!colaSinTicket.colaVacia())
            {
                temp = colaSinTicket.eliminarNodo();
                temp.asignarTicket(ticket);
                colaOriginal.agregarNodo(temp);
                ticket++;
            }

            dgvColaOriginal.Rows.Clear();
            while (!colaOriginal.colaVacia())
            {
                temp = colaOriginal.eliminarNodo();
                aux.agregarNodo(temp);
                dgvColaFinal.Rows.Add(new string[] { temp.nombre, Convert.ToString(temp.ticket) });
                dgvColaOriginal.Rows.Add(new string[] { temp.nombre, Convert.ToString(temp.ticket) });
            }
            colaOriginal = aux;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Nodo nodoAgregar;

            try
            {
                string nombre = txtNombre.Text;
                int ticket = Convert.ToInt16(txtTicket.Text);

                if (ticket > 0)
                {
                    foreach (DataGridViewRow row in dgvColaOriginal.Rows)
                    {
                        int celda = Convert.ToInt32(row.Cells[1].Value);
                        if (ticket == celda)
                        {
                            ticket = dgvColaOriginal.Rows.Count + 1;
                        }
                    }

                    dgvColaOriginal.Rows.Clear();
                    nodoAgregar = new Nodo(nombre, ticket, null);
                    colaOriginal.agregarNodo(nodoAgregar);

                    colaOriginal = agregarEnLaGrilla(dgvColaOriginal, colaOriginal);
                }
                else
                {
                    dgvColaSinTicket.Rows.Clear();
                    nodoAgregar = new Nodo(nombre, 0, null);
                    colaSinTicket.agregarNodo(nodoAgregar);

                    colaSinTicket = agregarEnLaGrilla(dgvColaSinTicket, colaSinTicket);
                }
            }
            catch (Exception) { MessageBox.Show($"El ticket {txtTicket.Text} ingresado es INVALIDO"); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvColaOriginal.Rows.Count != 0)
            {
                colaOriginal.eliminarNodo();
                dgvColaOriginal.Rows.RemoveAt(0);
                if(dgvColaFinal.Rows.Count != 0)
                {
                    dgvColaFinal.Rows.RemoveAt(0);
                }
            }
            else { MessageBox.Show("Estan todos atendidos"); }
        }

        private Cola agregarEnLaGrilla(DataGridView dgv, Cola cola)
        {
            Nodo temp = new Nodo();
            Cola aux = new Cola();
            while (!cola.colaVacia())
            {
                temp = cola.eliminarNodo();
                aux.agregarNodo(temp);
                if(temp.ticket == 0)
                {
                    dgv.Rows.Add(new string[] { temp.nombre, "Sin Ticket" });
                }
                else
                {
                    dgv.Rows.Add(new string[] { temp.nombre, Convert.ToString(temp.ticket) });
                }
            }
            return aux;
        }
    }
}
