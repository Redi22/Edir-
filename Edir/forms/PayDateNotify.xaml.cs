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
    /// Interaction logic for PayDateNotify.xaml
    /// </summary>
    public partial class PayDateNotify : UserControl
    {
        public PayDateNotify()
        {
            InitializeComponent();
        }
        public void SetContent(string message)
        {
            MessageText.Text = message;
        }
    }
}
