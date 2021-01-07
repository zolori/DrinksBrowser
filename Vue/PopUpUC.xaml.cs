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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vue
{
    /// <summary>
    /// Logique d'interaction pour PopUpUC.xaml
    /// </summary>
    public partial class PopUpUC : UserControl
    {

        public PopUpUC()
        {
            InitializeComponent();    
        }

        private void TextBlock_MouseUp_Fermer(object sender, MouseButtonEventArgs e)
        {
            Visibility = Visibility.Hidden;
        }

        private void AddAvis(object sender, RoutedEventArgs e)
        {
            AjoutAvisWindows addavis = new AjoutAvisWindows();
            
            addavis.Show();
        }
    }
}
