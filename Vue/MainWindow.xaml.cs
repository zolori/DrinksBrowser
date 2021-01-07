using Metier;
using System.Windows;
using System.Windows.Controls;

namespace Vue
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Manager man => (App.Current as App).LeManager;

        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = man;
        }


        /// <summary>
        /// rends visible/invisible le Menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMenu(object sender, RoutedEventArgs e)
        {
            if (LeftUC.IsVisible)
                LeftUC.Visibility = Visibility.Collapsed;
            else
                LeftUC.Visibility = Visibility.Visible;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox c = (sender as ComboBox);
            man.Tri_Alcool(((TextBlock)c.SelectedValue).Text);
        }

        private void RandomPopUp(object sender, RoutedEventArgs e)
        {
            if (PopUpUC.IsVisible) PopUpUC.Visibility = Visibility.Hidden;
            else
            {
                //le dataContext de PopUp est set en celui du stackPanel (Alcool)
                
                man.SelectionRandomAlcool();
                PopUpUC.DataContext = man.AlcoolSelectionne;
                PopUpUC.Visibility = Visibility.Visible;
            }
        }
    }
}
