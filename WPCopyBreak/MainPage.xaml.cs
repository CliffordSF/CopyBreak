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
#pragma warning disable CS0169 // The field 'MainPage.cardWidth' is never used
        private double cardWidth;
#pragma warning restore CS0169 // The field 'MainPage.cardWidth' is never used
#pragma warning disable CS0169 // The field 'MainPage.draggingStartPoint' is never used
        private Point draggingStartPoint;
#pragma warning restore CS0169 // The field 'MainPage.draggingStartPoint' is never used
#pragma warning disable CS0169 // The field 'MainPage.stackOriginalPosition' is never used
        private Point stackOriginalPosition;
#pragma warning restore CS0169 // The field 'MainPage.stackOriginalPosition' is never used
#pragma warning disable CS0169 // The field 'MainPage.draggingStack' is never used
        private Canvas draggingStack;
#pragma warning restore CS0169 // The field 'MainPage.draggingStack' is never used
#pragma warning disable CS0169 // The field 'MainPage.destinationStackColumn' is never used
        private int? destinationStackColumn; //? makes field able to accept a value of null
#pragma warning restore CS0169 // The field 'MainPage.destinationStackColumn' is never used
#pragma warning disable CS0169 // The field 'MainPage.sourceStackColumn' is never used
        private int sourceStackColumn;
#pragma warning restore CS0169 // The field 'MainPage.sourceStackColumn' is never used
        private const double cardMargin = 5;
#pragma warning disable CS0169 // The field 'MainPage.cardStackDifference' is never used
        private double cardStackDifference;
#pragma warning restore CS0169 // The field 'MainPage.cardStackDifference' is never used
        public static string cardColor;
#pragma warning disable CS0169 // The field 'MainPage.word' is never used
        string word;
#pragma warning restore CS0169 // The field 'MainPage.word' is never used
#pragma warning disable CS0169 // The field 'MainPage.points' is never used
        int points;
#pragma warning restore CS0169 // The field 'MainPage.points' is never used
#pragma warning disable CS0169 // The field 'MainPage.copyBreakLetter' is never used
        string copyBreakLetter;
#pragma warning restore CS0169 // The field 'MainPage.copyBreakLetter' is never used
        const int NumberOfColumns = 7;
#pragma warning disable CS0169 // The field 'MainPage.CWordList' is never used
        private ChallengeWords CWordList;
#pragma warning restore CS0169 // The field 'MainPage.CWordList' is never used
        //public string CWord;
#pragma warning disable CS0169 // The field 'MainPage.cardImageBack' is never used
        private Image cardImageBack;
#pragma warning restore CS0169 // The field 'MainPage.cardImageBack' is never used
        public FinalScore finalScore;
        public static string InputName;
        public HighScore highScores;


#pragma warning disable CS0169 // The field 'MainPage.game' is never used
        private Game game;
#pragma warning restore CS0169 // The field 'MainPage.game' is never used
        public string DeckChoice; //Used to select a deck to use
        // Constructor
        public MainPage()
            {
#pragma warning disable CS0103 // The name 'InitializeComponent' does not exist in the current context
            InitializeComponent();
#pragma warning restore CS0103 // The name 'InitializeComponent' does not exist in the current context
            }

        private void startButton_Click(object sender, RoutedEventArgs e)
            {
            NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
            }
        }
    }