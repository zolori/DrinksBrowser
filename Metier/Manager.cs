using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace Metier
{
    /// <summary>
    /// Classe Manager qui sert de pivot entre vues et metiers
    /// </summary>
    public class Manager
    {
        /// <summary>
        /// Alccol selectionne a l'affichage
        /// </summary>
        public Alcool AlcoolSelectionne { get; set; }

        /// <summary>
        /// Contient tous les alcools
        /// </summary>
        public LivreAlcool livreAlcool = new LivreAlcool();

        /// <summary>
        /// Interface de persistace
        /// </summary>
        private readonly IPersistance persistance;

        /// <summary>
        /// Contient les types d'alcools
        /// </summary>
        public ReadOnlyCollection<TypeAlcool> TypesAlcool { get; private set; }


        /// <summary>
        /// Contient la liste des filtres selctionnes par l'utilisateur (LeftUC)
        /// </summary>
        private readonly ICollection<TypeAlcool> filtresSelectionnes = new Collection<TypeAlcool>();


        /// <summary>
        /// Observable collection contenant les alcool a afficher (RightUC)
        /// </summary>
        public ObservableCollection<Alcool> AlcoolsAffiche { get; private set; }

        /// <summary>
        /// Tri en cours
        /// </summary>
        private string triEnCours = "Nom";

        /// <summary>
        /// nom du fichier json
        /// </summary>
        public static readonly string NOM_JSON = "bd_singleton.json";

        /// <summary>
        /// Constructeur. Prend IPersistance en parametre a qui le manager delegue la gestion de la persistence.
        /// Les alcools sont charges depuis json et les notes des alcools mises a jour en fonction des notes des avis.
        /// </summary>
        /// <param name="pers"></param>
        public Manager(IPersistance pers)
        {
            persistance = pers;
            ChargerFichier();
            
            AlcoolsAffiche = new ObservableCollection<Alcool>(livreAlcool.ListAlcool);
            TypesAlcool = new ReadOnlyCollection<TypeAlcool>(Enum.GetValues(typeof(TypeAlcool)).Cast<TypeAlcool>().ToList());

            UpdateNoteAvis();
        }

        /// <summary>
        /// Filtre les alcools affichés en fonction du contenu de FiltresSelectionnes
        /// Appelle Tri_Alcool afin de trier la liste affichée par le tri en cours
        /// </summary>
        public void Filtre_ListAlcools()
        {
            // Si pas de filtre selectionne, on met a jour la liste des alcools a afficher a partir de la base d'acools
            if (filtresSelectionnes.Count == 0)
            {
                AlcoolsAffiche.Clear();
                foreach (Alcool a in livreAlcool.ListAlcool)
                    AlcoolsAffiche.Add(a);
            }
            // sinon, on filtre la liste des alcools a afficher en fontion des filtres selectionnes
            else
            {
                var listAlcoolsFiltres = livreAlcool.ListAlcool.Where(a => filtresSelectionnes.Contains(a.Type));

                // Met à jour la liste des alcools affichés
                AlcoolsAffiche.Clear();
                foreach (Alcool a in listAlcoolsFiltres)
                    AlcoolsAffiche.Add(a);
            }

            Tri_Alcool(triEnCours);
        }

        /// <summary>
        /// Methode qui tri la collection affichée, en fonction de la selection dans la ComboBox (Nom au démarrage)
        /// </summary>
        /// <param name="s"></param>
        public void Tri_Alcool(string s)
        {
            IList<Alcool> la = null;
            triEnCours = s;

            if (s == "Prix")
            {
                la = AlcoolsAffiche.OrderBy(a => a.Prix).ToList();
            }
            else if (s == "Degré")
            {
                la = AlcoolsAffiche.OrderByDescending(a => a.Degre).ToList();
            }
            else if (s == "Note")
            {
                la = AlcoolsAffiche.OrderByDescending(a => a.Note).ToList();
            }
            else
            {
                la = AlcoolsAffiche.OrderBy(a => a.Nom).ToList();
            }

            AlcoolsAffiche.Clear();
            foreach (Alcool a in la) AlcoolsAffiche.Add(a);
        }

        /// <summary>
        /// Ajouter l'avis b dans la liste d'avis de l'alcool a.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void AjouterAvis(Alcool a, Avis b)
        {
            a.AjouterAvis(b);
        }

        /// <summary>
        /// Ajout d'un alcool dans la liste d'alccols
        /// NON UTILISE POUR LE MOMENT
        /// </summary>
        /// <param name="a"></param>
        public void AjouterAlcool(Alcool a)
        {
            livreAlcool.AjouterAlcool(a);
        }

        /// <summary>
        /// Supprime un alcool de la liste d'alccols
        /// NON UTILISE POUR LE MOMENT
        /// </summary>
        /// <param name="a"></param>
        public void SupprimerAlcool(Alcool a)
        {
            livreAlcool.SupprimerAlcool(a);
        }

        /// <summary>
        /// Ajout d'un filtre dans la liste des filtres selectionnes
        /// </summary>
        /// <param name="TypeAlcool"></param>
        public void AjouterFiltreSelectionne(TypeAlcool t)
        {
            filtresSelectionnes.Add(t);
        }

        /// <summary>
        /// Supprime un filtre de la liste des filtres selectionnes
        /// </summary>
        /// <param name="a"></param>
        public void SupprimerFiltreSelectionne(TypeAlcool t)
        {
            filtresSelectionnes.Remove(t);
        }

        /// <summary>
        /// Met a jour les notes des alcools
        /// </summary>
        public void UpdateNoteAvis()
        {
            foreach(Alcool a in livreAlcool.ListAlcool)
            {
                a.UpdateNote();
            }
        }

        public void SelectionRandomAlcool()
        {
            AlcoolSelectionne =  livreAlcool.GetRandomAlcool();
        }

        /// <summary>
        /// Sauvergarde les alcools dans un fichier json
        /// </summary>
        public void SauvegarderFichier()
        {
            persistance.SauvegarderAlcools(NOM_JSON, livreAlcool.ListAlcool);
        }

        /// <summary>
        /// Charge le fichier json contenant les alcools et avis
        /// </summary>
        public void ChargerFichier()
        {
            foreach (Alcool a in persistance.ChargerAlcools(NOM_JSON))
            {
                livreAlcool.AjouterAlcool(a);
            }
        }

    }

}
