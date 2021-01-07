using Metier;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vue
{
    /// <summary>
    /// Logique d'interaction pour LeftUC.xaml
    /// </summary>
    public partial class LeftUC : UserControl
    {
        public Manager man => (App.Current as App).LeManager;
        public LeftUC()
        {
            InitializeComponent();
        }

        private void CheckBox_Changed(object sender, RoutedEventArgs e)
        {
            CheckBox c = (sender as CheckBox);

            bool isChecked = false;
            if (c.IsChecked.HasValue && c.IsChecked.Value) isChecked = true;

            if (isChecked)
                man.AjouterFiltreSelectionne((TypeAlcool)c.DataContext);
            else
                man.SupprimerFiltreSelectionne((TypeAlcool)c.DataContext);

            man.Filtre_ListAlcools();
        }
    }
}
