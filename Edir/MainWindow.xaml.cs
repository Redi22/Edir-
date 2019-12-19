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
using Edir.members;
using Edir.capital;
using Edir.notification;
using Edir.forms;
using Edir.Models;
using Edir.Model;
using Edir.Payment;
using Edir.Settings;
using Edir.forms.Report;
using System.Data;

namespace Edir
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private EdirDbContext _context = null;
        UserAccount Account;
        About Edir;
        Role role;
        public MainWindow()
        {
            InitializeComponent();
            Dash_view();
            //Create Db Context Instance
             _context = new EdirDbContext();
            _context.SaveChanges();
            Edir = _context.Abouts.FirstOrDefault();
        }
        public void CheckAdmin( UserAccount Account)
        {
            this.Account = Account;
            role = _context.Roles.FirstOrDefault(r => r.Id == Account.RoleId);
        }
        public void Dash_view()
        {
            clear_all();
            dashbord1.Children.Add(new capitalDash());
            dashbord2.Children.Add(new memberView());
            dashbord3.Children.Add(new ViolationCount());
            Upcoming.Children.Clear();
            Upcoming.Children.Add(new UpcomingEvent());

        }
        private void menuDrawerClose_Click(object sender, RoutedEventArgs e)
        {
            menuDrawerClose.Visibility = Visibility.Collapsed;
            menuDrawerOpen.Visibility = Visibility.Visible;
        }

        private void menuDrawerOpen_Click(object sender, RoutedEventArgs e)
        {
            menuDrawerClose.Visibility = Visibility.Visible;
            menuDrawerOpen.Visibility = Visibility.Collapsed;
        }
        
        private void notificationButton_Click(object sender, RoutedEventArgs e)
        {
            clear_all();
            named.Children.Add(new MainNotificationPage());
                

        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {

            clear_all();
            SettingsMain settings = new SettingsMain();
            named.Children.Add(settings);
            settings.CheckAdmin(Account);

        }

        private void Members_clicked(object sender, MouseButtonEventArgs e)
        {
           
            if(role.MemberPrivilage)
            {
                clear_all();
                memberRegistrationForm Form = new memberRegistrationForm();
                named.Children.Add(Form);
            }else
            {
                ErrorMessage er = new ErrorMessage();
                er.MessageText.Text = "Access Denied";
                er.Show();
            }
            

        }

        private void Event_clicked(object sender, MouseButtonEventArgs e)
        {
            if(role.EventPrivilage)
            {

            clear_all();
            named.Children.Add(new EventRegistrationForm());
            

            }
            else
            {
                ErrorMessage er = new ErrorMessage();
                er.MessageText.Text = "Access Denied";
                er.Show();
            }
        }

        public void clear_all()
        {
            dashbord1.Children.Clear();
            dashbord2.Children.Clear();
            dashbord3.Children.Clear();
            named.Children.Clear();
            Upcoming.Children.Clear();
        }

        private void Items_click(object sender, MouseButtonEventArgs e)
        {
            if(role.StorePrivilage)
            {
            clear_all();
            named.Children.Add(new itemRegistrationForm());
            }
            else 
            {
                ErrorMessage er = new ErrorMessage();
                er.MessageText.Text = "Access Denied";
                er.Show();
            }
        }

        private void Rules_clicked(object sender, MouseButtonEventArgs e)
        {
            if(role.RulePrivilage)
            {

            clear_all();
            named.Children.Add(new RuleRegistrationForm());
        }
            else
            {
                ErrorMessage er = new ErrorMessage();
                er.MessageText.Text = "Access Denied";
                er.Show();
            }
        }

        private void Home_clicked(object sender, MouseButtonEventArgs e)
        {

            clear_all();
            //reset_color();
            Dash_view();
        }

        private void Payment_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (role.PaymentPrivilage)
            {
                PaymentForm pm = new PaymentForm();
                TimeSpan timeSpan = Edir.PayDate.Date - DateTime.Now.Date;

                if (timeSpan.TotalDays % 30 == 0)
                {
                    if (true)
                    {
                        clear_all();
                        named.Children.Add(pm);

                    }
                }
                else
                {
                    PayDateNotify pd = new PayDateNotify();
                    long daysLeft = Edir.PayDate.Day - DateTime.Now.Day;

                    if (daysLeft < 0)
                    {
                        daysLeft += 30;
                    }
                    pd.DaysLeft.Text = daysLeft.ToString();

                    clear_all();
                    pm.PaymentMainGrid.Children.Clear();
                    pm.PaymentMainGrid.Children.Add(pd);
                    named.Children.Add(pm);


                }

            }
        else
            {
                ErrorMessage er = new ErrorMessage();
                er.MessageText.Text = "Access Denied";
                er.Show();
            }
}

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            if(role.SuperAdminPrivilage)
            {
                ReportMain report = new ReportMain();
                clear_all();
                named.Children.Add(report);
            
            }
        else
            {
                ErrorMessage er = new ErrorMessage();
                er.MessageText.Text = "Access Denied";
                er.Show();
            }
}
    }
}
