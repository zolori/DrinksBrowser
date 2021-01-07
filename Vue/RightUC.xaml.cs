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
    /// Logique d'interaction pour RightUC.xaml
    /// </summary>
    public partial class RightUC : UserControl
    {
        public Manager man => (App.Current as App).LeManager;
        public RightUC()
        {
            InitializeComponent();
        }

        private void StackPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (PopUpUC.IsVisible)
                PopUpUC.Visibility = Visibility.Hidden;
            else
            {
                //le dataContext de PopUp est set en celui du stackPanel (Alcool)
                PopUpUC.DataContext = man.AlcoolSelectionne;
                PopUpUC.Visibility = Visibility.Visible;
            }
        }

        //private void SearchBar(object sender, RoutedEventArgs e)
        //{
        //    Alcool a = new Alcool();
        //    try { a.Nom = sbar.Text; }
        //    catch { MessageBox.Show("Entrez un nom d'alcool à rechercher"); }
        //    if (man.LivreAlcool.ListAlcool.Contains(a))
        //    {
        //        int i;
        //        i = man.LivreAlcool.ListAlcool.IndexOf(a);
        //        man.AlcoolSelectionne = man.LivreAlcool.ListAlcool[i];


        //        if (PopUpUC.IsVisible)
        //            PopUpUC.Visibility = Visibility.Hidden;
        //        else
        //        {
        //            //le dataContext de PopUp est set en celui du stackPanel (Alcool)

        //            PopUpUC.DataContext = man.AlcoolSelectionne;
        //            PopUpUC.Visibility = Visibility.Visible;
        //        }
        //    }
        //    else
        //    {
        //        if (a.Nom != null) MessageBox.Show("Alcool inexistant");
        //    }
            

    }
}
