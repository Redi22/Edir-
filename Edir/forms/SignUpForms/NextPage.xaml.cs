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

namespace Edir.forms.SignUpForms
{
    /// <summary>
    /// Interaction logic for NextPage.xaml
    /// </summary>
    public partial class NextPage : UserControl
    {
        long PayMem;
        long PaySib;
        long PayChildMon;
        long PayParentMon;
        long EventFin;
        List<long> pays;
        public NextPage()
        {
            InitializeComponent();
            pays = new List<long>();
        }
        public List<long> Save()
        {
            PayMem = Convert.ToInt64(PayMember.Text.ToString());
            PaySib = Convert.ToInt64( PaySibling.Text.ToString());
            PayChildMon = Convert.ToInt64(PayChild.Text.ToString());
            PayParentMon = Convert.ToInt64(PayParent.Text.ToString());
            EventFin = Convert.ToInt64(DefEventFin.Text.ToString());
            pays.Add(PayMem);
            pays.Add(PaySib);
            pays.Add(PayChildMon);
            pays.Add(PayParentMon);
            pays.Add(EventFin);
            return pays;


        }
    }
}
