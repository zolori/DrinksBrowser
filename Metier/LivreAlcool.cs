using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    /// <summary>
    /// Gere l'ajout et la suppresion des alcools.
    /// </summary>
    public class LivreAlcool
    {
        /// <summary>
        /// Contient la liste des alcools
        /// </summary>
        private ObservableCollection<Alcool> listAlcool = new ObservableCollection<Alcool>();

        /// <summary>
        /// Encapsulation de liste d'alcools privee
        /// </summary>
        public ReadOnlyObservableCollection<Alcool> ListAlcool { get; private set; }


        /// <summary>
        /// Constructeur
        /// </summary>
        public LivreAlcool()
        {
            ListAlcool = new ReadOnlyObservableCollection<Alcool>(listAlcool);
        }


        /// <summary>
        /// Ajoute l'alccol si pas deja present
        /// </summary>
        /// <param name="a"> Alcool à ajouter</param>
        /// <returns>return true si l'ajout est réussi sinon false.</returns>
        public bool AjouterAlcool(Alcool a)
        {
            if (listAlcool.Contains(a))
            {
                return false;
            }
            else
            {
                listAlcool.Add(a);
                return true;
            }
        }

        /// <summary>
        /// Supprime l'alcool si present
        /// </summary>
        /// <param name="a">Alcool à supprimer</param>
        /// <returns>return true si il est supprimé sinon faux.</returns>
        public Boolean SupprimerAlcool(Alcool a)
        {
            if (listAlcool.Contains(a))
            {
                return false;
            }
            else
            {
                listAlcool.Remove(a);
                return true;
            }
        }

        public Alcool GetRandomAlcool()
        {
            Random r = new Random();
            return listAlcool[r.Next(listAlcool.Count)];
        }

    }

}
