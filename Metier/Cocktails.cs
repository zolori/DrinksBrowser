using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Cocktails
    {
        public Cocktails(string name, string d, float no)
        {
            Nom = name;
            Description = d;
            Note = no;


        }

        public string Description { get; set; }
        private string description;

        public string Nom { get; set; }
        private string nom;

        public float Note { get; set; }
        private float note;

        public override bool Equals(object right)
        {

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

            return this.Equals(right as Cocktails);
        }

        public bool Equals(Cocktails other)
        {
            return (this.Nom.Equals(other.Nom) && this.Description.Equals(other.Description) && this.Note.Equals(other.Note));
        }

        public override int GetHashCode()
        {
            int result = 0;
            result = Nom.GetHashCode() * Note.GetHashCode() * Description.GetHashCode();
            return result;

        }
    }

}
