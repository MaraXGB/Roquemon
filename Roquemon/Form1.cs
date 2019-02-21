using System;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Roquemon
{
    public partial class Roquemon : Form
    {
        //-----------------------Variables----------------------------------
        //Varible utilizada para habilitar el boton Combatir, luego de ser elegidos los roquemones
        int Habilitador = 0;
        //para los casos donde la habilidad dura por 3 turnos.
        int Turno1 = 0, Turno2 = 0;
        int Turno3 = 0, Turno4 = 0;
        //Caracteristicas del Roquemon elegido por el Jugador 1
        double Vida1 = 0;
        int Velocidad1 = 0;
        int Ataque1 = 0;
        int Defensa1 = 0;
        double Critico1 = 0;
        //Caracteristicas del Roquemon elegido por el Jugador 1
        double Vida2 = 0;
        int Velocidad2 = 0;
        int Ataque2 = 0;
        int Defensa2 = 0;
        double Critico2 = 0;
        //Calculos correspondiente a quien atacara primero y el daño que causaran los Roquemones
        int VelocidadEfectiva1 = 0;
        int VelocidadEfectiva2 = 0;
        double Daño1 = 0;
        double Daño2 = 0;
        // Variable que establece el nombre del Jugador Ganador y el de su Roquemon.
        string Ganador = "";
        //Variable utilizada para establecer de forma aleatoria el que atacara primero cuando las velocidades efectivas son iguales.
        int PrimeroAtacando;
        //Declaraciones de cada roquemon en la clase Roquemones
        Roquemones Aguamon = new Roquemones();
        Roquemones Fuegomon = new Roquemones();
        Roquemones Plantamon = new Roquemones();

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

        public Roquemon()
        {
            InitializeComponent();
            inicializacion();

            //Ingreso del nombre de los jugadores
            string Jugador1 = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nombre del Jugador", "Jugador 1", "");
            if (Jugador1 == "") this.Jugador1.Text = "Jugador1";
            else this.Jugador1.Text = Jugador1;
            string Jugador2 = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nombre del Jugador", "Jugador 2", "");
            if (Jugador2 == "") this.Jugador2.Text = "Jugador2";
            else this.Jugador2.Text = Jugador2;

            //--------------------------Lectura del archivo de Texto-----------------------------------
            string Linea = "";
            string[] rCaracteristicas = { };
            char[] CharDelimitadores = { ',', '%', '\r', '\n' };

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


        private void button1_Click(object sender, EventArgs e)
        {
            //Carga los valores base de las caracteristicas de los Roquemones seleccionados
            CaracteristicasBase(Roquemon1.Text, true);
            CaracteristicasBase(Roquemon2.Text, false);
            //Establece las Habilidades seleccionadas por el jugador en su respectivo roquemon
            Habilidades(Habilidad1.Checked, Habilidad2.Checked, Habilidad1.Text,
                        Habilidad2.Text, true);
            Habilidades(Habilidad3.Checked, Habilidad4.Checked, Habilidad3.Text,
                        Habilidad4.Text, false);
            //Calculo de Velocidad Efectiva y Daño
            Resultados();
            //Validación para el caso que la velocidad efectiva de ambos jugadores sea la misma
            if (VelocidadEfectiva1 == VelocidadEfectiva2)
            {
                Random Rnd = new Random();
                PrimeroAtacando = Rnd.Next(0, 1);
                if (PrimeroAtacando == 0) VelocidadEfectiva1 = VelocidadEfectiva1 + 1;
                else VelocidadEfectiva2 = VelocidadEfectiva2 + 1;
            }

            PrimeroAtacar();

            //Envia un mensaje con el nombre del jugador ganador con el roquemon elegido, e inicializa los controles si desean jugar nuevamente
            if (progressBar1.Value == 0 || progressBar2.Value == 0)
            {
                SeleccionarGanador();
            }
            else timer1.Start();  // se utiliza un timer para que se vean ambos ataques con sus respectivos ataques descriptivos

        }
        private void CaracteristicasBase(string NombreRoquemon, bool Jugador)
        {
            //Jugador 1 representa el bool "true" y el Jugador 2 representa el bool "false"
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
            //Jugador 1 representa el bool "true" y el Jugador 2 representa el bool "false"
            if (Jugador == true)
            {
                //Mantiene la habilidad Furia y Fotosintesis por 3 turnos en el caso de ser seleccionada
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
            //El radiobutton Habilidad1 puede tener 3 habilidades de los roquemones Ataque Rápido, Flama y Latigo
            if (Habilidad1 == true)
            {

                if (NombreHabilidad1 == "Ataque Rápido")
                {
                    if (Jugador == true) Velocidad1 = Aguamon.Velocidad + 65; //Jugador1 : Aguamon: Establece velocidad en 100
                    else if (Jugador == false) Velocidad2 = Aguamon.Velocidad + 65; //Jugador2 : Aguamon: Establece velocidad en 100
                }
                else if (NombreHabilidad1 == "Flama")
                {
                    if (Jugador == true) Ataque1 = Fuegomon.Ataque + 5; // Jugador1 : Fuegomon: incrementa un bono de 5 en Ataque
                    else if (Jugador == false) Ataque2 = Fuegomon.Ataque + 5; //Jugador2 : Fuegomon: incrementa un bono de 5 en Ataque
                }
                else if (NombreHabilidad1 == "Latigo")
                {
                    if (Jugador == true) Ataque1 = Plantamon.Ataque + 5; // Jugador1 : Plantamon:incrementa un bono de 5 en Ataque
                    else if (Jugador == false) Ataque2 = Plantamon.Ataque + 5; //Jugador2 : Plantamon: incrementa un bono de 5 en Ataque
                }

            } //El radiobutton Habilidad2 puede tener 3 habilidades de los roquemones Torrente, Furia, Fotosintesis
            else if (Habilidad2 == true)
            {
                if (NombreHabilidad2 == "Torrente")
                {
                    if (Jugador == true) Ataque1 = Aguamon.Ataque + 5; // Jugador1 : Aguamon:incrementa un bono de 5 en Ataque
                    else if (Jugador == false) Ataque1 = Aguamon.Ataque + 5; // Jugador2 : Aguamon:incrementa un bono de 5 en Ataque
                }
                else if (NombreHabilidad2 == "Furia")
                {
                    if (Jugador == true)
                    {
                        Critico1 = Fuegomon.Critico + 0.2; // Jugador1 : Fuegomon: incrementa un 20% en el critico por 3 turnos
                        Turno1 = 3;
                    }
                    else if (Jugador == false)
                    {
                        Critico2 = Fuegomon.Critico + 0.2; // Jugador2 : Fuegomon: incrementa un 20% en el critico por 3 turnos
                        Turno1 = 3;
                    }
                }
                else if (NombreHabilidad2 == "Fotosintesis")
                {
                    if (Jugador == true)
                    {
                        Defensa1 = Plantamon.Defensa + 5; // Jugador1 : Plantamon: incrementa un bono de 5 en Defensa por 3 turnos
                        Turno3 = 3;
                    }
                    else if (Jugador == false)
                    {
                        Defensa2 = Plantamon.Defensa + 5; // Jugador1 : Plantamon: incrementa un bono de 5 en Defensa por 3 turnos
                        Turno4 = 3;
                    }
                }
            }
        }

        private void Resultados()
        {
            Random Aleatorio = new Random();
            VelocidadEfectiva1 = Velocidad1 + Aleatorio.Next(-10, 10);
            VelocidadEfectiva2 = Velocidad2 + Aleatorio.Next(-10, 10);
            Daño1 = (Ataque1 + Aleatorio.Next(-7, 7) - Defensa2) * (Critico1 + 1);
            if (Daño1 < 0) Daño1 = 0; //Valida que el daño sera nulo, en el caso que la defensa sea mayor al daño 
            Daño2 = (Ataque2 + Aleatorio.Next(-7, 7) - Defensa1) * (Critico2 + 1);
            if (Daño2 < 0) Daño2 = 0; //Valida que el daño sera nulo, en el caso que la defensa sea mayor al daño 

        }
        private void PrimeroAtacar()
        {
            //Compara las velocidades para determinar quien ataca primero, si el que recibe el daño queda con vida positiva luego del ataque
            //disminuye el progressbar en base a la vida restante y envia el mensaje descriptivo
            string Habilidad = "";
            if (VelocidadEfectiva1 > VelocidadEfectiva2 && progressBar2.Value > Convert.ToInt32(Daño1))
            {
                progressBar2.Value = progressBar2.Value - Convert.ToInt32(Daño1);
                label3.Text = Convert.ToString(progressBar2.Value);
                if (Habilidad1.Checked == true) Habilidad = Habilidad1.Text;
                else if (Habilidad2.Checked == true) Habilidad = Habilidad2.Text;
                label1.Text = "El " + Roquemon1.Text + " de " + Jugador1.Text + " ha causado un daño de: " +
                                   Convert.ToString(Daño1) + "\n al " + Roquemon2.Text + "de " + Jugador2.Text +
                                   " usando la habilidad: " + Habilidad;
            }
            else if (VelocidadEfectiva1 < VelocidadEfectiva2 && progressBar1.Value > Convert.ToInt32(Daño2))
            {
                progressBar1.Value = progressBar1.Value - Convert.ToInt32(Daño2);
                label2.Text = Convert.ToString(progressBar1.Value);
                if (Habilidad3.Checked == true) Habilidad = Habilidad3.Text;
                else if (Habilidad4.Checked == true) Habilidad = Habilidad4.Text;
                label1.Text = "El " + Roquemon2.Text + " de " + Jugador2.Text + " ha causado un daño de: " +
                                   Convert.ToString(Daño2) + "\n al " + Roquemon1.Text + " de " + Jugador1.Text +
                                   " usando la habilidad: " + Habilidad;
            }//En el casi que el que recibe el daño se le acabe la vida luego de ser atacado, establece al ganador
            // coloca el progressbar del perdedor en 0 y envia el mensaje descriptivo
            else if (VelocidadEfectiva1 > VelocidadEfectiva2 && progressBar2.Value <= Convert.ToInt32(Daño1))
            {
                progressBar2.Value = 0;
                label3.Text = "0";
                if (Habilidad1.Checked == true) Habilidad = Habilidad1.Text;
                if (Habilidad2.Checked == true) Habilidad = Habilidad2.Text;
                label1.Text = "El " + Roquemon1.Text + " de " + Jugador1.Text + " ha causado un daño de: " +
                                   Convert.ToString(Daño1) + "\n al " + Roquemon2.Text + " de " + Jugador2.Text +
                                   " usando la habilidad: " + Habilidad;
                Ganador = Jugador1.Text + " con " + Roquemon1.Text;
            }
            else if (VelocidadEfectiva1 < VelocidadEfectiva2 && progressBar1.Value <= Convert.ToInt32(Daño2))
            {
                progressBar1.Value = 0;
                label2.Text = "0";
                if (Habilidad3.Checked == true) Habilidad = Habilidad3.Text;
                if (Habilidad4.Checked == true) Habilidad = Habilidad4.Text;
                label1.Text = "El " + Roquemon2.Text + " de " + Jugador2.Text + " ha causado un daño de: " +
                                   Convert.ToString(Daño2) + "\n al " + Roquemon1.Text + " de " + Jugador1.Text +
                                   " usando la habilidad: " + Habilidad;
                Ganador = Jugador2.Text + " con " + Roquemon2.Text;

            }
        }

        private void SegundoAtacar()
        {    //Se Compara las velocidades para determinar quien atacara de segundo, si el que recibe el daño queda con vida positiva luego del ataque
            //disminuye el progressbar en base a la vida restante y envia el mensaje descriptivo
            if (VelocidadEfectiva1 < VelocidadEfectiva2 && progressBar2.Value > Convert.ToInt32(Daño1))
            {
                progressBar2.Value = progressBar2.Value - Convert.ToInt32(Daño1);
                label3.Text = Convert.ToString(progressBar2.Value);
                if (Habilidad1.Checked == true)
                    label1.Text = "El " + Roquemon1.Text + " de " + Jugador1.Text + " ha causado un daño de: " +
                                   Convert.ToString(Daño1) + "\n al " + Roquemon2.Text + "de " + Jugador2.Text +
                                   " usando la habilidad: " + Habilidad1.Text;
                else if (Habilidad2.Checked == true)
                    label1.Text = "El " + Roquemon1.Text + " de " + Jugador1.Text + " ha causado un daño de: " +
                                   Convert.ToString(Daño1) + "\n al " + Roquemon2.Text + " de " + Jugador2.Text +
                                   " usando la habilidad: " + Habilidad2.Text;
            }
            else if (VelocidadEfectiva1 > VelocidadEfectiva2 && progressBar1.Value > Convert.ToInt32(Daño2))
            {
                progressBar1.Value = progressBar1.Value - Convert.ToInt32(Daño2);
                label2.Text = Convert.ToString(progressBar1.Value);
                if (Habilidad3.Checked == true)
                    label1.Text = "El " + Roquemon2.Text + " de " + Jugador2.Text + " ha causado un daño de: " +
                                   Convert.ToString(Daño2) + "\n al " + Roquemon1.Text + " de " + Jugador1.Text +
                                   " usando la habilidad: " + Habilidad3.Text;
                else if (Habilidad4.Checked == true)
                    label1.Text = "El " + Roquemon2.Text + " de " + Jugador2.Text + " ha causado un daño de: " +
                                   Convert.ToString(Daño2) + "\n al " + Roquemon1.Text + " de " + Jugador1.Text +
                                   " usando la habilidad: " + Habilidad4.Text;
            }//En el casi que el que recibe el daño se le acabe la vida luego de ser atacado, establece al ganador
            // coloca el progressbar del perdedor en 0 y envia el mensaje descriptivo
            else if (VelocidadEfectiva1 < VelocidadEfectiva2 && progressBar2.Value <= Convert.ToInt32(Daño1))
            {
                progressBar2.Value = 0;
                label3.Text = "0";
                if (Habilidad1.Checked == true)
                    label1.Text = "El " + Roquemon1.Text + " de " + Jugador1.Text + " ha causado un daño de: " +
                                   Convert.ToString(Daño1) + "\n al " + Roquemon2.Text + " de " + Jugador2.Text +
                                   " usando la habilidad: " + Habilidad1.Text;
                if (Habilidad2.Checked == true)
                    label1.Text = "El " + Roquemon1.Text + " de " + Jugador1.Text + " ha causado un daño de: " +
                                   Convert.ToString(Daño1) + "\n al " + Roquemon2.Text + " de " + Jugador2.Text +
                                   " usando la habilidad: " + Habilidad2.Text;
                Ganador = Jugador1.Text + " con " + Roquemon1.Text;

            }
            else if (VelocidadEfectiva1 > VelocidadEfectiva2 && progressBar1.Value <= Convert.ToInt32(Daño2))
            {
                progressBar1.Value = 0;
                label2.Text = "0";
                if (Habilidad3.Checked == true)
                    label1.Text = "El " + Roquemon2.Text + " de " + Jugador2.Text + " ha causado un daño de: " +
                                   Convert.ToString(Daño2) + "\n al " + Roquemon1.Text + " de " + Jugador1.Text +
                                   " usando la habilidad: " + Habilidad3.Text;
                if (Habilidad4.Checked == true)
                    label1.Text = "El " + Roquemon2.Text + " de " + Jugador2.Text + " ha causado un daño de: " +
                                   Convert.ToString(Daño2) + "\n al " + Roquemon1.Text + " de " + Jugador1.Text +
                                   " usando la habilidad: " + Habilidad4.Text;
                Ganador = Jugador2.Text + " con " + Roquemon2.Text;

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // habilita el boton combatir cuando ambos jugadores hayan elegido los roquemones
            Habilitador++;
            if (Habilitador == 2)
            {
                Combatir.Visible = true;
                Combatir.Enabled = false;
                Habilitador = 0;
            }
            //Carga la interfaz correspondiente con el roquemon seleccionado para el jugador
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
            // habilita el boton combatir cuando ambos jugadores hayan elegido los roquemones
            Habilitador++;
            if (Habilitador == 2)
            {
                Combatir.Visible = true;
                Combatir.Enabled = false;
                Habilitador = 0;
            }
            //Carga la interfaz correspondiente con el roquemon seleccionado para el jugador
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            SegundoAtacar();
            timer1.Stop();

            Combatir.Enabled = false;
            Habilidad1.Checked = false;
            Habilidad2.Checked = false;
            Habilidad3.Checked = false;
            Habilidad4.Checked = false;
            if (progressBar1.Value == 0 || progressBar2.Value == 0)
            {
                SeleccionarGanador();
            }
        }
        private void SeleccionarGanador()
        {
            Thread.Sleep(1500);
            DialogResult Reiniciar;

            Reiniciar = MessageBox.Show("HAS GANADO \n" + Ganador + "\n ¿Quieren Jugar de nuevo?", "GANADOR", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (Reiniciar == System.Windows.Forms.DialogResult.Yes)
            {
                groupBox5.Visible = true;
                groupBox6.Visible = true;
                Combatir.Visible = false;
                label1.Text = "";
                AguamonD.Checked = false;
                FuegomonD.Checked = false;
                PlantamonD.Checked = false;
                AguamonI.Checked = false;
                FuegomonI.Checked = false;
                PlantamonI.Checked = false;
                inicializacion();
                Ganador = "";
                string Jugador1 = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nombre del Jugador", "Jugador 1", "");
                if (Jugador1 == "") this.Jugador1.Text = "Jugador1";
                else this.Jugador1.Text = Jugador1;
                string Jugador2 = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nombre del Jugador", "Jugador 2", "");
                if (Jugador2 == "") this.Jugador2.Text = "Jugador2";
                else this.Jugador2.Text = Jugador2;
            }
            else Close();
        }
        private void progressBar2_Click(object sender, EventArgs e)
        {

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