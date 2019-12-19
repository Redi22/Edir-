using System;
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

namespace Edir.notification
{
    /// <summary>
    /// Interaction logic for Condolence.xaml
    /// </summary>
    public partial class Condolence : Window
    {
        public DispatcherTimer dispatcherTimer;
        public Condolence()
        {
            InitializeComponent();
            SetTimeout();
        }


     


        private void SetTimeout()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1.5);
            dispatcherTimer.Start();
        }

        public void SetContent(string message)
        {
            MessageText.Text = message;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            dispatcherTimer.Stop();
            this.Hide();

        }
    }
}
