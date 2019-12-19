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
using System.Collections.ObjectModel;
using Edir.notification;

namespace Edir.forms
{
    /// <summary>
    /// Interaction logic for RuleRegistrationForm.xaml
    /// </summary>
    public partial class RuleRegistrationForm : UserControl
    {
        private EdirDbContext _context = null;
        Rule rule = new Rule();
        Violation violation;
        About Edir;
        public List<Rule> RulesList { get; set; }
        List<Rule> allRules;
        public RuleRegistrationForm()
        {
            InitializeComponent();

            _context = new EdirDbContext();
            allRules = _context.Rules.ToList();
            RulesGrid.ItemsSource = allRules;
            violation = new Violation();
            Edir = _context.Abouts.FirstOrDefault();

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            rule.Name = RuleName.Text.Trim();
            rule.Description = Description.Text.ToString();
            rule.FirstFin = Convert.ToDouble(FirstFin.Text);
            rule.SecondFin = Convert.ToDouble(SecondFin.Text);
            rule.LastFin = Convert.ToDouble(FinalFin.Text);
            rule.RuleRegistrationDate = DateTime.Now.Date;

            _context.Rules.Add(rule);
            _context.SaveChanges();
            SucessMessage sm = new SucessMessage();
            sm.MessageText.Text = "Registered Successfully";
            sm.Show();

        }

        private void RulesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Rule Selected = ((Rule)RulesGrid.SelectedItem);

            if (Selected != null)
            {
                RuleName.Text = Selected.Name.ToString();
                Description.Text = Selected.Description.ToString();
                FirstFin.Text = Selected.FirstFin.ToString();
                SecondFin.Text = Selected.SecondFin.ToString();
                FinalFin.Text = Selected.LastFin.ToString();
              
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Rule Selected = ((Rule)RulesGrid.SelectedItem);

            if (Selected != null)
            {
                Selected.Name = RuleName.Text.Trim();
                Selected.Description = Description.Text.ToString();
                Selected.FirstFin = Convert.ToDouble(FirstFin.Text);
                Selected.SecondFin = Convert.ToDouble(SecondFin.Text);
                Selected.LastFin = Convert.ToDouble(FinalFin.Text);

                _context.Entry(Selected).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                SucessMessage sm = new SucessMessage();
                sm.MessageText.Text = "Updated Successfully";
                sm.Show();

            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Rule Selected = ((Rule)RulesGrid.SelectedItem);

            if (Selected != null)
            {
                DeleteConfirmation Confirmation = new DeleteConfirmation();
                Confirmation.assigner(Selected);
                Confirmation.Show();

            }

        }

 
        private void ViolatedRuleId_Loaded(object sender, RoutedEventArgs e)
        {
            var Rules = _context.Rules.ToList();
            ViolatedRuleId.ItemsSource = Rules;
        }

        private void ReportBtn_Click(object sender, RoutedEventArgs e)
        {
            long SelMemId = Convert.ToInt64(MemId.Text);
            long SelRuleId = 0;
            double First = Edir.DefaultFirstFin ;
            double Second = Edir.DefaultSecondFin;
            double Debit = 0;
            double Last = Edir.DefaultFinalFin;
            if (!Fundamental.IsChecked.GetValueOrDefault())
            {
               var SelectedRule = ViolatedRuleId.SelectedItem;
                Rule SelRule = ((Rule)SelectedRule);
                SelRuleId = SelRule.Id;
                rule = _context.Rules.FirstOrDefault(r => r.Id == SelRuleId);
                First = Convert.ToDouble(rule.FirstFin);
                Second = Convert.ToDouble(rule.SecondFin);
                Last = Convert.ToDouble(rule.LastFin);

            }
            int PreRec = _context.Violations.Where(v => v.MemberId == SelMemId).Count();
            if(PreRec < 2)
            {
                Debit = First;
                
            }
            else if (PreRec < 3)
            {
                Debit = Second;

            }
            else if (PreRec > 3)
            {
                Debit = Last;

            }
            Member Mem = ((Member)_context.Members.FirstOrDefault(m => m.Id == SelMemId));
            Mem.Debit += Debit;
            violation.Description = Description.Text.ToLower();
            violation.MemberId = SelMemId;
            violation.RuleId = SelRuleId;
            violation.ReportDate = DateTime.Now.Date;
            _context.Entry(Mem).State = System.Data.Entity.EntityState.Modified;
            _context.Violations.Add(violation);
            _context.SaveChanges();
            SucessMessage sm = new SucessMessage();
            sm.MessageText.Text = "Reported Successfully";
            sm.Show();

        }

        

        private void Search_KeyUp(object sender, KeyEventArgs e)
        {
            List<Rule> Searched = new List<Rule>();
            foreach(Rule Rule in allRules)
            {
                if (Rule.Name.ToLower().Contains(Search.Text.ToString().ToLower()))
                {
                    Searched.Add(Rule);
                }
            }
            RulesGrid.ItemsSource = Searched;

        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            allRules = _context.Rules.ToList();
            RulesGrid.ItemsSource = allRules;
        }
    }
}
