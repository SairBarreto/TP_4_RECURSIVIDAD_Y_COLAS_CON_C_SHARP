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

namespace Ejercicio_07
{
    public partial class Form1 : Form
    {
        Cola caja1, caja2, caja3;
        double totalCobradoCaja1, totalCobradoCaja2, totalCobradoCaja3; 
        public Form1()
        {
            InitializeComponent();

            //Las cajas empiezan cerradas
            btnCerrarCaja1.Enabled = false; btnCerrarCaja1.BackColor = Color.DarkRed; 
            btnCerrarCaja2.Enabled = false; btnCerrarCaja2.BackColor = Color.DarkRed; 
            btnCerrarCaja3.Enabled = false; btnCerrarCaja3.BackColor = Color.DarkRed; 
               
            txtMontoCaja1.Enabled = false; btnCobrarCaja1.Enabled = false; btnCobrarCaja1.BackColor = Color.SteelBlue;
            txtMontoCaja2.Enabled = false; btnCobrarCaja2.Enabled = false; btnCobrarCaja2.BackColor = Color.SteelBlue;
            txtMontoCaja3.Enabled = false; btnCobrarCaja3.Enabled = false; btnCobrarCaja3.BackColor = Color.SteelBlue;
            //Inicializo las Colas
            caja1 = new Cola();
            caja2 = new Cola();
            caja3 = new Cola();
            //Inicializo los Totales de las cajas
            totalCobradoCaja1 = 0;
            totalCobradoCaja2 = 0;
            totalCobradoCaja3 = 0;
        }
        private void btnIngresarClientes_Click(object sender, EventArgs e)
        {
            if(!btnAbrirCaja1.Enabled | !btnAbrirCaja2.Enabled | !btnAbrirCaja3.Enabled) //Verifico que alguna caja este abierta
            {
                Nodo nodoAgregar;
                string nombreCliente = Interaction.InputBox("Ingrese un Nombre");
                nodoAgregar = new Nodo(nombreCliente, null);
                List<int> vectorCantidad = new List<int>();

                if (!btnAbrirCaja1.Enabled)
                {
                    vectorCantidad.Add(caja1.obtenerTotal());
                    if (!btnAbrirCaja2.Enabled)
                    {
                        vectorCantidad.Add(caja2.obtenerTotal());
                        if (!btnAbrirCaja3.Enabled) { vectorCantidad.Add(caja3.obtenerTotal()); }
                    }
                    else if (!btnAbrirCaja3.Enabled)
                    {
                        vectorCantidad.Add(caja3.obtenerTotal());
                    }
                }
                else if (!btnAbrirCaja2.Enabled)
                {
                    vectorCantidad.Add(caja2.obtenerTotal());
                    if (!btnAbrirCaja3.Enabled) { vectorCantidad.Add(caja3.obtenerTotal()); }
                }
                else if (!btnAbrirCaja3.Enabled)
                {
                    vectorCantidad.Add(caja3.obtenerTotal());
                }

                int colaConMenorCantidad = vectorCantidad.Min();

                if(caja1.obtenerTotal() == colaConMenorCantidad && !btnAbrirCaja1.Enabled)
                {
                    verificarEstadoYAgregarNodo(caja1, lbColaCaja1, nodoAgregar);
                }
                else if(caja2.obtenerTotal() == colaConMenorCantidad && !btnAbrirCaja2.Enabled)
                {
                    verificarEstadoYAgregarNodo(caja2, lbColaCaja2, nodoAgregar);
                }
                else if(caja3.obtenerTotal() == colaConMenorCantidad && !btnAbrirCaja3.Enabled)
                {
                    verificarEstadoYAgregarNodo(caja3, lbColaCaja3, nodoAgregar);
                }
            }
            else { MessageBox.Show("Abra una caja para ingresar un cliente"); }
        }

        private void btnCerrarCaja1_Click(object sender, EventArgs e)
        {
            vaciarColaYPasarlaAOtras(caja1, caja2, caja3, lbEstadoCaja1, lbColaCaja1, lbColaCaja2, lbColaCaja3, btnAbrirCaja1, btnCerrarCaja1, btnCerrarCaja2, btnCerrarCaja3);
            if(btnAbrirCaja1.Enabled)
            {
                txtMontoCaja1.Enabled = false; btnCobrarCaja1.Enabled = false; btnCobrarCaja1.BackColor = Color.SteelBlue;
            }
        }

        private void btnCerrarCaja2_Click(object sender, EventArgs e)
        {
            vaciarColaYPasarlaAOtras(caja2, caja1, caja3, lbEstadoCaja2, lbColaCaja2, lbColaCaja1, lbColaCaja3, btnAbrirCaja2, btnCerrarCaja2, btnCerrarCaja1, btnCerrarCaja3);
            if (btnAbrirCaja2.Enabled)
            {
                txtMontoCaja2.Enabled = false; btnCobrarCaja2.Enabled = false; btnCobrarCaja2.BackColor = Color.SteelBlue;
            }
        }

        private void btnCerrarCaja3_Click(object sender, EventArgs e)
        {
            vaciarColaYPasarlaAOtras(caja3, caja1, caja2, lbEstadoCaja3, lbColaCaja3, lbColaCaja1, lbColaCaja2, btnAbrirCaja3, btnCerrarCaja3, btnCerrarCaja1, btnCerrarCaja2);
            if (btnAbrirCaja3.Enabled)
            {
                txtMontoCaja3.Enabled = false; btnCobrarCaja3.Enabled = false; btnCobrarCaja3.BackColor = Color.SteelBlue;
            }   
        }

        private void btnAbrirCaja1_Click(object sender, EventArgs e)
        {
            btnCerrarCaja1.Enabled = true; btnCerrarCaja1.BackColor = Color.Red;
            txtMontoCaja1.Enabled = true; btnCobrarCaja1.Enabled = true; btnCobrarCaja1.BackColor = Color.Cyan;
            btnAbrirCaja1.Enabled = false; btnAbrirCaja1.BackColor = Color.DarkGreen;
            lbEstadoCaja1.Text = "Abierto";
        }

        private void btnAbrirCaja2_Click(object sender, EventArgs e)
        {
            btnCerrarCaja2.Enabled = true; btnCerrarCaja2.BackColor = Color.Red;
            txtMontoCaja2.Enabled = true; btnCobrarCaja2.Enabled = true; btnCobrarCaja2.BackColor = Color.Cyan;
            btnAbrirCaja2.Enabled = false; btnAbrirCaja2.BackColor = Color.DarkGreen;
            lbEstadoCaja2.Text = "Abierto";
        }

        private void btnAbrirCaja3_Click(object sender, EventArgs e)
        {
            btnCerrarCaja3.Enabled = true; btnCerrarCaja3.BackColor = Color.Red;
            txtMontoCaja3.Enabled = true; btnCobrarCaja3.Enabled = true; btnCobrarCaja3.BackColor = Color.Cyan;
            btnAbrirCaja3.Enabled = false; btnAbrirCaja3.BackColor = Color.DarkGreen;
            lbEstadoCaja3.Text = "Abierto";
        }

        static void verificarEstadoYAgregarNodo(Cola cola, Label lb, Nodo nodoAgregar) 
        {
            string texto = lb.Text;
            char numerReemplazar = texto.Last();
            cola.agregarNodo(nodoAgregar);
            lb.Text = texto.Replace(Convert.ToString(numerReemplazar), Convert.ToString(cola.obtenerTotal()));
        }

        private void btnCobrarCaja1_Click(object sender, EventArgs e)
        {
            cobrarCaja(caja1, txtMontoCaja1, lbColaCaja1, ref totalCobradoCaja1);
        }
        private void btnCobrarCaja2_Click(object sender, EventArgs e)
        {
            cobrarCaja(caja2, txtMontoCaja2, lbColaCaja2, ref totalCobradoCaja2);
        }
        private void btnCobrarCaja3_Click(object sender, EventArgs e)
        {
            cobrarCaja(caja3, txtMontoCaja3, lbColaCaja3, ref totalCobradoCaja3);
        }

        private void btnFinalizarJornada_Click(object sender, EventArgs e)
        {
            //Las cajas se cierran
            btnCerrarCaja1.Enabled = false; btnCerrarCaja1.BackColor = Color.DarkRed;
            btnCerrarCaja2.Enabled = false; btnCerrarCaja2.BackColor = Color.DarkRed;
            btnCerrarCaja3.Enabled = false; btnCerrarCaja3.BackColor = Color.DarkRed;

            btnAbrirCaja1.Enabled = true; btnAbrirCaja1.BackColor = Color.Lime;
            btnAbrirCaja2.Enabled = true; btnAbrirCaja2.BackColor = Color.Lime;
            btnAbrirCaja3.Enabled = true; btnAbrirCaja3.BackColor = Color.Lime;

            txtMontoCaja1.Enabled = false; btnCobrarCaja1.Enabled = false; btnCobrarCaja1.BackColor = Color.SteelBlue;
            txtMontoCaja2.Enabled = false; btnCobrarCaja2.Enabled = false; btnCobrarCaja2.BackColor = Color.SteelBlue;
            txtMontoCaja3.Enabled = false; btnCobrarCaja3.Enabled = false; btnCobrarCaja3.BackColor = Color.SteelBlue;

            //Limpio las Colas
            vaciarCola(caja1, lbColaCaja1, lbEstadoCaja1);
            vaciarCola(caja2, lbColaCaja2, lbEstadoCaja2);
            vaciarCola(caja3, lbColaCaja3, lbEstadoCaja3);

            //Muestro lo ganado por Caja
            mostrarTotalGanado(lbCobroTotalCaja1, ref totalCobradoCaja1);
            mostrarTotalGanado(lbCobroTotalCaja2, ref totalCobradoCaja2);
            mostrarTotalGanado(lbCobroTotalCaja3, ref totalCobradoCaja3);
        }

        static void mostrarTotalGanado(Label lb, ref double total)
        {
            string texto = lb.Text;
            int posicionInicial = 9;
            string montoReemplazar = texto.Substring(posicionInicial);
            lb.Text = texto.Replace(montoReemplazar, Convert.ToString(total));
            total = 0;
        }

        static void vaciarCola(Cola cola, Label lb, Label lbEstado)
        {
            string texto = lb.Text;
            char aReemplazar = texto.Last();

            while (!cola.colaVacia())
            {
                cola.eliminarNodo();
            }
            lb.Text = texto.Replace(Convert.ToString(aReemplazar), "0");
            lbEstado.Text = "Cerrado";
        }

        static void vaciarColaYPasarlaAOtras(Cola colaEliminar, Cola cola1, Cola cola2, Label lbEstado, Label lbCola, Label lbCola1, Label lbCola2, Button btnAbrir, Button btnCerrar, Button btnCerrar1, Button btnCerrar2)
        {
            btnAbrir.Enabled = true; btnAbrir.BackColor = Color.Lime;
            btnCerrar.Enabled = false; btnCerrar.BackColor = Color.DarkRed;
            bool salir = false;
            string texto = lbCola.Text;
            char aReemplazar = texto.Last();
            lbEstado.Text = "Cerrado";

            while (!colaEliminar.colaVacia() && !salir)
            {
                if (btnCerrar1.Enabled && btnCerrar2.Enabled) //Si el boton de cerrar esta habilitado, la caja esta abierta
                {
                    verificarEstadoYAgregarNodo(cola1, lbCola1, colaEliminar.eliminarNodo());
                    if (!colaEliminar.colaVacia()) { verificarEstadoYAgregarNodo(cola2, lbCola2, colaEliminar.eliminarNodo()); }
                    lbCola.Text = texto.Replace(Convert.ToString(aReemplazar), Convert.ToString(colaEliminar.obtenerTotal()));
                }
                else if (btnCerrar1.Enabled)
                {
                    verificarEstadoYAgregarNodo(cola1, lbCola1, colaEliminar.eliminarNodo());
                    lbCola.Text = texto.Replace(Convert.ToString(aReemplazar), Convert.ToString(colaEliminar.obtenerTotal()));
                }
                else if (btnCerrar2.Enabled)
                {
                    verificarEstadoYAgregarNodo(cola2, lbCola2, colaEliminar.eliminarNodo());
                    lbCola.Text = texto.Replace(Convert.ToString(aReemplazar), Convert.ToString(colaEliminar.obtenerTotal()));
                }
                else
                {
                    MessageBox.Show("Abra otra caja si quiere cerrar la CAJA");
                    btnAbrir.Enabled = false; btnAbrir.BackColor = Color.DarkGreen;
                    btnCerrar.Enabled = true; btnCerrar.BackColor = Color.Red;
                    salir = true;
                    lbEstado.Text = "Abierto";
                }
            }
        }
        static void cobrarCaja(Cola cola, TextBox txt, Label lb, ref double sumatoria)
        {
            try
            {
                double cobro = Convert.ToDouble(txt.Text.Replace(".", ","));
                txt.Text = "";
                string texto = lb.Text;
                char aReemplazar = texto.Last();
                if (!cola.colaVacia())
                {
                    sumatoria += cobro;
                    cola.eliminarNodo();
                    lb.Text = texto.Replace(Convert.ToString(aReemplazar), Convert.ToString(cola.obtenerTotal()));
                }
                else
                {
                    MessageBox.Show("NO HAY CLIENTES PARA EFECTUAR EL COBRO");
                }
            }
            catch (Exception) { MessageBox.Show("El Monto ingresado NO ES VALIDO!!!"); }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
