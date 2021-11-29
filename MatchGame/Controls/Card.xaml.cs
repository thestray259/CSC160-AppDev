using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO; 
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatchGame.Controls
{
    /// <summary>
    /// Interaction logic for Card.xaml
    /// </summary>
    public partial class Card : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private eState state = eState.Inactive;

        private bool interactable;
        private string symbol;
        public enum eState
        {
            Inactive,
            Idle, 
            Flipped, 
            Matched
        }
        
        public GameWindow Owner { get; set; }
        public eState State 
        {
            get { return state; }
            set
            {
                if (value != state)
                {
                    state = value;
                    Interactable = (state == eState.Idle);
                    Show = (state == eState.Flipped || state == eState.Matched);
                    NotifyPropertyChanged("State");
                }
            }
        }

        public Card()
        {
            InitializeComponent();
            DataContext = this;
            this.Loaded += Card_Loaded;
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Card_Loaded(object sender, RoutedEventArgs e)
        {
            Owner = (GameWindow)Window.GetWindow(this);
            Owner.RegisterCard(this); 
        }

        public bool Interactable
        {
            get { return interactable; }
            set
            {
                if (value != interactable)
                {
                    interactable = value;
                    NotifyPropertyChanged("Interactable"); 
                }
            }
        }

        public string Symbol
        {
            get { return symbol; }
            set
            {
                if (value != symbol)
                {
                    symbol = value;
                    NotifyPropertyChanged("Symbol"); 
                }
            }
        }

        public bool Show
        {
            set
            {
                if (value)
                {
                    lblSymbol.Visibility = Visibility.Visible;
                    imgCard.Visibility = Visibility.Hidden; 
                }
                else
                {
                    lblSymbol.Visibility = Visibility.Hidden;
                    imgCard.Visibility = Visibility.Visible; 
                }
            }
        }

        private void btnCard_Click(object sender, RoutedEventArgs e)
        {
            State = eState.Flipped;
            Owner.SelectCard(this); 
        }
    }
}
