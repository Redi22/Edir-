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

namespace Edir.forms
{
    /// <summary>
    /// Interaction logic for AttendanceForm.xaml
    /// </summary>
    public partial class AttendanceForm : UserControl
    {
        List<Member> members;
        private EdirDbContext _context = null;
        Member member = new Member();
        DataGrid EventGrid;
        EdirEvent eve;
        Attendace attendance;
        
        public AttendanceForm()
        {
            InitializeComponent();
            _context = new EdirDbContext();
            eve = new EdirEvent();
            attendance = new Attendace();
        }
        public void GridInitializer(DataGrid EventGrid)
        {
            this.EventGrid = EventGrid;

        }

        private void MemberDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var gr = sender as DataGrid;
            members = _context.Members.ToList();
            gr.ItemsSource = members;


        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (Member member in members)
            {
                member.AttendStatus = false;
                _context.Entry(member).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int checkBoxColum = 4;
            eve = ((EdirEvent)EventGrid.SelectedItem);
            List<Member> selectedMembers = new List<Member>();
            List<Attendace> pays = new List<Attendace>();
            for (int i = 0; i < MemberDataGrid.Items.Count - 1; i++)
            {
                var item = MemberDataGrid.Items[i];
                var payStatusCheckbox = MemberDataGrid.Columns[checkBoxColum].GetCellContent(item) as CheckBox;
                TextBlock Id_block = MemberDataGrid.Columns[0].GetCellContent(item) as TextBlock;
                long Id = Convert.ToInt64(Id_block.Text);
                if ((bool)payStatusCheckbox.IsChecked)
                {
                    Member member = _context.Members.FirstOrDefault(m => m.Id == Id);
                    member.AttendStatus = true;
                    attendance.MemberId = member.Id;
                    attendance.EventId = eve.Id;
                    _context.Attendances.Add(attendance);
                    _context.Entry(member).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();


                }
            }
            foreach (Member member in members)
            {

                if (member.AttendStatus == false)
                {
                    member.Debit += eve.Fin;
                    _context.Entry(member).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
        }

    
    }
}
