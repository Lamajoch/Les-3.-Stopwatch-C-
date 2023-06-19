using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
namespace Stopwatch
{
    public partial class MainWindow : Window
    {
        // Fields for the timer, round number, and number of events
        private DispatcherTimer _timer;
        private int _ronde;
        private int _numberOfEvents;

        public MainWindow()
        {
            InitializeComponent();

            // Initialize the timer and set it to fire a tick event every millisecond
            _timer = new DispatcherTimer();
            _timer.Tick += Timer_Tick;
            _timer.Interval = TimeSpan.FromMilliseconds(0.3);
        }

        // Event handler for the timer tick event
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Increment the number of events
            _numberOfEvents++;

            // Update the text blocks with the elapsed time
            txtNumberOfTickEvents.Text = _numberOfEvents.ToString();
            txtUren.Text = (_numberOfEvents / 3600000).ToString();
            txtMinuten.Text = ((_numberOfEvents / 60000) % 60).ToString();
            txtSeconden.Text = ((_numberOfEvents / 1000) % 60).ToString();
            txtMilliseconden.Text = (_numberOfEvents % 1000).ToString();
        }

        // Event handler for the Start button click event
        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            // Enable the Round, Stop, and Reset buttons and disable the Start button
            btnRonde.IsEnabled = true;
            btnStop.IsEnabled = true;
            btnReset.IsEnabled = true;
            btnStart.IsEnabled = true;

            // Reset the round number and start the timer
            _ronde = 0;
            _timer.Start();
        }

        // Event handler for the Round button click event
        private void BtnRonde_Click(object sender, RoutedEventArgs e)
        {
            // Increment the round number and add a new item to the list box
            _ronde++;
            lstTussentijden.Items.Add("Ronde " + _ronde + ": " + txtUren.Text + ":" + txtMinuten.Text + ":" + txtSeconden.Text + ":" + txtMilliseconden.Text);
        }

        // Event handler for the Stop button click event
        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            // Disable the Round, Stop, and Reset buttons and enable the Start button
            btnRonde.IsEnabled = false;
            btnStop.IsEnabled = false;
            btnReset.IsEnabled = true;
            btnStart.IsEnabled = true;

            // Stop the timer
            _timer.Stop();
        }

        // Event handler for the Reset button click event
        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            // Reset the number of events, round number, and clear the list box
            _numberOfEvents = 0;
            _ronde = 0;
            lstTussentijden.Items.Clear();

            // Reset the text blocks
            txtNumberOfTickEvents.Text = "0";
            txtUren.Text = "0";
            txtMinuten.Text = "0";
            txtSeconden.Text = "0";
            txtMilliseconden.Text = "0";

            // Enable the Start button and disable the Reset button
            btnStart.IsEnabled = true;
            btnReset.IsEnabled = false;
        }
    }
}
