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
    /// Interaction logic for Essentials.xaml
    /// </summary>
    public partial class Essentials : UserControl
    {
        List<String> info;
        String name, description;
        public Essentials()
        {
            InitializeComponent();
            info = new List<String>();
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        public List<String> save()
        {
            name = EdirName.Text.Trim();
            description = Description.Text.TrimEnd();
            info.Add(name);
            info.Add(description);

            return info;
        }
    }
}
