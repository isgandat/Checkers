using CheckersMinimax.Clone;
using CheckersMinimax.Pieces;
using CheckersMinimax.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace CheckersMinimax
{
    
    /// Interaction logic for CheckersSquareUserControl.xaml
    /// </summary>
    public partial class CheckersSquareUserControl : UserControl, INotifyPropertyChanged, IMinimaxClonable
    {
        private static readonly Settings Settings = Settings.Default;

        
        /// Gets or sets the checkers point.

        /// <value>
        /// The checkers point.
        /// </value>
        public CheckersPoint CheckersPoint { get; set; }

        
        /// Gets or sets the color of the background.

        /// <value>
        /// The color of the background.
        /// </value>
        public Brush BackgroundColor
        {
            get
            {
                return background;
            }

            set
            {
                background = value;
                OnPropertyChanged("BackgroundColor");
            }
        }

        private Brush background;

        
        /// Initializes a new instance of the <see cref="CheckersSquareUserControl"/> class.

        public CheckersSquareUserControl()
        {
        }

        
        /// Initializes a new instance of the <see cref="CheckersSquareUserControl"/> class.

        /// <param name="backgroundColor">Color of the background.</param>
        /// <param name="checkersPoint">The checkers point.</param>
        /// <param name="routedEventHandler">The routed event handler.</param>
        public CheckersSquareUserControl(Brush backgroundColor, CheckersPoint checkersPoint, RoutedEventHandler routedEventHandler)
        {
            InitializeComponent();
            this.Background = backgroundColor;
            this.CheckersPoint = checkersPoint;
            this.button.Click += routedEventHandler;

            UpdateSquare();

            //Debug TODO: Delete this when not needed anymore
            //button.Content = "row: " + checkersPoint.Row + " , col: " + checkersPoint.Column;
        }

        
        /// Updates the square.

        public void UpdateSquare()
        {
            if (CheckersPoint != null && CheckersPoint.Checker != null)
            {
                try
                {
                    if (checkerImage != null)
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            checkerImage.Source = CheckersPoint.Checker.BuildCheckerImageSource();
                        });
                    }
                }
                catch (Exception ex)
                {
                    //Show error message to user
                    MessageBox.Show(string.Format("Error Updating Square Row: Message = {0}", ex.Message));
                }
            }
            else
            {
                HideChecker();
            }
        }

        
        /// Determines whether this instance has checker.

        /// returns= 
        ///   <c>true</c> if this instance has checker; otherwise, <c>false</c>.
        /// 
        public bool HasChecker()
        {
            return CheckersPoint.Checker != null && !(CheckersPoint.Checker is NullCheckerPiece);
        }

        
        /// Gets the minimax clone.

        /// returns= 
        /// A clone to be used in the minimax algoritm
        /// 
        public object GetMinimaxClone()
        {
            CheckersSquareUserControl clone = new CheckersSquareUserControl();
            clone.CheckersPoint = (CheckersPoint)this.CheckersPoint.GetMinimaxClone();

            return clone;
        }

        #region INotifiedProperty Block        
        
        /// Occurs when a property value changes.

        public event PropertyChangedEventHandler PropertyChanged;

        
        /// Called when [property changed]. Used in data binding

        /// <param name="propertyName">Name of the property.</param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        
        /// Hides the checker.

        private void HideChecker()
        {
            checkerImage.Visibility = Visibility.Collapsed;
        }
    }
}
