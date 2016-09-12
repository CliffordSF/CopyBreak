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
using Brooks.ennuiWare.CopyBreak.Engine;

namespace Brooks.ennuiWare.CopyBreak.Windows
{
    /// <summary>
    /// Interaction logic for copyBreakLetterSelector.xaml
    /// </summary>
    public partial class copyBreakLetterSelector : Window
    {
        public Letter? SelectedLetter
        {
            get
            {
                return selectedLetter;
            }
        }

        private Letter? selectedLetter;

        public copyBreakLetterSelector()
        {
            InitializeComponent();
            textBoxLetterSelected.Focus();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void textBoxLetterSelected_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBoxLetterSelected.Text.Length == 1)
            {
                selectedLetter = (Letter)Enum.Parse(typeof(Letter), textBoxLetterSelected.Text, true);
                this.Close();
            }
        }
            
    }
}
