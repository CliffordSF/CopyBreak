using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Brooks.ennuiWare.CopyBreak.Windows
{
    /// <summary>
    /// Interaction logic for newGame.xaml
    /// </summary>
    public partial class selectADeckWindow : Window
    {     
        public string SelectedColor { get; set; }

        public selectADeckWindow()
        {
            InitializeComponent();
        }

        private void selectDeckOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BlueDeck_Click(object sender, RoutedEventArgs e)
        {
            SelectedColor = "Blue";
        }

        private void RedDeck_Click(object sender, RoutedEventArgs e)
        {
            SelectedColor = "Red";
        }

        private void CartoonDeck_Click(object sender, RoutedEventArgs e)
        {
            SelectedColor = "Cartoon";
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
   