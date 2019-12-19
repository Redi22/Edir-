using Edir.Models;
using Edir.Model;
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
    /// Interaction logic for childRegistrationForm.xaml
    /// </summary>
    public partial class childRegistrationForm : UserControl
    {
        private EdirDbContext _context = null;
        long SelParent = 0;
        Child Ch = new Child();
        List<Child> children;
        public childRegistrationForm()
        {
            InitializeComponent();
            _context = new EdirDbContext();


        }
        public void GetParentId(Edir.Model.Member i)
        {
            SelParent = i.Id ;
            refreshBtn_Click();

        }
        public void Clear()
        {
            ChildName.Text =
            Phone.Text = "";
        }
        public void refreshBtn_Click()
        {

            children = _context.Childs.Where(c => c.ParentId == SelParent).ToList();
            ChildGrid.ItemsSource = children;
        }
        

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Ch.Name = ChildName.Text.Trim();
            Ch.Phone = Convert.ToInt64( Phone.Text.Trim());
            Ch.ParentId = SelParent;
            
            _context.Childs.Add(Ch);
            _context.SaveChanges();
            refreshBtn_Click();
            Clear();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Child SelectedChild = ((Child)ChildGrid.SelectedItem);

            if (SelectedChild != null)
            {
                SelectedChild.Name = ChildName.Text.Trim();
                SelectedChild.Phone = Convert.ToInt64(Phone.Text.Trim());

                _context.Entry(SelectedChild).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                Clear();
                refreshBtn_Click();

            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Child SelectedChild = ((Child)ChildGrid.SelectedItem);

          
            if (SelectedChild != null)
            { 
                _context.Entry(SelectedChild).State = System.Data.Entity.EntityState.Deleted;
                _context.SaveChanges();
                Clear();
                refreshBtn_Click();

            }
        }

        private void ChildGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Child SelectedChild = ((Child) ChildGrid.SelectedItem);
            if(SelectedChild != null)
            {
                ChildName.Text = SelectedChild.Name.ToString();
                Phone.Text = SelectedChild.Phone.ToString();

            }
        }
    }
}
