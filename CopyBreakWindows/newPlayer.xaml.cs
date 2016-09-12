using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;

namespace Brooks.ennuiWare.CopyBreak.Windows
{
    /// <summary>
    /// Interaction logic for newPlayer.xaml
    /// </summary>
    public partial class newPlayer : Window
    {
        public newPlayer()
        {
            InitializeComponent();
            userNameTextBox.Focus();
        }

        private void userInputOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
