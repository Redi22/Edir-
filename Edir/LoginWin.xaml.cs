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
using System.Windows.Shapes;

namespace Edir
{
    /// <summary>
    /// Interaction logic for LoginWin.xaml
    /// </summary>
    public partial class LoginWin : Window
    {
        private EdirDbContext _context = null;
        bool Logged;
        About Edir;
        public LoginWin()
        {
            InitializeComponent();
            _context = new EdirDbContext();
            Edir = _context.Abouts.FirstOrDefault();
            EdirName.Text = Edir.EdirName.ToString();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            List<UserAccount> userAccounts = _context.UserAccounts.ToList();
            UserAccount user = new UserAccount();
            user.Username = Username.Text.Trim();
            user.Password = Password.Password;

            foreach(UserAccount u in userAccounts)
            {
                if(user.Username == u.Username && user.Password == u.Password)
                {
                    MainWindow main = new MainWindow();
                    main.Show();
                    main.CheckAdmin(u);
                    Logged = true;
                }
            }
            if (!Logged)
            {
                ErrorMessage er = new ErrorMessage();
                er.MessageText.Text = "Wrong Password";
                er.Show();
            }
            

        }
    }
}
