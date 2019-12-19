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
using Edir.Models;
using Edir.notification;

namespace Edir.forms
{
    /// <summary>
    /// Interaction logic for ChangeAccountSetting.xaml
    /// </summary>
    public partial class ChangeAccountSetting : UserControl
    {
        private EdirDbContext _context = null;
        Role role = new Role();
        UserAccount Account;
        long AccountRole;
        public ChangeAccountSetting()
        {
            InitializeComponent();
            _context = new EdirDbContext();
        }

        private void CreateRoleBtn_Click(object sender, RoutedEventArgs e)
        {
            role.Name = RoleName.Text.Trim();
            role.Description = Description.Text.ToString();
            role.EventPrivilage = role.PaymentPrivilage = role.SuperAdminPrivilage = role.StorePrivilage =
            role.MemberPrivilage = false;
            if (MemberPrivilage.IsChecked.GetValueOrDefault())
            {
                role.MemberPrivilage = true;
            }
            if (EventPrivilage.IsChecked.GetValueOrDefault())
            {
                role.EventPrivilage = true;
            }if (PaymentPrivilage.IsChecked.GetValueOrDefault())
            {
                role.PaymentPrivilage = true;
            }if (StorePrivilage.IsChecked.GetValueOrDefault())
            {
                role.StorePrivilage = true;
            }
            role.RoleCreationDate = DateTime.Now.Date;
            _context.Roles.Add(role);
            _context.SaveChanges();

        }
    }
}
