using Edir.forms.Report;
using Edir.forms.SignUpForms;
using Edir.Model;
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

namespace Edir
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        private EdirDbContext _context = null;
        Essentials essentials;
        List<String> info;
        NextPage nextPage;
        List<long> payments;
        ThirdPage thirdPage;
        UserAccount admin;
        string EdirName; string Description;
        double PayMem;
        double PaySib;
        double PayChild;
        double PayParent;
        double EventFin;

        int index;

        public SignUpWindow()
        {
            InitializeComponent();
            index = 0;
            _context = new EdirDbContext();
            essentials = new Essentials();
            nextPage = new NextPage();
            thirdPage = new ThirdPage();
            payments = new List<long>();
            info = new List<string>();
            admin = _context.UserAccounts.FirstOrDefault(u => u.Id == 5);

            
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Children.Clear();
            MainContent.Children.Add(essentials);
            Logo.Height = 40;
            Logo.VerticalAlignment = VerticalAlignment.Top;
            ContinueBtn.Visibility = Visibility.Hidden;
            NextBtn.Visibility = Visibility.Visible;
            PreviousBtn.Visibility = Visibility.Visible;
        }

        private void PreviousBtn_Click(object sender, RoutedEventArgs e)
        {
            if (index == 1)
            {
                MainContent.Children.Clear();
                MainContent.Children.Add(essentials);
                index = 0;
            }
            else if (index == 2)
            {
                MainContent.Children.Clear();
                MainContent.Children.Add(nextPage);
                index = 1;
                NextBtn.Visibility = Visibility.Visible;
            }

            

        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            if(index == 0)
            {
                info = essentials.save();
            this.EdirName = info[0];
            this.Description = info[1];
            MainContent.Children.Clear();
            MainContent.Children.Add(nextPage);
                index = 1;
            } else if(index == 1)
            {
                try
                {
                    payments = nextPage.Save();
                    this.PayMem = payments[0];
                    this.PaySib = payments[1];
                    this.PayChild = payments[2];
                    this.PayParent = payments[3];
                    this.EventFin = payments[4]; 
                }
                catch(Exception)
                {
                    this.PayMem =
                    this.PaySib =
                    this.PayChild =
                    this.PayParent =
                    this.EventFin = 0; 
                }
                MainContent.Children.Clear();
                MainContent.Children.Add(thirdPage);
                thirdPage.Initialize(EdirName, Description, PayMem, PaySib, PayChild, PayParent, EventFin );
                index = 2;
                NextBtn.Visibility = Visibility.Hidden;
                



            }


        }
    }
}
