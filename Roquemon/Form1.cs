using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;


namespace Roquemon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Ingreso del nombre de los jugadores
            string Jugador1 = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nombre del Jugador", "Jugador 1", "");
            groupBox1.Text = Jugador1;
            string Jugador2 = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nombre del Jugador", "Jugador 2", "");
            groupBox2.Text = Jugador2;
            //string Ruta = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la ruta del archivo de texto de los Roquemones", "Archivo de Texto", "");
            string Ruta = "Roquemon.txt";
            string Linea = "";
            int CantLineas = 0;
            string[] rCaracteristicas;
            string[] RoquemonesC = {};
            char[] delimiterChars = {',', '%', '\r','\n'};

            using (StreamReader aTexto = new StreamReader(Ruta, Encoding.Default))
            {           
                while ((Linea = aTexto.ReadToEnd()) != null)
                {
                    rCaracteristicas = Linea.Split(delimiterChars);
           
                    CantLineas++;
                }
                aTexto.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }

    internal class ArrayList
    {
        public static implicit operator ArrayList(System.Collections.ArrayList v)
        {
            throw new NotImplementedException();
        }
    }
}
