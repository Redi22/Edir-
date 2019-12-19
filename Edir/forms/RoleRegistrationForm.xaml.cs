using Edir.Models;
using Edir.Model;
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

namespace Edir.forms
{
    /// <summary>
    /// Interaction logic for RoleRegistrationForm.xaml
    /// </summary>
    public partial class RoleRegistrationForm : UserControl
    {
        private EdirDbContext _context = null;
        Role role = new Role();
        public RoleRegistrationForm()
        {
            InitializeComponent();
            _context = new EdirDbContext();

        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            role.Name = RoleName.Text.Trim();
            role.Description = Description.Text.Trim();

            _context.Roles.Add(role);
            _context.SaveChanges();

        }
    }
}
