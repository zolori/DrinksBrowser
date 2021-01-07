using Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Vue
{
    /// <summary>
    /// Logique d'interaction pour AjoutAvisWindows.xaml
    /// </summary>
    public partial class AjoutAvisWindows : Window
    {
        public Manager man = (App.Current as App).LeManager;
        public AjoutAvisWindows()
        {
            InitializeComponent();
        }

        private void AddAvis(object sender, RoutedEventArgs e)
        {
            try
            {
                string pseudo = tbuser.Text;
                //Converti le string en Double 
                double note = float.Parse(tbnote.Text);
                string desc = tbavis.Text;

                man.AjouterAvis(man.AlcoolSelectionne, new Avis(pseudo, note, desc, DateTime.Now));
                man.UpdateNoteAvis();
                man.SauvegarderFichier();

                Close();
            }
            catch (Exception ep)
            {
                MessageBox.Show(ep.Message);
            }
        }
    }
}
