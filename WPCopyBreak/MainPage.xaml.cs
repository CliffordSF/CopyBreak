using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Brooks.ennuiWare.CopyBreak.Engine;


namespace Brooks.ennuiWare.CopyBreak.WPCopyBreak
    {
    public partial class MainPage : PhoneApplicationPage
        {
        private double cardWidth;
        private Point draggingStartPoint;
        private Point stackOriginalPosition;
        private Canvas draggingStack;
        private int? destinationStackColumn; //? makes field able to accept a value of null
        private int sourceStackColumn;
        private const double cardMargin = 5;
        private double cardStackDifference;
        public static string cardColor;
        string word;
        int points;
        string copyBreakLetter;
        const int NumberOfColumns = 7;
        private ChallengeWords CWordList;
        //public string CWord;
        private Image cardImageBack;
        public FinalScore finalScore;
        public static string InputName;
        public HighScore highScores;


        private Game game;
        public string DeckChoice; //Used to select a deck to use
        // Constructor
        public MainPage()
            {
            InitializeComponent();
            }

        private void startButton_Click(object sender, RoutedEventArgs e)
            {
            NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
            }
        }
    }