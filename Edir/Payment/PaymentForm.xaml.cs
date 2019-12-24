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

namespace Edir.Payment
{
    /// <summary>
    /// Interaction logic for PaymentForm.xaml
    /// </summary>
    public partial class PaymentForm : UserControl
    {
        About Edir;
       List<Member> members;
        private EdirDbContext _context = null;
        Member member = new Member();
        DateTime PaymentDate = DateTime.Now.Date;
        double Amount;
        public PaymentForm()
        {
            InitializeComponent();
            _context = new EdirDbContext();
            Edir = _context.Abouts.FirstOrDefault();
            members = _context.Members.ToList();
            MemberDataGrid.ItemsSource = members;
            Amount = Edir.MonthlyPayment;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Member> selectedMembers = new List<Member>();
            List<Pay> pays = new List<Pay>();
            Pay pay = new Pay();
                pays = _context.Payments.ToList();
                int checkBoxColum = 4;
                for (int i = 0; i < MemberDataGrid.Items.Count-1; i++)
                {
                    var item = MemberDataGrid.Items[i];
                    var payStatusCheckbox = MemberDataGrid.Columns[checkBoxColum].GetCellContent(item) as CheckBox;
                    var stg = MemberDataGrid.Columns[0].GetCellContent(item) as TextBlock;
                    long Id = Convert.ToInt64(stg.Text);
                if ((bool)payStatusCheckbox.IsChecked)
                    {
                    Member member = _context.Members.FirstOrDefault(m => m.Id == Id);
                    member.PayStatus = true;
                    pay.MemberId = member.Id;
                    pay.PaidDate = DateTime.Now.Date;
                    _context.Payments.Add(pay);
                    _context.Entry(member).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();
                }
                }
                foreach(Member m in selectedMembers)
                {

                if (member.PayStatus == false)
                {
                    member.Debit += Amount;
                    _context.Entry(member).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
               
                Edir.Capital += (pays.Count() * Amount);
                _context.Entry(Edir).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                }

     
            
            
        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            members = _context.Members.ToList();

            foreach (Member member in members)
            {
                member.PayStatus = false;
                _context.Entry(member).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }

        }

        private void MemberId_Loaded(object sender, RoutedEventArgs e)
        {
            var gr = sender as ComboBox;
            members = _context.Members.ToList();
            gr.ItemsSource = members;
        }

        private void FullPay_Click(object sender, RoutedEventArgs e)
        {
            Member mem = ((Member)MemberId.SelectedItem);
            if(mem != null)
            {
                double amount = Convert.ToInt64(amountPaid.Text);
                Edir.Capital += amount;
                mem.Debit -= amount;
                _context.Entry(mem).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                Pay pay = new Pay();
                pay.PaidDate = PaymentDate;
                pay.Type = "Debit Cover";
                pay.MemberId = mem.Id;
                pay.Amount = amount;
                _context.Payments.Add(pay);
                _context.SaveChanges();
            }

        }
    }
   
       
    }

