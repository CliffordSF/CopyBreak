using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace WPCopyBreak
    {
    public partial class Page1 : PhoneApplicationPage
        {
        public Page1()
            {
            InitializeComponent();
            this.RotateStoryBoard.Begin();
            }

        private void dealButton_Click(object sender, RoutedEventArgs e)
            {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }

        private void RotateStoryboard_Completed(object sender, EventArgs e)
            {
            return;
            }

        

        

        private void SunTotal_MouseLeave(object sender, MouseEventArgs e)
            {
            this.RotateStoryBoard.Begin();
            }

        

       

        }
    }