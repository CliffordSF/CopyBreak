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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Windows.Forms;

namespace Brooks.ennuiWare.CopyBreak.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Begin section added for transparent window...calls ExtendGlassFrame function from GlassHelper class
        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            // This can't be done any earlier than the SourceInitialized event:
            GlassHelper.ExtendGlassFrame(this, new Thickness(-1));
          
        }

        private void surfaceButton4_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
      
        private void surfaceButton3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.MessageBox.Show("Thank you for your purchase! ennuiWare (c) 2010", "Thanks!");
        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

       

      
        //End section added for transparent window
            //int backChoice = 0; // Customer selects Blue (0), Red (1) or Cartoon (2) as color for card background
        }
    }

