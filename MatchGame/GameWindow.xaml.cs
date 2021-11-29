using MatchGame.Controls;
using System;
using System.ComponentModel; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window, INotifyPropertyhanged, ICommand
    {
        private Random random;
        private DispatcherTimer timer;
        private List<Card> cards = new List<Card>();
        private List<string> symbols = new List<string>()
        {
            "!", "!", "N", "N", ",", ",",
            "b", "b", "v", "v", "w", "w",
        };

        private Card card1 = null;
        private Card card2 = null;

        public event PropertyChangedEventHandler PropertyChanged;

        public GameWindow()
        {
            InitializeComponent();
            //timer.Interval = new TimeSpan(0, 0, 1);
            //timer.Tick += TimerTick;
            //timer.Start(); 
        }

        private void TimerTick(object sender, EventArgs e)
        {
            //timer.Stop(); 
            foreach (Card c in cards)
            {
                if (c.State != Card.eState.Matched)
                {
                    c.State = Card.eState.Idle; 
                }
            }

            card1 = null;
            card2 = null; 
        }

        public void RegisterCard(Card card)
        {
            card.State = Card.eState.Idle;
            //int cardSymbolIndex = random.Next(0, symbols.Count);
            //card.Symbol = symbols[cardSymbolIndex];
            //symbols.RemoveAt(cardSymbolIndex);
            cards.Add(card); 
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SelectCard(Card card)
        {
            if (card1 == null)
            {
                card1 = card; 
            }
            else
            {
                card2 = card; 
                if (card1.lblSymbol == card2.lblSymbol)
                {
                    card1.State = Card.eState.Matched; 
                    card2.State = Card.eState.Matched; 
                }
                else
                {
                    // disable all cards for 1 second 
                    //card.IsEnabled = false; 

                    foreach (Card c in cards)
                    {
                        if (c.State == Card.eState.Idle)
                        {
                            c.State = Card.eState.Inactive; 
                        }
                    }

                    // start timer, after a second the TimerTick is called and the cards reset
                    //timer.Start();
                    
                }
            }
        }

        public bool WinCheck()
        {
            // if all cards == matched, then win 

            return false; 
        }

        // Command stuff 
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

/*        public bool CanExecute(object parameter)
        {
            //return !GameOver; 
        }*/

        public void Execute(object parameter)
        {
            //ResetGame(); 
        }

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
