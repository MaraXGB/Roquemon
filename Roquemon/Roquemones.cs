using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roquemon
{
    class Roquemones
    {
        private string mNombre;
        private int mVida, mAtaque, mDefensa, mVelocidad;
        private double mCritico;

        public string Nombre { get => mNombre; set => mNombre = value; }
        public int Vida { get => mVida; set => mVida = value; }
        public int Ataque { get => mAtaque; set => mAtaque = value; }
        public int Defensa { get => mDefensa; set => mDefensa = value; }
        public int Velocidad { get => mVelocidad; set => mVelocidad = value; }
        public double Critico { get => mCritico; set => mCritico = value; }

        //Constructores
        public Roquemones()
        {
            //mNombre = "";
            //mVida = 0;
            //mAtaque = 0;
            //mDefensa = 0;
            //mVelocidad = 0;
            //mCritico = 0;
        }


    }
}
