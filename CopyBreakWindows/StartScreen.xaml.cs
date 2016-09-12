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
using System.Threading;
using Brooks.ennuiWare.CopyBreak.Engine;

namespace Brooks.ennuiWare.CopyBreak.Windows
{
    /// <summary>
    /// Interaction logic for StartScreen.xaml
    /// </summary>
    public partial class StartScreen : Window
    {
        public String SelectedColor { get; set; }
        public HighScore highScores;
        public FinalScore finalscore;

        public StartScreen()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            InitializeComponent();
            highScores = new HighScore(finalscore);
            DisplayTopTen();
            PlayerNameTextBox.Focus();

            

            
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new MainWindow(); //Create an instance of MainWindow
            //newWindow.Owner = this;
            MainWindow.InputName = PlayerNameTextBox.Text;
            MainWindow.cardColor = SelectedColor;

            this.Close();
            newWindow.ShowDialog();
           
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

        public void DisplayTopTen()
        { 
            //top10StackPanel.Children.Clear();
            for (int i = 0; i < highScores.highScoreList.Count; i++)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = "Hello World!"; //"highScores.highScoreList[i].Gplayer  highScores.highScoreList[i].gameDate  highScores.highScoreList[i].GameScore";
                top10StackPanel.Children.Add(textBlock);
            }
        }
     } 
}
