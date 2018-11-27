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
        int Turno1 = 0, Turno2 = 0;
        int Turno3 = 0, Turno4 = 0;
        double Vida1 = 0;
        int Velocidad1 = 0;
        int Ataque1 = 0;
        int Defensa1 = 0;
        double Critico1 = 0;
        double Vida2 = 0;
        int Velocidad2 = 0;
        int Ataque2 = 0;
        int Defensa2 = 0;
        double Critico2 = 0;
        int VelocidadEfectiva1 = 0;
        int VelocidadEfectiva2 = 0;
        double Daño1 = 0;
        double Daño2 = 0;

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
            string Linea = "";
            string[] rCaracteristicas= {};
            char[] CharDelimitadores = {',', '%', '\r','\n'};

            using (StreamReader aTexto = new StreamReader("Roquemon.txt", Encoding.Default))
            {
                Linea = aTexto.ReadToEnd();
                rCaracteristicas = Linea.Split(CharDelimitadores);   
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
            CaracteristicasBase(Roquemon1.Text, true);
            CaracteristicasBase(Roquemon2.Text, false);

            Habilidades(Habilidad1.Checked, Habilidad2.Checked, Habilidad1.Text, 
                        Habilidad2.Text, true);
            Habilidades(Habilidad3.Checked, Habilidad4.Checked, Habilidad3.Text, 
                        Habilidad4.Text, false);
            Resultados();

            if (VelocidadEfectiva1 > VelocidadEfectiva2 && progressBar2.Value > Convert.ToInt32(Daño1))
            {
                progressBar2.Value = progressBar2.Value - Convert.ToInt32(Daño1);
                label3.Text = Convert.ToString(progressBar2.Value);
                if (Habilidad1.Checked== true)
                label1.Text = "El " + Roquemon1.Text + "de " + Jugador1.Text + "ha causado un daño de: " + 
                               Convert.ToString(Daño1) + " al " + Roquemon2.Text + "de " + Jugador2.Text + 
                               "usando la habilidad: " + Habilidad1.Text;
                else if (Habilidad2.Checked == true)
                    label1.Text = "El " + Roquemon1.Text + "de " + Jugador1.Text + "ha causado un daño de: " +
                                   Convert.ToString(Daño1) + " al " + Roquemon2.Text + "de " + Jugador2.Text +
                                   "usando la habilidad: " + Habilidad2.Text;
            }
            else if (VelocidadEfectiva1 < VelocidadEfectiva2 && progressBar1.Value > Convert.ToInt32(Daño2))
            {
                progressBar1.Value = progressBar1.Value - Convert.ToInt32(Daño2);
                label3.Text = Convert.ToString(progressBar1.Value);
                if (Habilidad3.Checked == true)
                    label1.Text = "El " + Roquemon2.Text + " de " + Jugador2.Text + " ha causado un daño de: " +
                                   Convert.ToString(Daño2) + " al " + Roquemon1.Text + " de " + Jugador1.Text +
                                   " usando la habilidad: " + Habilidad3.Text;
                else if (Habilidad4.Checked == true)
                    label1.Text = "El " + Roquemon2.Text + " de " + Jugador2.Text + " ha causado un daño de: " +
                                   Convert.ToString(Daño2) + " al " + Roquemon1.Text + "de " + Jugador1.Text +
                                   " usando la habilidad: " + Habilidad4.Text;
            }
            timer1.Start();

        }
        private void CaracteristicasBase(string NombreRoquemon, bool Jugador)
        {
            if (Jugador == true)
            {
                if (NombreRoquemon == "Aguamón")
                {
                    Vida1 = Aguamon.Vida;
                    Ataque1 = Aguamon.Ataque;
                    Defensa1 = Aguamon.Defensa;
                    Velocidad1 = Aguamon.Velocidad;
                    Critico1 = Aguamon.Critico;
                }
                else if (NombreRoquemon == "Fuegomón")
                {
                    Vida1 = Fuegomon.Vida;
                    Ataque1 = Fuegomon.Ataque;
                    Defensa1 = Fuegomon.Defensa;
                    Velocidad1 = Fuegomon.Velocidad;
                    Critico1 = Fuegomon.Critico;
                }
                else if (NombreRoquemon == "Plantamón")
                {
                    Vida1 = Plantamon.Vida;
                    Ataque1 = Plantamon.Ataque;
                    Defensa1 = Plantamon.Defensa;
                    Velocidad1 = Plantamon.Velocidad;
                    Critico1 = Plantamon.Critico;
                }
            }
            if (Jugador == false)
            {
                if (NombreRoquemon == "Aguamón")
                {
                    Vida2 = Aguamon.Vida;
                    Ataque2 = Aguamon.Ataque;
                    Defensa2 = Aguamon.Defensa;
                    Velocidad2 = Aguamon.Velocidad;
                    Critico2 = Aguamon.Critico;
                }
                else if (NombreRoquemon == "Fuegomón")
                {
                    Vida2 = Fuegomon.Vida;
                    Ataque2 = Fuegomon.Ataque;
                    Defensa2 = Fuegomon.Defensa;
                    Velocidad2 = Fuegomon.Velocidad;
                    Critico2 = Fuegomon.Critico;
                }
                else if (NombreRoquemon == "Plantamón")
                {
                    Vida2 = Plantamon.Vida;
                    Ataque2 = Plantamon.Ataque;
                    Defensa2 = Plantamon.Defensa;
                    Velocidad2 = Plantamon.Velocidad;
                    Critico2 = Plantamon.Critico;
                }
            }
        }
        private void Habilidades(bool Habilidad1, bool Habilidad2, string NombreHabilidad1, 
                                 string NombreHabilidad2, bool Jugador)
        {
            if (Jugador == true)
            {
                if (Turno1 > 0)
                {
                    Critico1 = Fuegomon.Critico + 0.2;
                    Turno1--;
                }

                if (Turno2 > 0)
                {
                    Defensa1 = Plantamon.Defensa + 5;
                    Turno2--;
                }
            }
            if (Jugador == false)
            {
                if (Turno3 > 0)
                {
                    Critico2 = Fuegomon.Critico + 0.2;
                    Turno3--;
                }

                if (Turno4 > 0)
                {
                    Defensa2 = Plantamon.Defensa + 5;
                    Turno4--;
                }
            }
            if (Habilidad1 == true)
            {

                if (NombreHabilidad1 == "Ataque Rápido")
                {
                    if (Jugador  == true) Velocidad1 = Aguamon.Velocidad + 65;
                    else if (Jugador == false) Velocidad2 = Aguamon.Velocidad + 65;
                }
                else if (NombreHabilidad1 == "Flama")
                {
                    if (Jugador == true) Ataque1 = Fuegomon.Ataque + 5;
                    else if (Jugador == false) Ataque2 = Fuegomon.Ataque + 5;
                }
                else if (NombreHabilidad1 == "Latigo")
                {
                    if (Jugador == true)  Ataque1 = Plantamon.Ataque + 5;
                    else if (Jugador == false) Ataque2 = Plantamon.Ataque + 5;
                }

            }
            else if (Habilidad2 == true)
            {
                if (NombreHabilidad2 == "Torrente")
                {
                    if (Jugador == true) Ataque1 = Aguamon.Ataque + 5;
                    else if (Jugador == false) Ataque1 = Aguamon.Ataque + 5;
                }
                else if (NombreHabilidad2 == "Furia")
                {
                    if (Jugador == true)
                    {
                        Critico1 = Fuegomon.Critico + 0.2;
                        Turno1 = 3;
                    }
                    else if (Jugador == false)
                    {
                        Critico2 = Fuegomon.Critico + 0.2;
                        Turno1 = 3;
                    }
                }
                else if (NombreHabilidad2 == "Fotosintesis")
                {
                    if (Jugador == true)
                    {
                        Defensa1 = Plantamon.Defensa + 5;
                        Turno3 = 3;
                    }
                    else if (Jugador == false)
                    {
                        Defensa2 = Plantamon.Defensa + 5;
                        Turno4 = 3;
                    }
                }
            }
        }
        //int Vida1, int Ataque1, int Defensa1, int Velocidad1, double Critico1, int Vida2, int Ataque2, int Defensa2, int Velocidad2, double Critico2
        private void Resultados()
        {
            Random Aleatorio = new Random();
            VelocidadEfectiva1 = Velocidad1 + Aleatorio.Next(-10, 10);
            VelocidadEfectiva2 = Velocidad2 + Aleatorio.Next(-10, 10);
            Daño1 = (Ataque1 + Aleatorio.Next(-7, 7) - Defensa2) * (Critico1+1);
            if (Daño1 < 0) Daño1 = 0;
            Daño2 = (Ataque2 + Aleatorio.Next(-7, 7) - Defensa1) * (Critico2+1);
            if (Daño2 < 0) Daño2 = 0;

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
                Roquemon1.Text = Aguamon.Nombre;
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
                Roquemon1.Text = Fuegomon.Nombre;
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
                Roquemon1.Text = Plantamon.Nombre;
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
            label2.Text = Convert.ToString(progressBar1.Value);
            CaracteristicasBase(Roquemon1.Text, true);
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
            label3.Text = Convert.ToString(progressBar2.Value);
            CaracteristicasBase(Roquemon2.Text, false);
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
            if ((Habilidad1.Checked == true) && (Habilidad3.Checked == true || Habilidad4.Checked == true))
            {
                Combatir.Enabled = true;
            }
        }

        private void Habilidad2_CheckedChanged(object sender, EventArgs e)
        {
            if ((Habilidad2.Checked == true) && (Habilidad3.Checked == true || Habilidad4.Checked == true))
            {
                Combatir.Enabled = true;
            }
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (VelocidadEfectiva1 < VelocidadEfectiva2 && progressBar2.Value > Convert.ToInt32(Daño1))
            {
                progressBar2.Value = progressBar2.Value - Convert.ToInt32(Daño1);
                label3.Text = Convert.ToString(progressBar2.Value);
                if (Habilidad1.Checked == true)
                    label1.Text = "El " + Roquemon1.Text + " de " + Jugador1.Text + " ha causado un daño de: " +
                                   Convert.ToString(Daño1) + " al " + Roquemon2.Text + "de " + Jugador2.Text +
                                   " usando la habilidad: " + Habilidad1.Text;
                else if (Habilidad2.Checked == true)
                    label1.Text = "El " + Roquemon1.Text + " de " + Jugador1.Text + " ha causado un daño de: " +
                                   Convert.ToString(Daño1) + " al " + Roquemon2.Text + "de " + Jugador2.Text +
                                   " usando la habilidad: " + Habilidad2.Text;
            }
            else if (VelocidadEfectiva1 > VelocidadEfectiva2 && progressBar1.Value > Convert.ToInt32(Daño2))
            {
                progressBar1.Value = progressBar1.Value - Convert.ToInt32(Daño2);
                label3.Text = Convert.ToString(progressBar1.Value);
                if (Habilidad3.Checked == true)
                    label1.Text = "El " + Roquemon2.Text + "de " + Jugador2.Text + "ha causado un daño de: " +
                                   Convert.ToString(Daño2) + " al " + Roquemon1.Text + "de " + Jugador1.Text +
                                   "usando la habilidad: " + Habilidad3.Text;
                else if (Habilidad4.Checked == true)
                    label1.Text = "El " + Roquemon2.Text + "de " + Jugador2.Text + "ha causado un daño de: " +
                                   Convert.ToString(Daño2) + " al " + Roquemon1.Text + "de " + Jugador1.Text +
                                   "usando la habilidad: " + Habilidad4.Text;
            }
            Combatir.Enabled = false;
            Habilidad1.Checked = false;
            Habilidad2.Checked = false;
            Habilidad3.Checked = false;
            Habilidad4.Checked = false;
            timer1.Stop();

        }

        private void Habilidad3_CheckedChanged(object sender, EventArgs e)
        {
            if ((Habilidad3.Checked == true) && (Habilidad1.Checked == true || Habilidad2.Checked == true))
            {
                Combatir.Enabled = true;
            }
        }

        private void Habilidad4_CheckedChanged(object sender, EventArgs e)
        {
            if ((Habilidad4.Checked == true) && (Habilidad1.Checked == true || Habilidad2.Checked == true))
            {
                Combatir.Enabled = true;
            }
        }
    }

}
