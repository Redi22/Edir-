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
    /// Interaction logic for SibRegistrationForm.xaml
    /// </summary>
    public partial class SibRegistrationForm : UserControl
    {
        private EdirDbContext _context = null;
        long SelParent = 0;
        Sibling Sib = new Sibling();
        List<Sibling> siblings;
        public SibRegistrationForm()
        {
            InitializeComponent();
            _context = new EdirDbContext();
            
        }

        public void GetParentId(Edir.Model.Member i)
        {
            SelParent = i.Id;
            refreshBtn_Click();
        }
        public void refreshBtn_Click()
        {
            siblings = _context.Siblings.Where(c => c.ParentId == SelParent).ToList();
            SibGrid.ItemsSource = siblings;
        }
        
        public void Clear()
        {
            ChildName.Text =
            Phone.Text = "";
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Sib.Name = ChildName.Text.Trim();
            Sib.Phone = Convert.ToInt64(Phone.Text.Trim());
            Sib.ParentId = SelParent;

            _context.Siblings.Add(Sib);
            _context.SaveChanges();
            Clear();
            refreshBtn_Click();


        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Sibling SelectedSib = ((Sibling)SibGrid.SelectedItem);

            if (SelectedSib != null)
            {
                SelectedSib.Name = ChildName.Text.Trim();
                SelectedSib.Phone = Convert.ToInt64(Phone.Text.Trim());

                _context.Entry(SelectedSib).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                Clear();
                refreshBtn_Click();

            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Sibling SelectedSib = ((Sibling)SibGrid.SelectedItem);


            if (SelectedSib != null)
            {
                _context.Entry(SelectedSib).State = System.Data.Entity.EntityState.Deleted;
                _context.SaveChanges();
                Clear();
            }
        }

        private void SibGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sibling SelectedSib = ((Sibling)SibGrid.SelectedItem);
            if (SelectedSib != null)
            {
                ChildName.Text = SelectedSib.Name.ToString();
                Phone.Text = SelectedSib.Phone.ToString();

            }
        }

       
    }
}
