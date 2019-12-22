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

namespace Edir.forms.Report
{
    /// <summary>
    /// Interaction logic for ReportMain.xaml
    /// </summary>
    public partial class ReportMain : UserControl
    {
        private EdirDbContext _context = null;
        List<EdirEvent> edirEvents = null;
        List<EdirEvent> allEdirEvents = null;
        List<Member> members    = null;
        List<Member> allMembers = null;
        List<Item>    items        = null;
        List<Item>   allItems     = null;
        List<Rule> rules    = null;
        List<Rule> allRules = null;
        List<Pay>   pays    = null;
        List<Pay>  allPays  = null;
        DateTime dt;
        public ReportMain()
        {
            InitializeComponent();
            _context = new EdirDbContext();
            dt = DateTime.Now.Date;
            edirEvents = new List<EdirEvent>();
            members = new List<Member>();
            allMembers = new List<Member>();
            items = new List<Item>();
            allItems = new List<Item>();
            rules = new List<Rule>();
            allRules = new List<Rule>();
            pays = new List<Pay>();
            allPays = new List<Pay>();
            String month= DateTime.Now.ToString("MMMM");
            head.Header = "report for the month " + month;
            container.Text = "This is a report about basic activities of this edir for this month.";
            event_viewer();
            mem_viewer();
            item_viewer();
            pay_viewer();
            rule_viewer();

        }

        private void event_viewer()
        {
            allEdirEvents = _context.EdirEvents.ToList();
            foreach (EdirEvent ev in allEdirEvents)
            {
                if((ev.date - dt).TotalDays <= 30)
                {
                    edirEvents.Add(ev);
                    grid_event.Children.Clear();
                }
            }

            foreach(EdirEvent e in edirEvents)
            {
                long attendees = _context.Attendances.Where(a => a.EventId == e.Id).Count();
                DescriptionCard dc = new DescriptionCard();
                dc.title.Content = e.Name;
                dc.descriptions.Text = "On " + e.date + " the event took place." + e.Description + ". The number of attendees was " + attendees + ". The event took place at " + e.Place + ". ";
                grid_event.Children.Add(dc);
            }
        }
        private void mem_viewer()
        {
            allMembers = _context.Members.ToList();
            foreach (Member ev in allMembers)
            {
                if((ev.RegisteredDate - dt).TotalDays <= 30)
                {
                    members.Add(ev);
                    grid_mem.Children.Clear();
                }
            }

            foreach(Member e in members)
            {
                DescriptionCard dc = new DescriptionCard();
                dc.title.Content = e.FirstName;
                dc.descriptions.Text = "On " + e.RegisteredDate + " the event took place." + ". The number of attendees was " +  ". The event took place at "  + ". ";
                grid_mem.Children.Add(dc);
            }
        }

        private void item_viewer()
        {
            DateTime dt = DateTime.Now.Date;
            allItems = _context.Items.ToList();
            foreach (Item ev in allItems)
            {
                if ((ev.PurchasedDate - dt).TotalDays <= 30)
                {
                    items.Add(ev);
                    grid_item.Children.Clear();
                }
            }

            foreach (Item e in items)
            {
                DescriptionCard dc = new DescriptionCard();
                dc.title.Content = e.Name;
                dc.descriptions.Text = "On " + e.PurchasedDate + " this item was purchased for a single price of "; 
                grid_item.Children.Add(dc);
            }
        }
        private void rule_viewer()
        {
            allRules = _context.Rules.ToList();
            foreach (Rule ev in allRules)
            {
                if ((ev.RuleRegistrationDate - dt).TotalDays <= 30)
                {
                    rules.Add(ev);
                    grid_rule.Children.Clear();
                }
            }
        
            foreach (Rule e in rules)
            {
                DescriptionCard dc = new DescriptionCard();
                dc.title.Content = e.Name;
                dc.descriptions.Text = "On " + e.RuleRegistrationDate + " the event took place." + ". The number of attendees was " + ". The event took place at " + ". ";
                grid_rule.Children.Add(dc);
            }
        }
        private void pay_viewer()
        {
            allPays = _context.Payments.ToList();
            foreach (Pay ev in allPays)
            {
                if ((ev.PaidDate - dt).TotalDays <= 30)
                {
                    pays.Add(ev);
                    grid_pay.Children.Clear();
                }
            }
        
            foreach (Pay e in pays)
            {
                DescriptionCard dc = new DescriptionCard();
                dc.title.Content = e.Type;
                dc.descriptions.Text = "On " + e.PaidDate + " the event took place." + ". The number of attendees was " + ". The event took place at " + ". ";
                grid_pay.Children.Add(dc);
            }
        }

    }
}
