using System;
using System.Security.Policy;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        public MainWindow() { InitializeComponent(); }

        public Game Game = new Game();
        public Player PlayerBlue = new Player();
        public Player? PlayerOrange, CurrentlyPlaying;

        private async void GameStart(object sender, RoutedEventArgs e) {
            //Zu Spielfeld wechseln
            Settings.Visibility = Visibility.Collapsed;
            Fields.Visibility = Visibility.Visible;
            Frame.Header = "Spielfeld";
            
            //Initialisierung: PlayerOrange als Bot oder Player & zufölliger CurrentlyPlaying
            PlayerOrange = Singleplayer.IsChecked == true ? new BotPlayer((int)DiffSlider.Value) : new Player();
            CurrentlyPlaying = Utils.Random.Next(1, 3) switch { 1 => PlayerOrange, _ => PlayerBlue };
            
            //Start Timer & Game
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += TimerTick;
            ResetTimer(800);
            timer.Start();
            
            await Game.GameLoop();
            
            //Reset Game
            //TODO
        }

        private void PlayerClickEvent(object sender, RoutedEventArgs e) {
            Game.LastPressedButton = sender as Button;
        }

        public bool OccupyField(Button field, Player player) {
            if (player != CurrentlyPlaying || field.Content != null) return false;
            if (player == PlayerBlue) {
                //Blaues Feld setzen
            } else {
                //Oranges Feld setzen
            }
            return true;
        }
        
        private void TimerTick(object sender, EventArgs e) {
            ProgressBar.Value--;
            Game.TimeRemaining = (int)ProgressBar.Value;
        }

        private void ResetTimer(int value) {
            Game.TimeRemaining = value;
            ProgressBar.Maximum = value;
            ProgressBar.Value = value;
        }
    }
}