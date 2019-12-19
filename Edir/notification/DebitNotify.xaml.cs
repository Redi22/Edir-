using Edir.Models;
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

namespace Edir.notification
{
    /// <summary>
    /// Interaction logic for DebitNotify.xaml
    /// </summary>
    public partial class DebitNotify : Window
    {
        private EdirDbContext _context = null;

        public DebitNotify()
        {
            InitializeComponent();
            _context = new EdirDbContext();
        }

        private void DebitNot_Loaded(object sender, RoutedEventArgs e)
        {
            var gr = sender as DataGrid;
            gr.ItemsSource = _context.Members.ToList();

        }
    }
}
