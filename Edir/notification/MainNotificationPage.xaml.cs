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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Edir.notification
{
    /// <summary>
    /// Interaction logic for MainNotificationPage.xaml
    /// </summary>
    public partial class MainNotificationPage : UserControl
    {
        EdirDbContext _context = null;
        List<Member> debitedMembers = null;
        List<Member> members = null;
        List<Rental> allRents = null;
        List<Rental> rents = null;
        List<Member> violators = null;
        long memberId;

        public MainNotificationPage()
        {
            InitializeComponent();
            _context = new EdirDbContext();
            violators = new List<Member>();
            members = _context.Members.ToList();

            debitedMembers = _context.Members.Where(m => m.Debit >= 400).ToList();

            foreach(Member member in members)
            {
                if (_context.Violations.Where(v => v.MemberId == member.Id).Count() >= 3)
                {
                    violators.Add(member);
                }

            }

            allRents = _context.Rentals.ToList();
            rents = new List<Rental>();
            foreach(Rental rent in allRents)
            {
                TimeSpan timeSpan = rent.RentedDate - DateTime.Now.Date;
                double daysRented = timeSpan.TotalDays;
                if (daysRented > 7)
                {
                    rents.Add(rent);
                }

            }

            DebitMemberView.ItemsSource = debitedMembers;
            RuleViolView.ItemsSource = violators;
            itemsView.ItemsSource = rents;

        }
    }
}
