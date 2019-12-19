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
    /// Interaction logic for DeleteConfirmation.xaml
    /// </summary>
    public partial class DeleteConfirmation : Window
    {
        private EdirDbContext _context = null;
        public DeleteConfirmation()
        {
            InitializeComponent();
            _context = new EdirDbContext();
        }
        object Selected;
        public void assigner(object passed)
        {
            this.Selected = passed;
        }
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {

            _context.Entry(Selected).State = System.Data.Entity.EntityState.Deleted;
            _context.SaveChanges();
            SucessMessage sm = new SucessMessage();
            sm.MessageText.Text = "Deleted Successfully";
            this.Hide();
            sm.Show();

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
