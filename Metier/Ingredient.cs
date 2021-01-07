using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    class Ingredient
    {
        public String Aliment { get; set; }

        private String aliment;

        public Quantite Quantit { get; set; }

        private Quantite quantit;

        public Ingredient(String a, Quantite q)
        {
            Aliment = a;
            Quantit = q;
        }

        public override string ToString()
        {
            return $"{Quantit} {Aliment}";
        }

        public override bool Equals(object right)
        {
            //check null
            if (object.ReferenceEquals(right, null))
            {
                return false;
            }

            if (object.ReferenceEquals(this, right))
            {
                return true;
            }

            if (this.GetType() != right.GetType())
            {
                return false;
            }

            return this.Equals(right as Ingredient);
        }

        public bool Equals(Ingredient other)
        {
            return (this.Aliment.Equals(other.Aliment) && this.Quantit.Equals(other.Quantit));
        }


        public override int GetHashCode()
        {
            int result;
            result = Aliment.GetHashCode() * Quantit.GetHashCode();
            return result;
        }

    }
}
