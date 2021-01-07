using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    class Quantite
    {
        public Quantite(float nb, Unite u)
        {
            Nombre = nb;
            Unit = u;
        }

        public float Nombre
        {
            get { return nombre; }
            set
            {
                if (nombre < 0)
                {
                    nombre = 0;
                }
                else
                {
                    nombre = value;
                }
            }
        }

        private float nombre;
        public Unite Unit { get; set; }

        private Unite unit;

        public override string ToString()
        {
            return $"{Nombre} {Unit}";
        }
    }
}
