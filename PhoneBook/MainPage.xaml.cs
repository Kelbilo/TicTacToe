using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PhoneBook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public bool playerOne = true; // Player one true = X, false is O
        public int turnCount = 0; // To check for draw
        string winnerPlayer; // Checking who the winner is


        public MainPage()
        {
            this.InitializeComponent();
            // Give all the buttons the same method
            TopRight.Click += ButtonClick;
            TopCenter.Click += ButtonClick;
            TopLeft.Click += ButtonClick;
            CenterRight.Click += ButtonClick;
            Center.Click += ButtonClick;
            CenterLeft.Click += ButtonClick;
            BotRight.Click += ButtonClick;
            BotCenter.Click += ButtonClick;
            BotLeft.Click += ButtonClick;

            // Making the draw text invisible
            Drawtxt.Opacity = 0;
            Canvas.SetZIndex(Drawtxt, -1);
        }
        
        void ButtonClick(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;

            if (playerOne)
            {
                b.Content = "X"; //playerOne =true
            }
            else
            {
                b.Content = "O"; //playerOne =false means its player two "O"
            }
            // Check if Button has been pressed
            if (b.Content != null)
            {
                b.IsEnabled = false;
            }
            else
            {
                b.IsEnabled = true;
            }
            playerOne = !playerOne;
            turnCount++;
            CheckWin();
        }

        private void CheckWin()
        {
            bool winner = false;

            //Check horizontal wins
            if ((TopRight.Content == TopCenter.Content) && (TopCenter.Content == TopLeft.Content) && (!TopRight.IsEnabled))
            {
                winner = true;
                winnerPlayer = TopRight.Content.ToString(); // To check who the winner is
            }
            else if ((CenterRight.Content == Center.Content) && (Center.Content == CenterLeft.Content) && (!CenterRight.IsEnabled))
            {
                winner = true;
                winnerPlayer = CenterRight.Content.ToString();
            }
            else if ((BotRight.Content == BotCenter.Content) && (BotCenter.Content == BotLeft.Content) && (!BotRight.IsEnabled))
            {
                winnerPlayer = BotRight.Content.ToString();
                winner = true;
            }

            //Check vertical wins
            if ((TopRight.Content == CenterRight.Content) && (CenterRight.Content == BotLeft.Content) && (!TopRight.IsEnabled))
            {
                winnerPlayer = TopRight.Content.ToString();
                winner = true;
            }
            else if ((TopCenter.Content == Center.Content) && (Center.Content == BotCenter.Content) && (!TopCenter.IsEnabled))
            {
                winnerPlayer = TopCenter.Content.ToString();
                winner = true;
            }
            else if ((TopLeft.Content == CenterLeft.Content) && (CenterLeft.Content == BotRight.Content) && (!TopLeft.IsEnabled))
            {
                winnerPlayer = TopLeft.Content.ToString();
                winner = true;
            }

            //Cheeck for diagonal wins
            if ((TopRight.Content == Center.Content) && (Center.Content == BotRight.Content) && (!TopRight.IsEnabled))
            {
                winner = true;
                winnerPlayer = TopRight.Content.ToString();
            }
            else if ((TopLeft.Content == Center.Content) && (Center.Content == BotLeft.Content) && (!TopLeft.IsEnabled))
            {
                winner = true;
                winnerPlayer = TopLeft.Content.ToString();
            }

            if (winner)
            {
                DisableButtons();
                if (winnerPlayer == "X")
                {
                    PlayerOneScore.Text = (int.Parse(PlayerOneScore.Text) + 1).ToString(); // Adding score to winner
                }
                else
                {
                    PlayerTwoScore.Text = (int.Parse(PlayerTwoScore.Text) + 1).ToString();
                }
            }
            else if (turnCount == 9)
            {
                // If turncount is 9 disable buttions and show draw text
                DisableButtons();
                Drawtxt.Opacity = 100;
                Canvas.SetZIndex(Drawtxt, 1);
            }
        }

        private void DisableButtons()
        {
            TopRight.IsEnabled = false;
            TopCenter.IsEnabled = false;
            TopLeft.IsEnabled = false;
            CenterRight.IsEnabled = false;
            Center.IsEnabled = false;
            CenterLeft.IsEnabled = false;
            BotRight.IsEnabled = false;
            BotCenter.IsEnabled = false;
            BotLeft.IsEnabled = false;
        }

        private void EnableButtons()
        {
            TopRight.IsEnabled = true;
            TopCenter.IsEnabled = true;
            TopLeft.IsEnabled = true;
            CenterRight.IsEnabled = true;
            Center.IsEnabled = true;
            CenterLeft.IsEnabled = true;
            BotRight.IsEnabled = true;
            BotCenter.IsEnabled = true;
            BotLeft.IsEnabled = true;
        }

        private void PlayAgainBtn_Click(object sender, RoutedEventArgs e)
        {
            TopRight.Content = "";
            TopCenter.Content = "";
            TopLeft.Content = "";
            CenterRight.Content = "";
            Center.Content = "";
            CenterLeft.Content = "";
            BotRight.Content = "";
            BotCenter.Content = "";
            BotLeft.Content = "";
            EnableButtons();
            Drawtxt.Opacity = 0;
            Canvas.SetZIndex(Drawtxt, -1);
            turnCount = 0;
        }

        private void ResetScoreBtn_Click(object sender, RoutedEventArgs e)
        {
            PlayerTwoScore.Text = "0";
            PlayerOneScore.Text = "0";
            Drawtxt.Opacity = 0;
            Canvas.SetZIndex(Drawtxt, -1);
        }
    }
}
