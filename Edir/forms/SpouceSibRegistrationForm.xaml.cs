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
    /// Interaction logic for SpouceSibRegistrationForm.xaml
    /// </summary>
    public partial class SpouceSibRegistrationForm : UserControl
    {
        private EdirDbContext _context = null;
        long SelParent = 0;
        SpouseSibling Sib = new SpouseSibling();
        List<SpouseSibling> spouseSiblings;
        public SpouceSibRegistrationForm()
        {
            InitializeComponent();
            _context = new EdirDbContext();
            refreshBtn_Click();

        }
        public void Clear()
        {
            ChildName.Text =
            Phone.Text = "";
        }
        public void refreshBtn_Click()
        {
            spouseSiblings = _context.SpouseSiblings.Where(c => c.ParentId == SelParent).ToList();
            SpouseSibGrid.ItemsSource = spouseSiblings;
        }

        public void GetParentId(Edir.Model.Member i)
        {
            SelParent = i.Id;
        }
       

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Sib.Name = ChildName.Text.Trim();
            Sib.Phone = Convert.ToInt64(Phone.Text);
            Sib.ParentId = SelParent;

            _context.SpouseSiblings.Add(Sib);
            _context.SaveChanges();
            refreshBtn_Click();
            Clear();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            SpouseSibling SelectedSib = ((SpouseSibling)SpouseSibGrid.SelectedItem);

            if (SelectedSib != null)
            {
                SelectedSib.Name = ChildName.Text.Trim();
                SelectedSib.Phone = Convert.ToInt64(Phone.Text);

                _context.Entry(SelectedSib).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                refreshBtn_Click();
                Clear();
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            SpouseSibling SelectedSib = ((SpouseSibling)SpouseSibGrid.SelectedItem);


            if (SelectedSib != null)
            {
                _context.Entry(SelectedSib).State = System.Data.Entity.EntityState.Deleted;
                _context.SaveChanges();
                Clear();
                refreshBtn_Click();
            }
        }

        private void SpouseSibGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SpouseSibling SelectedSib = ((SpouseSibling)SpouseSibGrid.SelectedItem);
            if (SelectedSib != null)
            {
                ChildName.Text = SelectedSib.Name.ToString();
                Phone.Text = SelectedSib.Phone.ToString();

            }
        }
    }
}
