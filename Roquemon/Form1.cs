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
    public partial class Roquemon : Form
    {
        int Habilitador = 0;
        Roquemones Aguamon = new Roquemones();
        Roquemones Fuegomon = new Roquemones();
        Roquemones Plantamon = new Roquemones();
        public Roquemon()
        {
            InitializeComponent();
            inicializacion();
            
            //Ingreso del nombre de los jugadores
            string Jugador1 = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nombre del Jugador", "Jugador 1", "");
            this.Jugador1.Text = Jugador1;
            string Jugador2 = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nombre del Jugador", "Jugador 2", "");
            this.Jugador2.Text = Jugador2;

            //--------------------------Lectura del archivo de Texto-----------------------------------
            //string Ruta = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la ruta del archivo de texto de los Roquemones", "Archivo de Texto", "");
            string Ruta = "Roquemon.txt";
            string Linea = "";
            string[] rCaracteristicas= {};
            char[] delimiterChars = {',', '%', '\r','\n'};

            using (StreamReader aTexto = new StreamReader(Ruta, Encoding.Default))
            {
                Linea = aTexto.ReadToEnd();
                rCaracteristicas = Linea.Split(delimiterChars);   
                aTexto.Close();
            }
            //------------------------------------------------------------------------------------------
            //----------------------------Cargar informacion a la clase roquemones----------------------

            Aguamon.Nombre = rCaracteristicas[0];
            Aguamon.Vida = Convert.ToInt32(rCaracteristicas[1]);
            Aguamon.Ataque = Convert.ToInt32(rCaracteristicas[2]);
            Aguamon.Defensa = Convert.ToInt32(rCaracteristicas[3]);
            Aguamon.Velocidad = Convert.ToInt32(rCaracteristicas[4]);
            Aguamon.Critico = Convert.ToDouble(rCaracteristicas[5]) / 100;


            Fuegomon.Nombre = rCaracteristicas[8];
            Fuegomon.Vida = Convert.ToInt32(rCaracteristicas[9]);
            Fuegomon.Ataque = Convert.ToInt32(rCaracteristicas[10]);
            Fuegomon.Defensa = Convert.ToInt32(rCaracteristicas[11]);
            Fuegomon.Velocidad = Convert.ToInt32(rCaracteristicas[12]);
            Fuegomon.Critico = Convert.ToDouble(rCaracteristicas[13]) / 100;


            Plantamon.Nombre = rCaracteristicas[16];
            Plantamon.Vida = Convert.ToInt32(rCaracteristicas[17]);
            Plantamon.Ataque = Convert.ToInt32(rCaracteristicas[18]);
            Plantamon.Defensa = Convert.ToInt32(rCaracteristicas[19]);
            Plantamon.Velocidad = Convert.ToInt32(rCaracteristicas[20]);
            Plantamon.Critico = Convert.ToDouble(rCaracteristicas[21]) / 100;

        }
        private void inicializacion()
        {
            Jugador1.Text = "";
            Jugador2.Text = "";
            label1.Text = "";
            Roquemon1.Text = "";
            Roquemon2.Text = "";
            Habilidad1.Checked = false;
            Habilidad2.Checked = false;
            Habilidad3.Checked = false;
            Habilidad4.Checked = false;
            Combatir.Visible = false;
            BJugador1.Enabled = false;
            Bjugador2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Velocidad1 = 0;
            int Ataque1 = 0;
            int Defensa1 = 0;
            double Critico1 = 0;
            int Turno1=0;
            int Turno2 = 0;

            if (Turno1 > 3)
            {

            }
            if (Habilidad1.Checked == true)
            {

                if (Habilidad1.Text == "Ataque Rápido")
                {
                    Velocidad1 = 100;
                }
                else if (Habilidad1.Text == "Flama")
                {
                    Ataque1 = Fuegomon.Ataque + 5;
                }
                else if (Habilidad1.Text == "Latigo")
                {
                    Ataque1 = Plantamon.Ataque + 5;
                }

            }
            else if (Habilidad2.Checked == true)
            {
                if (Habilidad2.Text == "Torrente")
                {
                    Ataque1 = Aguamon.Ataque + 5;
                }
                else if (Habilidad2.Text == "Furia")
                {
                    Critico1 = Fuegomon.Critico + 0.2;
                    Turno1 = 3;
                }
                else if (Habilidad2.Text == "Fotosintesis")
                {
                    Defensa1 = Plantamon.Defensa + 5;
                    Turno2 = 3;
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Habilitador++;
            if (Habilitador == 2)
            {
                Combatir.Visible = true;
                Combatir.Enabled = false;
                Habilitador = 0;
            } 
        
           if (AguamonI.Checked == true)
           {
                Roquemon1.Text = "Aguamón";
                Habilidad1.Image = Image.FromFile("AtaqueRapido.ico");
                Habilidad1.Text = "Ataque Rápido";
                    Habilidad1.Checked = false;
                Habilidad2.Image = Image.FromFile("Torrente.ico");
                Habilidad2.Text = "Torrente";
                groupBox5.Visible = false;
                pictureBox1.Image = Image.FromFile("AguamonIzquierda.png");
                progressBar1.Maximum = Aguamon.Vida;
                progressBar1.Value = Aguamon.Vida;
            }
            else if (FuegomonI.Checked == true)
            {
                Roquemon1.Text = "Fuegomón";
                Habilidad1.Image = Image.FromFile("Flama.ico");
                Habilidad1.Text = "Flama";
                Habilidad1.Checked = false;
                Habilidad2.Image = Image.FromFile("Furia.ico");
                Habilidad2.Text = "Furia";
                groupBox5.Visible = false;
                pictureBox1.Image = Image.FromFile("FuegomonIzquierda.png");
                progressBar1.Maximum = Fuegomon.Vida;
                progressBar1.Value = Fuegomon.Vida;
            }
           else if (PlantamonI.Checked == true)
            {
                Roquemon1.Text = "Plantamón";
                Habilidad1.Image = Image.FromFile("Latigo.ico");
                Habilidad1.Text = "Latigo";
                Habilidad1.Checked = false;
                Habilidad2.Image = Image.FromFile("Fotosintesis.ico");
                Habilidad2.Text = "Fotosintesis";
                groupBox5.Visible = false;
                pictureBox1.Image = Image.FromFile("PlantamonIzquierda.png");
                progressBar1.Maximum = Plantamon.Vida;
                progressBar1.Value = Plantamon.Vida;
            }
        }


        private void Bjugador2_Click(object sender, EventArgs e)
        {
            Habilitador++;
            if (Habilitador == 2)
            {
                Combatir.Visible = true;
                Combatir.Enabled = false;
                Habilitador = 0;
            }
            
            if (AguamonD.Checked == true)
            {
                Roquemon2.Text = "Aguamón";
                Habilidad3.Image = Image.FromFile("AtaqueRapido.ico");
                Habilidad3.Text = "Ataque Rápido";
                Habilidad4.Image = Image.FromFile("Torrente.ico");
                Habilidad4.Text = "Torrente";
                groupBox6.Visible = false;
                pictureBox2.Image = Image.FromFile("AguamonDerecha.png");
                progressBar2.Maximum = Aguamon.Vida;
                progressBar2.Value = Aguamon.Vida;
            }
            else if (FuegomonD.Checked == true)
            {
                Roquemon2.Text = "Fuegomón";
                Habilidad3.Image = Image.FromFile("Flama.ico");
                Habilidad3.Text = "Flama";
                Habilidad4.Image = Image.FromFile("Furia.ico");
                Habilidad4.Text = "Furia";
                groupBox6.Visible = false;
                pictureBox2.Image = Image.FromFile("FuegomonDerecha.jpg");
                progressBar2.Maximum = Fuegomon.Vida;
                progressBar2.Value = Fuegomon.Vida;
            }
            else if (PlantamonD.Checked == true)
            {
                Roquemon2.Text = "Plantamón";
                Habilidad3.Image = Image.FromFile("Latigo.ico");
                Habilidad3.Text = "Latigo";
                Habilidad4.Image = Image.FromFile("Fotosintesis.ico");
                Habilidad4.Text = "Fotosintesis";
                groupBox6.Visible = false;
                pictureBox2.Image = Image.FromFile("PlantamonDerecha.png");
                progressBar2.Maximum = Plantamon.Vida;
                progressBar2.Value = Plantamon.Vida;
            }
        }

        private void AguamonI_CheckedChanged(object sender, EventArgs e)
        {
            if (AguamonI.Checked == true) BJugador1.Enabled = true;
        }

        private void FuegomonI_CheckedChanged(object sender, EventArgs e)
        {
            if (FuegomonI.Checked == true) BJugador1.Enabled = true;
        }

        private void PlantamonI_CheckedChanged(object sender, EventArgs e)
        {
            if (PlantamonI.Checked == true) BJugador1.Enabled = true;
        }

        private void AguamonD_CheckedChanged(object sender, EventArgs e)
        {
            if (AguamonD.Checked == true) Bjugador2.Enabled = true;
        }

        private void FuegomonD_CheckedChanged(object sender, EventArgs e)
        {
            if (FuegomonD.Checked == true) Bjugador2.Enabled = true;
        }

        private void PlantamonD_CheckedChanged(object sender, EventArgs e)
        {
            if (PlantamonD.Checked == true) Bjugador2.Enabled = true;
        }

        private void Habilidad1_CheckedChanged(object sender, EventArgs e)
        {
            int prueba = 0;
            prueba++;
        }
    }

}
