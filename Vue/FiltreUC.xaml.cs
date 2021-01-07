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
        public RightUC()
        {
            InitializeComponent();

            Alcool a1 = new Alcool()
            {
                Nom = "whisky",
                Note = 4,
                Image = "Images/Label 5 CB.jpg"
            };

            Alcool a2 = new Alcool()
            {
                Nom = "Gin",
                Note = 2,
                Image = "Images/gordons_gin.png"
            };

            List<Alcool> l1 = new List<Alcool>()
            {
                a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,
                a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,
                a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,
                a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,
                a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,
                a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,
                a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2,a1,a2
            };

            lvAlcool.ItemsSource = l1;
        }

        private void StackPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (PopUpUC.IsVisible)
                PopUpUC.Visibility = Visibility.Hidden;
            else
            {
                //le dataContext de PopUp est set en celui du stackPanel (Alcool)
                PopUpUC.DataContext = (sender as StackPanel).DataContext;
                PopUpUC.Visibility = Visibility.Visible;
            }
        }
    }
}
