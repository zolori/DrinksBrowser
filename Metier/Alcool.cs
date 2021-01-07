using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    /// <summary>
    /// Classe métier Alccol
    /// 2 alccols sont égaux si les noms le sont.
    /// </summary>
    [DataContract]
    public class Alcool : IEquatable<Alcool>, INotifyPropertyChanged
    {
        public const double CONST_NOTE_MAX = 5;
        public const double CONST_NOTE_MIN = 0;

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// La collection Observable des avis sur cet alcool
        /// </summary>
        [DataMember]
        public ObservableCollection<Avis> ListAvis { get; set; } = new ObservableCollection<Avis>();

        /// <summary>
        /// Constructeur Alcool prenant nom, image, type et degre en parametres
        /// </summary>
        /// <param name="nom">nom de l'acool</param>
        /// <param name="image">nom de l'image de l'acool</param>
        /// <param name="type">TypeAlcool de l'acool</param>
        /// <param name="float">degre de l'acool</param>
        public Alcool(string nom, string image, TypeAlcool type, string description, float degre, float prix)
        {
            Nom = nom;
            Image = image;
            Type = type;
            Degre = degre;
            Description = description;
            Prix = prix;
        }

        /// <summary>
        /// Constructeur Alcool prenant en parametre un avis en parametre en plus des parameters du constructeur précédent.
        /// </summary>
        /// <param name="nom">nom de l'acool</param>
        /// <param name="image">nom de l'image de l'acool</param>
        /// <param name="type">TypeAlcool de l'acool</param>
        /// <param name="float">degre de l'acool</param>
        /// <param name="Avis">avis de l'acool</param>
        public Alcool(string nom, string image, TypeAlcool type, string description, float degre, float prix, Avis avis) :
            this(nom, image, type, description, degre, prix)
        { 
            ListAvis.Add(avis);
        }

        /// <summary>
        /// Constructeur alcool vide
        /// </summary>
        public Alcool()
        {
        }

        /// <summary>
        /// Nom getter/setter: le nom de l'alcool.
        /// Ne peut etre null, vide ou contenir seulement des caractères vides ==> ArgumentException
        /// </summary>
        [DataMember]
        public string Nom
        {
            get { return nom; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(" \"Nom\" ne peut être null, vide ou constitué de caractères vides");
                }
                else nom = value;
            }
        }
        private string nom;

        /// <summary>
        /// Type getter/setter: le type de l'alcool.
        /// Doit faire parti de l'enum TypeAlcool ==> ArgumentException
        /// </summary>
        [DataMember]
        public TypeAlcool Type
        {
            get { return type; }
            private set
            {
                // Le type doit faire parti de l'enum TypeAlcool
                if (!Enum.IsDefined(typeof(TypeAlcool), value))
                {
                    throw new ArgumentException(" \"Type\" doit être d'un type existant");
                }
                else type = value;
            }
        }
        private TypeAlcool type;

        /// <summary>
        /// Note getter/setter: la note moyenne des avis attribué a l'alcool.
        /// La note doit etre comprise entre {CONST_NOTE_MIN} et {CONST_NOTE_MAX} ==> ArgumentException
        /// Notification de changement de la note sur le setter
        /// </summary>
        public Double Note
        {
            get { return note; }
            private set
            {
                if (value < CONST_NOTE_MIN || value > CONST_NOTE_MAX)
                {
                    throw new ArgumentException($" \"Note\" doit être comprise entre {CONST_NOTE_MIN} et {CONST_NOTE_MAX}");
                }
                else
                {
                    note = value;
                    OnPropertyChanged(nameof(note));
                }

            }
        }
        private Double note;

        /// <summary>
        /// Image getter/setter: le chemin de l'image
        /// </summary>
        [DataMember]
        public string Image { get; private set; }

        /// <summary>
        /// Description getter/setter: la description de l'alcool.
        /// Ne peut etre null, vide ou contenir seulement des caractères vides ==> ArgumentException
        /// </summary>
        [DataMember]
        public string Description
        {
            get { return description; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(" \"Description\" ne peut être null, vide ou constitué de caractères vides");
                }
                else description = value;
            }
        }
        private string description;

        /// <summary>
        /// Prix getter/setter: le prix de l'alcool.
        /// Ne peut être négatif ou nul ==> ArgumentException
        /// </summary>
        [DataMember]
        public double Prix
        {
            get { return prix; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(" \"prix\" ne peut pas être négatif ou nul");
                }
                else prix = value;
            }
        }
        private double prix;

        /// <summary>
        /// Degre getter/setter: le degre de l'alcool.
        /// Ne peut pas être négatif ou nul => ArgumentException
        /// </summary>
        [DataMember]
        public float Degre
        {
            get { return degre; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(" \"Degre\" ne peut pas être négatif ou nul");
                }
                else degre = value;
            }
        }
        private float degre;

        /// <summary>
        /// Méthode qui ajoute un avis
        /// l'avis ne doit pas déjà exister.
        /// </summary>
        /// <param name="a">avis a ajouter</param>
        public void AjouterAvis(Avis a)
        {
            if (!ListAvis.Contains(a)) ListAvis.Add(a);
        }

        /// <summary>
        /// Met à jour la note égale à la moyenne des notes des avis.
        /// </summary>
        public void UpdateNote()
        {
            Note = (ListAvis.Count != 0) ? ListAvis.Average(avis => avis.Note) : 0;
        }


        ///
        /// 'Surcharge du Equals' pour pouvoir comparer uniquement sur le pseudo
        /// 

        /// <summary>
        /// Compare les deux alcools après avoir vérifier si other n'était pas null et si il â le même type que this
        /// et si ils n'étaient pas à la même place mémoire.
        /// </summary>
        /// <param name="right">Alcool a comparer</param>
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

            return this.Equals(right as Alcool);
        }

        /// <summary>
        /// Regarde si les deux alcools ont le meme nom.
        /// </summary>
        /// <param name="other">alcool a comparer</param>
        /// <returns>false si les deux noms sont differents sinon return true.</returns>
        public bool Equals(Alcool other)
        {
            return (this.Nom == other.Nom);
        }

        public override int GetHashCode()
        {
            return Nom.GetHashCode();
        }
        public override string ToString()
        {
            return $"{Nom}";
        }

        /// <summary>
        /// Appelée au moment du chargement du fichier Alcool.
        /// Créé une nouvelle liste d'Avis
        /// </summary>
        /// <param name="sc"></param>
        [OnDeserializing]
        public void Init(StreamingContext sc = new StreamingContext())
        {
            ListAvis = new ObservableCollection<Avis>();
        }
    }
}
