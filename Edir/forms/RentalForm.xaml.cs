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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Edir.Model;

namespace Edir.forms
{
    /// <summary>
    /// Interaction logic for RentalForm.xaml
    /// </summary>
    public partial class RentalForm : UserControl
    {
        private EdirDbContext _context = null;
        public RentalForm()
        {
            InitializeComponent();
            _context = new EdirDbContext();
        
        }

        private void ItemsControl_Loaded(object sender, RoutedEventArgs e)
        {
            var gr = sender as ItemsControl;
            gr.ItemsSource = _context.Members.ToList();
        }
    }
}
