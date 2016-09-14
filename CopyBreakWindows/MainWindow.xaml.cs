using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Brooks.ennuiWare.CopyBreak.Engine;

namespace Brooks.ennuiWare.CopyBreak.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
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

        public MainWindow()
        {
            //Thread.Sleep(TimeSpan.FromSeconds(2));
            InitializeComponent();
            CWordList = new ChallengeWords();
            highScores = new HighScore(finalScore);
            //HighScore highScores = new HighScore(FinalScore);

            //Begin section added for transparent window...calls ExtendGlassFrame function from GlassHelper class
        }

        //protected override void OnSourceInitialized(EventArgs e)
        //{
        //    base.OnSourceInitialized(e);
        //    // This can't be done any earlier than the SourceInitialized event:
        //    GlassHelper.ExtendGlassFrame(this, new Thickness(-1));
        //}

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            //add highscore code
            highScores.SaveHighScoreList(highScores);
            this.Close();
        }

        private void newGameButton_Click(object sender, RoutedEventArgs e)
        { 
            if(game != null)
            {
                //if (game.gameInProgress = false)
                //{
                //    //game.End();
                //    //This code is duplicated in the end button click...make into a function that can 
                //    //be called in both places
                //    FinalScore = new FinalScore(game.Player, game.CurrentScore);
                //    highScores.AddToHighScoreList(FinalScore);
                //    scoreLabel.Content = game.CurrentScore;
                //    MessageBox.Show("Your final score is: " + game.CurrentScore, "GAME OVER");
                //    DisplayHighscore();
                //}
                if (game.gameInProgress == true)
                {
                    if (MessageBox.Show("Do you want to END the current game and start a new one?", "New Game", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        game.End();
                        ////This code is duplicated in the end button click...make into a function that can 
                        ////be called in both places
                        finalScore = new FinalScore(game.Player, game.CurrentScore);
                        highScores.AddToHighScoreList(finalScore);
                        scoreLabel.Content = game.CurrentScore;
                        MessageBox.Show("Your final score is: " + game.CurrentScore, "GAME OVER");
                        DisplayHighscore();
                    }
                    else
                    {
                        return;
                    }
                }
                else if (game.gameInProgress == false)
                {
                   // return;
                }
            }
                
            if(InputName == null)
            {
                var newWindow = new newPlayer();
                newWindow.Owner = this;
                newWindow.ShowDialog();
                InputName = newWindow.userNameTextBox.Text.ToString();
            }

            PlaySound(@"C:\Users\Clifford\Documents\Visual Studio 2010\Projects\CopyBreak\CopyBreakWindows\Sounds\shuffle_cards.wav");
            game = new Game(cardColor, InputName, CWordList.GetNextChallengeWord());
            game.Start();
            DrawHand(game.Hand);
            scoreLabel.Content = null;
            scoreLabel.Content = 000;
            //CWord = CWordList.GetNextChallengeWord(); -- moved to ChallengeWordList on 10/27/10
            ChallengeWord.Content = "Challenge Word: " + game.ChallengeWord;
            wordPanel.Children.Clear();
            game.gameInProgress = true;

        }

        //Create the image
        //double columnSize = 2.0;
        Image letterImage = new Image();

        //letterImage.Source = LoadImage("/images/CopyBreak RED " + letter.ToString() + ".bmp");
        //Column0.Children.Add(letterImage);


        private void DrawHand(Hand hand)
        {
            for (int columnNumber = 0; columnNumber < NumberOfColumns; columnNumber++)//columnNumber iterator
            {
                Stack column = hand.Columns[columnNumber];//create stack (column) to move a stack from hand to

                Canvas canvasColumn = (Canvas)mainCanvas.Children[columnNumber]; //Create a canvas (canvasColumn) and move a mainCanvas canvas to
                canvasColumn.Children.Clear();//Clear the new canvasColumn's child canvas?????
                canvasColumn.SetValue(Canvas.TopProperty, 0.0);//Set the top margin on the canvas to 0.0
                canvasColumn.SetValue(Canvas.LeftProperty, (cardWidth + cardMargin * 2) * columnNumber + cardMargin);
                canvasColumn.Width = cardWidth + cardMargin;

                for (int i = 0; i < column.Count; i++)//Iterates through cards in the stack
                {
                    Card card = column[i];
                    string letter = card.Letter.ToString();//Find the letter for each card and puts it in a string called letter
                    // Create the image element called cardImage
                    Image cardImage = new Image();//

                    // set the width of the card
                    cardImage.Width = cardWidth;

                    //letterImage.Margin = new Thickness(5);

                    // Create source...new BitmapImage
                    BitmapImage bi = new BitmapImage();
                    // BitmapImage.UriSource must be in a BeginInit/EndInit block.
                    bi.BeginInit();
                    switch (cardColor)//Set the UriSource of the BitImage (bi) based on the color chosen for the deck
                    {
                        case "Red":
                            bi.UriSource = new Uri(@"/images/CopyBreak RED " + letter + ".gif", UriKind.RelativeOrAbsolute);
                            break;
                        case "Blue":
                            bi.UriSource = new Uri(@"/images/CopyBreak BLUE " + letter + ".gif", UriKind.RelativeOrAbsolute);
                            break;
                        case "Cartoon":
                            bi.UriSource = new Uri(@"/images/CopyBreak BLUE " + letter + " Cartoon.gif", UriKind.RelativeOrAbsolute);
                            break;

                        default:
                            bi.UriSource = new Uri(@"/images/CopyBreak RED " + letter + ".gif", UriKind.RelativeOrAbsolute);
                            break;
                    }


                    bi.EndInit();
                    // Set the Bitmap Image to the cardImage source
                    cardImage.Source = bi;
                    //Load into canvas
                    //int cardPosition = i;
                    cardImage.SetValue(Canvas.TopProperty, i * cardStackDifference);//Set the top postion of the cardImage
                    canvasColumn.Children.Add(cardImage);//Add the cardImage to the canvasColumn

                    //Create card back image and set
                    cardImageBack = new Image();
                    cardImageBack.Width = cardWidth * .75; // Size image smaller than cards in hand
                    //cardImageBack.Height = finalRow.Height;
                    //cardImageBack.Width = (cardImageBack.Height * .75);
                    BitmapImage cb = new BitmapImage();
                    cb.BeginInit();
                    switch (cardColor)
                    {
                        case "Red":
                            cb.UriSource = new Uri(@"/images/CopyBreak RED Back.gif", UriKind.RelativeOrAbsolute);
                            break;
                        case "Blue":
                            cb.UriSource = new Uri(@"/images/CopyBreak BLUE Back.gif", UriKind.RelativeOrAbsolute);
                            break;
                        case "Cartoon":
                            cb.UriSource = new Uri(@"/images/CopyBreak BLUE Back.gif", UriKind.RelativeOrAbsolute);
                            break;
                        default:
                            cb.UriSource = new Uri(@"/images/CopyBreak RED Back.gif", UriKind.RelativeOrAbsolute);
                            break;

                    }
                    cb.EndInit();
                    cardImageBack.Source = cb;
                    cardImageBack.SetValue(Canvas.TopProperty, 1.0);
                    cardImageBack.SetValue(Canvas.LeftProperty, 5.0);
                    bankCardCanvas.Children.Add(cardImageBack);
                }
            }
        }

        private void mainCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //const double ThirdColumnWidth = 100.0;
            const double NumberOfColumns = 7.0;
            cardWidth = (mainCanvas.ActualWidth) / NumberOfColumns - cardMargin * 2.0;

            double cardHeight = cardWidth / 239.0 * 355; // TODO: make these constant
            cardStackDifference = 0.25 * cardHeight;

            if (game != null)
            {
                bankCardCanvas.Children.Clear();
                DrawHand(game.Hand);
            }


            //mainCanvas.SetValue(Canvas.HeightProperty, 
        }

        private void Stack_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Cursor = Cursors.Arrow;
            System.Diagnostics.Debug.WriteLine("StackMouseUp with DestinationColumn = {0}", destinationStackColumn);

            string cardIdentity = game.Hand.Columns[sourceStackColumn].Word; // set cardIdentity to stack string

            if (cardIdentity == "CopyBreak")//Check to see if sourceStack is Copybreak card
            {
                var newWindow = new copyBreakLetterSelector(); //Create a new window instance of copyBreakLetterSelector
                newWindow.Owner = this;
                newWindow.ShowDialog();
                if (newWindow.SelectedLetter.HasValue)
                {
                    Stack.CopyBreakLetter = newWindow.SelectedLetter;
                }
                else
                {
                    return;
                }

                if (game != null)
                {
                    DrawHand(game.Hand);
                }
            }

            bool wasChallengedWord;
            if (destinationStackColumn > 6 && game.Turn(sourceStackColumn + 1, out wasChallengedWord))
            {
                if (wasChallengedWord)
                {
                    MessageBox.Show("You got the Challenge Word! 100 bonus points will be added to your score!", "CONGRATULATIONS!");
                }
                string newWord;
                scoreLabel.Content = game.CurrentScore;
                DisplayBankedWords(game.BankedWords);
            }
            if (destinationStackColumn.HasValue)
            {
                if (!game.Move(sourceStackColumn, destinationStackColumn.Value))
                {
                    //MessageBox.Show("Combination is not in dictionary or you are trying to work on more than one word per turn.", "Invalid move", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            
            draggingStack = null;
            DrawHand(game.Hand);
        }

        private void DisplayBankedWords(List<string> listOfBankedWords)
        {
            wordPanel.Children.Clear();
            foreach (String word in listOfBankedWords)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = word;
                wordPanel.Children.Add(textBlock);
            }
        }

        private void Stack_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            draggingStack = (Canvas)sender; //select canvas
            sourceStackColumn = mainCanvas.Children.IndexOf(draggingStack); //find stack number and set to sourceStackColumn int

            //Card card = game.Hand[sourceStackColumn]; WHAT WERE WE DOING HERE?
            destinationStackColumn = null;

            int zIndexOfMainCanvas = (int)mainCanvas.GetValue(Canvas.ZIndexProperty);
            for (int i = 0; i < mainCanvas.Children.Count - 1; i++) // removed -3 from mainCanvas.Children.Count value
            {
                Canvas stack = (Canvas)mainCanvas.Children[i];
                stack.SetValue(Canvas.ZIndexProperty, zIndexOfMainCanvas + 1);
            }

            draggingStack.SetValue(Canvas.ZIndexProperty, zIndexOfMainCanvas + 8);

            // Store original mouse position
            draggingStartPoint = e.GetPosition(null);

            stackOriginalPosition = new Point((double)draggingStack.GetValue(Canvas.LeftProperty),
                                                     (double)draggingStack.GetValue(Canvas.TopProperty));

            Cursor = Cursors.Hand;    
        }

        private void Stack_MouseMove(object sender, MouseEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("Sender is " + ((Canvas) sender).Name);
            // Get the current mouse position
            Point mousePos = e.GetPosition(null);
            Vector diff = mousePos - draggingStartPoint;

            if ((e.LeftButton == MouseButtonState.Pressed) && (draggingStack != null))
            {
                Point newStackPosition = stackOriginalPosition + diff;
                draggingStack.SetValue(Canvas.LeftProperty, newStackPosition.X);
                draggingStack.SetValue(Canvas.TopProperty, newStackPosition.Y);

                destinationStackColumn = (int)Math.Round(newStackPosition.X / (cardWidth + cardMargin * 2));

                System.Diagnostics.Debug.WriteLine("Move with vector diff of {0} and new destination of {1}", diff, destinationStackColumn);

                // if draggingStack.bottom > bankingDeck.Top and draggingStack.Left > bankingDeck.Left; 

            }

        }

        private void TurnButton_Click(object sender, RoutedEventArgs e)
        {
            if (game != null)
            {
                game.Turn();
                DrawHand(game.Hand);
            }
            else
                return;
        }

        private void optionsButton_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new selectADeckWindow();
            newWindow.Owner = this;
            newWindow.ShowDialog();
            cardColor = newWindow.SelectedColor;

            if (game != null)
            {
                DrawHand(game.Hand);
            }
        }

        private void mainCanvas_MouseLeave(object sender, MouseEventArgs e)
        {
            if (game == null)
            {
                return;
            }

            System.Diagnostics.Debug.WriteLine("mainCanvas_MouseLeave, so just redrawing hand");
            draggingStack = null;
            DrawHand(game.Hand);
        }

        private void bankCardCanvas_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            return;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //highScores = GameStateManagement.LoadHighscore();

            //highScores = new HighScore(finalScore);
            DisplayHighscore();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            CWordList.Save();
            GameStateManagement.SaveHighscore(highScores);
        }

        private void endButton_Click(object sender, RoutedEventArgs e)
        {
            if((game.CurrentScore == 0) || (game.gameInProgress == false))
            {
                return;
            }
           
            game.End(); 
            

            finalScore = new FinalScore(game.Player, game.CurrentScore);
            highScores.AddToHighScoreList(finalScore);
            scoreLabel.Content = game.CurrentScore;
            //HighScore HighScoreGameEnd = new HighScore(FinalScore);
            MessageBox.Show("Your final score is: " + game.CurrentScore, "GAME OVER");
            DisplayHighscore();
            highScores.SaveHighScoreList(highScores);
        }


       private void DisplayHighscore()
        {
            int score = highScores.ReturnHighScore(finalScore);

            if (score == null)
            {
                HighScoreTextBox.Content = "High Score: N/A";
            }
            else
            {
                HighScoreTextBox.Content = "High Score: " + score;
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog svdlg = new Microsoft.Win32.SaveFileDialog();
            svdlg.DefaultExt = ".xml";
            svdlg.Filter = "XML file (.xml)|*.xml";
            bool? svdlgResult = svdlg.ShowDialog(this);

            if(svdlgResult.HasValue && svdlgResult.Value)
            {
                string filename = svdlg.FileName;
                GameStateManagement.SaveGame(game, filename);
            }
            
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML file (.xml)|*.xml";
            bool? dlgResult = dlg.ShowDialog(this);
            if(dlgResult.HasValue && dlgResult.Value)
            {
                game = GameStateManagement.LoadGame(dlg.FileName);
                DrawHand(game.Hand);
                scoreLabel.Content = game.CurrentScore;
                DisplayBankedWords(game.BankedWords);
                ChallengeWord.Content = "Challenge Word: " + game.ChallengeWord;
            }         
        }

        private void aboutButton_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new AboutCopyBreak();
            newWindow.ShowDialog();
        }

        //SOUNDS

        static void PlaySound(string strWavName)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(strWavName);
            player.Play();
        }


    
    }
}

    


