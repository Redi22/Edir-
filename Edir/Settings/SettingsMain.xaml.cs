using Edir.forms;
using Edir.Model;
using Edir.Models;
using Edir.notification;
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

namespace Edir.Settings
{
    /// <summary>
    /// Interaction logic for SettingsMain.xaml
    /// </summary>
    /// 
    public partial class SettingsMain : UserControl

    {
        long AccountRole;
        UserAccount Account;
        private EdirDbContext _context = null;
        public SettingsMain()
        {
            InitializeComponent();
            _context = new EdirDbContext();
        }
        public void CheckAdmin (UserAccount Account)
        {
            this.AccountRole = Account.RoleId;
            this.Account = Account;
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Account.Password == PasswordBox.Password)
            {
                if (NewPass.Password == Confirm.Password)
                {
                    Account.Password = NewPass.Password;
                    _context.Entry(Account).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();
                    SucessMessage sm = new SucessMessage();
                    sm.MessageText.Text = "Password Changed";
                    sm.Show();
                }
            }

        }
        private void ListView_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SettingGrid.Children.Clear();
            ChangeAccountSetting accountSetting = new ChangeAccountSetting();
            SettingGrid.Children.Add(accountSetting);
        }

        private void ListView_PreviewMouseDown_1(object sender, MouseButtonEventArgs e)
        {
            SettingGrid.Children.Clear();
            MemberRoleRegistrtionForm Form = new MemberRoleRegistrtionForm();
            Form.CheckAdmin(Account);
            SettingGrid.Children.Add(Form);
        }

    }
}
