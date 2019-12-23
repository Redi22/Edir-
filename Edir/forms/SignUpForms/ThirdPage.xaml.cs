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

namespace Edir.forms.SignUpForms
{
    /// <summary>
    /// Interaction logic for ThirdPage.xaml
    /// </summary>
    public partial class ThirdPage : UserControl
    {
       
        About Edir;
        Role role;
        private EdirDbContext _context = null;
        public ThirdPage()
        {
            InitializeComponent();
            Edir = new About();
            _context = new EdirDbContext();
            role = new Role();
        }

        public void Initialize(string EdirName, string Description , double PayMem ,double PaySib, double PayChild, double PayParent, double EventFin   )
        {
            try
            {
                Edir.EdirName = EdirName;
                Edir.Description = Description;
                Edir.PayMemberDeseced = PayMem;
                Edir.PaySiblingDeseced = PaySib;
                Edir.PayChildDeseced = PayChild;
                Edir.PayParentDeseced = PayParent;
                Edir.DefaultEventFin = EventFin;
                Edir.DefaultFirstFin = Convert.ToInt64(FirstFin.Text.ToString());
                Edir.DefaultSecondFin = Convert.ToInt64(SecondFin.Text.ToString());
                Edir.DefaultFinalFin = Convert.ToInt64(FinalFin.Text.ToString());
                Edir.Capital = 0;
                Edir.CreatedDate = DateTime.Now.Date;
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.Message);
                
            }
          
        }
        private void FinishBtn_Click(object sender, RoutedEventArgs e)
        {
            DateTime now = DateTime.Now.Date;
            role.Name = "Super Admin";
            role.Description = "this admin has all privilages and also must add new admins.";
            role.SuperAdminPrivilage = true;
            role.RoleCreationDate = now;
            _context.Roles.Add(role);
            _context.SaveChanges();

            role.Name = "Admin";
            role.Description = "this admin has all privilages except store privilages. There can be multiple admins but all will have equal privilages.";
            role.SuperAdminPrivilage = role.StorePrivilage = false;
            role.RulePrivilage = role.PaymentPrivilage = role.MemberPrivilage = role.EventPrivilage = true;
            role.RoleCreationDate = now;
            _context.Roles.Add(role);
            _context.SaveChanges();

            role.Name = "Store Keeper";
            role.Description = "this admin has privilages involving the store management. There can be multiple store admins but all will have equal privilages.";
            role.RoleCreationDate = now;
            role.StorePrivilage = true;
            role.SuperAdminPrivilage = role.RulePrivilage = role.PaymentPrivilage = role.MemberPrivilage = role.EventPrivilage = false;
            _context.Roles.Add(role);
            _context.SaveChanges();

            _context.Abouts.Add(Edir);
            _context.SaveChanges();
            
        }
    }
}
