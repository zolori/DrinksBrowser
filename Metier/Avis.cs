using System;
using System.Runtime.Serialization;


namespace Metier
{
    /// <summary>
    /// Classe métier Avis des utilisateurs de l'application qui contient 4 proprietés principales: Pseudo, Note, Date et Commentaire
    /// 2 avis sont égaux si les pseudos le sont.
    /// </summary>
    [DataContract]
    public class Avis : IEquatable<Avis>
    {
        /// <summary>
        /// Constructeur Avis prenant pseudo, note, commentaire et date en parametres
        /// </summary>
        /// <param name="pseudo">pseudo de l'avis</param>
        /// <param name="note">note de l'avis</param>
        /// <param name="commentaire">commentaire de l'avis</param>
        /// <param name="date">date de l'avis</param>
        public Avis(string pseudo, Double note, string commentaire, DateTime date)
        {
            Commentaire = commentaire;
            Pseudo = pseudo;
            Note = note;
            Date = date;
        }

        /// <summary>
        /// Pseudo getter/setter: le pseudo de l'utilisateur.
        /// Ne peut etre null, vide ou contenir seulement des caractères vides ==> ArgumentException
        /// </summary>
        [DataMember]
        public string Pseudo
        {
            get { return pseudo; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(" \"Pseudo\" ne peut être null, vide ou constitué de caractères vides");
                }
                else pseudo = value;
            }
        }
        private string pseudo;

        /// <summary>
        /// Note getter/setter: la note attribué par l'utilisateur a l'alcool concerné.
        /// La note doit etre comprise entre 0 et 5  ==> ArgumentException
        /// </summary>
        [DataMember]
        public Double Note
        {
            get { return note; }
            private set
            {
                if (value < Alcool.CONST_NOTE_MIN || value > Alcool.CONST_NOTE_MAX)
                {
                    throw new ArgumentException($"\"Note\" doit être comprise entre {Alcool.CONST_NOTE_MIN} et {Alcool.CONST_NOTE_MAX}");
                }
                else note = value;
            }
        }
        private Double note;

        /// <summary>
        /// Date getter/setter: la date a laquelle l'avis a été donné
        /// </summary>
        [DataMember]
        public DateTime Date { get; private set; }

        /// <summary>
        /// Commentaire getter/setter: le commentaire de l'avis.
        /// Ne peut être null, vide ou constitué de caractères vides ==> ArgumentException
        /// </summary>
        [DataMember]
        public string Commentaire
        {
            get { return commentaire; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(" \"Commentaire\" ne peut être null, vide ou constitué de caractères vides");
                }
                else commentaire = value;
            }
        }
        private string commentaire;


        ///
        /// 'Surcharge du Equals' pour pouvoir comparer uniquement sur le pseudo
        /// 
        
        /// <summary>
        /// Compare les deux avis après avoir vérifier si other n'était pas null et si il â le même type que this
        /// et si ils n'étaient pas à la même place mémoire.
        /// </summary>
        /// <param name="right">Avis a comparer</param>
        /// <returns>true si egaux/returns>
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

            return this.Equals(right as Avis);
        }

        /// <summary>
        /// Deux avis sont identiques s'ils ont le meme pseudo
        /// </summary>
        /// <param name="other">Avis a comparer</param>
        /// <returns>true si egaux/returns>
        public bool Equals(Avis other)
        {
            return Pseudo == other.Pseudo ? true : false;
        }

        /// <summary>
        /// Surcharge qui retourne le hashCode du Pseudo 
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            return Pseudo.GetHashCode();
        }
    }
}
