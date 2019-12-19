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

namespace Edir.forms
{
    /// <summary>
    /// Interaction logic for SpouseAndParentsView.xaml
    /// </summary>
    public partial class SpouseAndParentsView : UserControl
    {
        private EdirDbContext _context = null;
        long SelParent;
        
        public SpouseAndParentsView()
        {
            InitializeComponent();

            _context = new EdirDbContext();
            
        }
        public void GetParentId( Member i)
        {
            SelParent = i.Id;

        }
        public void SpouceView()
        {
            Spouse  S = _context.spouses.FirstOrDefault(s => s.ParentId == SelParent);
            if(S != null)
            {
            SpouseName.Text = S.Name;
            SpouseFName.Text = S.FatherName;
            SpouseMName.Text = S.MotherName;
            }
            
        }
    }
}
