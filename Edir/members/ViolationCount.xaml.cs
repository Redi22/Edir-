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

namespace Edir.members
{
    /// <summary>
    /// Interaction logic for Violation.xaml
    /// </summary>
    public partial class ViolationCount : UserControl
    {
        private EdirDbContext _context = null;
        public ViolationCount()
        {
            InitializeComponent();
            _context = new EdirDbContext();
            violation.Text = _context.Violations.Count().ToString();
        }
    }
}
