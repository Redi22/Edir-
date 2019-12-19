using Edir.Model;
using Edir.notification;
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

namespace Edir.forms
{
    /// <summary>
    /// Interaction logic for MemberRoleRegistrtionForm.xaml
    /// </summary>
    public partial class MemberRoleRegistrtionForm : UserControl
    {
        private EdirDbContext _context = null;
        UserAccount admins = new UserAccount();
        long AccountRole;
        UserAccount Account;
        List<Role> allroles;
        public MemberRoleRegistrtionForm()
        {
            InitializeComponent();
            _context = new EdirDbContext();
            allroles = _context.Roles.Where(r => r.Id > 3).ToList();
            roles.ItemsSource = allroles;
        }
        public void CheckAdmin(UserAccount Account)
        {
            this.Account = Account;
            this.AccountRole = Account.RoleId;
        }
        private void RoleId_Loaded(object sender, RoutedEventArgs e)
        {
            var gr = sender as ComboBox;
            gr.ItemsSource = _context.Roles.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(AccountRole == 2)
            {
            admins.RoleId = Convert.ToInt64(RoleId.SelectedIndex);
            admins.Username = Username.Text.Trim();
            admins.Password = PasswordBox.ToString();
            admins.AdminUpgradeDate = DateTime.Now.Date;
            _context.UserAccounts.Add(admins);
            _context.SaveChanges();
            SucessMessage Sm = new SucessMessage();
            Sm.MessageText.Text = "Admin Added Successfully";
            Sm.Show();

            }
            else
            {
                ErrorMessage Sm = new ErrorMessage();
                Sm.MessageText.Text = "Access Denied";
                Sm.Show();
            }

          
        }
    }
}
