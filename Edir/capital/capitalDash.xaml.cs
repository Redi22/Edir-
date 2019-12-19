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

namespace Edir.capital
{
    /// <summary>
    /// Interaction logic for capitalDash.xaml
    /// </summary>
    public partial class capitalDash : UserControl
    {
        private EdirDbContext _context = null;
        public capitalDash()
        {
            InitializeComponent();
            _context = new EdirDbContext();
            capital.Text = _context.Abouts.FirstOrDefault().Capital.ToString();
        }
       
    }
}
