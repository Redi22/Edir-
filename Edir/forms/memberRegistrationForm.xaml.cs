using Edir.Models;
using Edir.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using Edir.notification;
using System.Windows.Threading;

namespace Edir.forms
{
    /// <summary>
    /// Interaction logic for memberRegistrationForm.xaml
    /// </summary>
    public partial class memberRegistrationForm : UserControl
    {
        List<Member> allMembers;
        childRegistrationForm ChildForm;
        SpouseAndParentsView SpouseForm; SibRegistrationForm SibForm; SpouceSibRegistrationForm SpouseSibForm;
        Member Mem = new Member();
        int SelectedSubcity;
        private EdirDbContext _context = null;
        Spouse spouse = new Spouse();
        Loss Loss = new Loss();
        About Edir;
        double PayChild, PaySpou, PaySib, PayParents;
        public List<string> Types { get; set; }
        public memberRegistrationForm()
        {
            InitializeComponent();
            //Create Db Context Instance  Types.Add("Child");
            _context = new EdirDbContext();
           allMembers = _context.Members.ToList();
            MemGrid.ItemsSource = allMembers;
            Edir = _context.Abouts.FirstOrDefault();
            if (Edir != null)
            {

              PayChild = Edir.PayChildDeseced; PaySpou = Edir.PayMemberDeseced; PaySib = Edir.PaySiblingDeseced; PayParents = Edir.PayParentDeseced;
            }
        }

        public void Clear()
        {
            MemName.Text =
            MemLastName.Text =
            MemMotherName.Text =
            Woreda.Text =
            Kebele.Text =
            HouseNum.Text =
            Phone.Text = "";
            GenderBtn.IsChecked =
            MarriageStat.IsChecked = false;
            Clear_Spouse();
        }
        public void Clear_Spouse()
        {
            SpouName.Text =
            SpoFatherName.Text =
            SpoMotherName.Text = "";
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            Member SelectedMember = ((Member)MemGrid.SelectedItem);

            if (SelectedMember != null)
            {
                SelectedMember.FirstName = MemName.Text.Trim();
                SelectedMember.LastName = MemLastName.Text.Trim();
                SelectedMember.MotherName = MemMotherName.Text.Trim();
                SelectedMember.SubCity = Subcity.Text;
                if (GenderBtn.IsChecked.GetValueOrDefault())
                {
                    SelectedMember.Gender = "Female";
                }
                else
                {
                    SelectedMember.Gender = "Male";
                }
                if (MarriageStat.IsChecked.GetValueOrDefault())
                {
                    SelectedMember.MariageStatus = true;
                    
                }
                else
                {
                    SelectedMember.MariageStatus = false;

                }
                SelectedSubcity = Subcity.SelectedIndex;

                if (SelectedSubcity == 0)
                {
                    Mem.SubCity = "Arada";
                }
                else if (SelectedSubcity == 1)
                {
                    Mem.SubCity = "Akaki/Kality";
                }
                else if (SelectedSubcity == 2)
                {
                    Mem.SubCity = "Bole";
                }
                else if (SelectedSubcity == 3)
                {
                    Mem.SubCity = "Kolfe Keraniyo";
                }
                else if (SelectedSubcity == 4)
                {
                    Mem.SubCity = "Yeka";
                }
                else if (SelectedSubcity == 5)
                {
                    Mem.SubCity = "Gulele";
                }
                else if (SelectedSubcity == 6)
                {
                    Mem.SubCity = "Ledeta";
                }
                else if (SelectedSubcity == 7)
                {
                    Mem.SubCity = "Nefas Silk";
                }
                else if (SelectedSubcity == 8)
                {
                    Mem.SubCity = "Kirkos";
                }
                else if (SelectedSubcity == 9)
                {
                    Mem.SubCity = "Addis Ketema";
                }

                SelectedMember.Woreda = Convert.ToInt64(Woreda.Text);
                SelectedMember.Kebele = Convert.ToInt64(Kebele.Text);
                SelectedMember.HouseNummber = HouseNum.Text.Trim();
                SelectedMember.PhoneNumber = Convert.ToInt64(Phone.Text);

               
                _context.Entry(SelectedMember).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
            ErrorMessage message = new ErrorMessage();
            message.SetContent("You have made an update");
            message.Show();
            Clear();
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Mem.FirstName = MemName.Text.Trim();
            Mem.LastName = MemLastName.Text.Trim();
            Mem.MotherName = MemMotherName.Text.Trim();
            Mem.SubCity = Subcity.Text;
            
            if (GenderBtn.IsChecked.GetValueOrDefault())
            {
                Mem.Gender = "Female";
            }
            else
            {
                Mem.Gender = "Male";
            }
            if (MarriageStat.IsChecked.GetValueOrDefault())
            {
                Mem.MariageStatus = true;

            }
            else
            {
                Mem.MariageStatus = false;

            }
            SelectedSubcity = Subcity.SelectedIndex;
            
            if(SelectedSubcity == 0)
            {
                Mem.SubCity = "Arada";
            }else if(SelectedSubcity == 1)
            {
                Mem.SubCity = "Akaki/Kality";
            }else if(SelectedSubcity == 2)
            {
                Mem.SubCity = "Bole";
            }else if(SelectedSubcity == 3)
            {
                Mem.SubCity = "Kolfe Keraniyo";
            }else if(SelectedSubcity == 4)
            {
                Mem.SubCity = "Yeka";
            }else if(SelectedSubcity == 5)
            {
                Mem.SubCity = "Gulele";
            }else if(SelectedSubcity == 6)
            {
                Mem.SubCity = "Ledeta";
            }else if(SelectedSubcity == 7)
            {
                Mem.SubCity = "Nefas Silk";
            }else if(SelectedSubcity == 8)
            {
                Mem.SubCity = "Kirkos";
            }else if(SelectedSubcity == 9)
            {
                Mem.SubCity = "Addis Ketema";
            }
            
            Mem.Woreda = Convert.ToInt64(Woreda.Text);
            Mem.Kebele = Convert.ToInt64(Kebele.Text);
            Mem.HouseNummber = HouseNum.Text.Trim();
            Mem.PhoneNumber = Convert.ToInt64(Phone.Text);
            Mem.RegisteredDate = DateTime.Now.Date;

            _context.Members.Add(Mem);
            _context.SaveChanges();
            SucessMessage sm = new SucessMessage();
            sm.MessageText.Text = "Registered Successfully";
            sm.Show();
            Clear();


        }
    

        private void MemGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Member SelectedMember = ((Member)MemGrid.SelectedItem);
            if (SelectedMember != null)
            {
            LossType.IsEnabled = true;
                if (SelectedMember.MariageStatus)
                {
                    Spouse s = ((Spouse)_context.spouses.FirstOrDefault(d => d.ParentId == SelectedMember.Id));
                        if(s != null)
                        {
                            SpouName.Text = s.Name;
                            SpoFatherName.Text = s.FatherName;
                            SpoMotherName.Text = s.MotherName;
                        }
                
                }
                    else
                    {
                        SpouName.Text = "";
                        SpoFatherName.Text = "";
                        SpoMotherName.Text = "";
                        
                    }
            MemName.Text = SelectedMember.FirstName.ToString();
            MemLastName.Text = SelectedMember.LastName.ToString();
            MemMotherName.Text = SelectedMember.MotherName.ToString();
            Woreda.Text = SelectedMember.Woreda.ToString();
            Kebele.Text = SelectedMember.Kebele.ToString();
            HouseNum.Text = SelectedMember.HouseNummber.ToString();
            Phone.Text = SelectedMember.PhoneNumber.ToString();
            if(SelectedMember.Gender == "female")
                {
                    GenderBtn.IsChecked = false;
                } else {
                    GenderBtn.IsChecked = true;
                }
            if (SelectedMember.MariageStatus == true)
                {
                    MarriageStat.IsChecked = true;

                }else
                {
                    MarriageStat.IsChecked = false;

                }
            if(SelectedMember.SubCity == "Arada")
                {
                    Subcity.SelectedIndex = 0;
                }else if(SelectedMember.SubCity == "Akaki / Kality")
                {
                    Subcity.SelectedIndex = 1;
                }else if(SelectedMember.SubCity == "Bole")
                {
                    Subcity.SelectedIndex = 2;
                }else if(SelectedMember.SubCity == "Kolfe Keraniyo")
                {
                    Subcity.SelectedIndex = 3;
                }else if(SelectedMember.SubCity == "Yeka")
                {
                    Subcity.SelectedIndex = 4;
                }else if(SelectedMember.SubCity == "Gulele")
                {
                    Subcity.SelectedIndex = 5;
                }else if(SelectedMember.SubCity == "Ledeta")
                {
                    Subcity.SelectedIndex = 6;
                }else if(SelectedMember.SubCity == "Nefas Silk")
                {
                    Subcity.SelectedIndex = 7;
                }else if(SelectedMember.SubCity == "Kirkos")
                {
                    Subcity.SelectedIndex = 8;
                }else if(SelectedMember.SubCity == "Addis Ketema")
                {
                    Subcity.SelectedIndex = 9;
                }
            }
            ChildMenu_Click();
            SpouseMenu_Click();
            SibMenu_Click();
            SpouSibMenu_Click();
            if(SelectedMember != null)
            {
                ViolationsView.ItemsSource = _context.Violations.Where(v => v.MemberId == SelectedMember.Id).ToList();
                LossesView.ItemsSource = _context.Losses.Where(v => v.ParentId == SelectedMember.Id).ToList();

            }
        }


        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Member SelectedMember = ((Member)MemGrid.SelectedItem);

            if (SelectedMember != null)
            {
                DeleteConfirmation deleteConfirmation = new DeleteConfirmation();
                deleteConfirmation.assigner(SelectedMember);
                deleteConfirmation.Show();
                MemGrid.Items.Refresh();
                
            }
            Clear();
        }

        private void MenuChoice_Unchecked(object sender, RoutedEventArgs e)
        {
         
        }

        private void MenuChoice_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void ChildMenu_Click()
        {
            Member SelectedMember = ((Member)MemGrid.SelectedItem);

            if (SelectedMember != null)
            {

                ChildForm = new childRegistrationForm();
                ChildForm.GetParentId(SelectedMember);

                ChildView.Children.Clear();
                ChildView.Children.Add(ChildForm);



            }
        }

        private void SpouseMenu_Click()
        {Member SelectedMember = ((Member)MemGrid.SelectedItem);

            if (SelectedMember != null)
            {
                SpouseForm = new  SpouseAndParentsView();
                SpouseForm.GetParentId(SelectedMember);

                SpouseView.Children.Clear();
                SpouseView.Children.Add(SpouseForm);
                SpouseForm.SpouceView();
              


            }

        }

        private void SibMenu_Click()
        {
            Member SelectedMember= ((Member)MemGrid.SelectedItem);

            if (SelectedMember != null)
            {
                SibForm = new SibRegistrationForm();
                SibForm.GetParentId(SelectedMember); 

                SiblingsView.Children.Clear();
                SiblingsView.Children.Add(SibForm);
            }



        }

        private void SpouSibMenu_Click()
        {
            Member SelectedMember = ((Member)MemGrid.SelectedItem);

            if (SelectedMember != null)
            {
                SpouseSibForm = new SpouceSibRegistrationForm();
                SpouseSibForm.GetParentId(SelectedMember);

                SpoSiblingsView.Children.Clear();
                SpoSiblingsView.Children.Add(SpouseSibForm);


            }

           
        }
        private void RulesViolated()
        {
            Member SelectedMember = ((Member)MemGrid.SelectedItem);

            if (SelectedMember != null)
            {
                List<Violation> violations = _context.Violations.Where(v => v.MemberId == SelectedMember.Id).ToList();
                ViolationsView.ItemsSource = violations;
            }
        }
         private void PreviousLosses()
        {
            Member SelectedMember = ((Member)MemGrid.SelectedItem);

            if (SelectedMember != null)
            {
                List<Loss> losses = _context.Losses.Where(v => v.ParentId == SelectedMember.Id).ToList();
                ViolationsView.ItemsSource = losses;
            }
        }

            private void LossType_Loaded(object sender, RoutedEventArgs e)
        {
          
            var gr = sender as ComboBox;
            gr.ItemsSource = Types;
        }

      
        public void Condolence()
        {
            Condolence Condolence = new Condolence();
            Condolence.MessageText.Text = "We are Sorry for the loss";
            Condolence.Show();
        }
        private void ReportBtn_Click(object sender, RoutedEventArgs e)
        {

            if(Fundamental.IsChecked.GetValueOrDefault() == true)
            {
               //Member Descised = ((Member)MemGrid.SelectedItem);
               // _context.Losses.Add(Loss);
               // _context.Entry(Descised).State = System.Data.Entity.EntityState.Deleted;
                
               // foreach (var child in )
               // {
               //     _context.Childs.Attach(child);
               //     _context.Entry(child).State = EntityState.Modified;
               // }
               // foreach (var child in Descised.Siblings)
               // {
               //     _context.Siblings.Attach(child);
               //     _context.Entry(child).State = EntityState.Modified;
               // }
               // foreach (var child in Descised.SpouseSiblings)
               // {
               //     _context.SpouseSiblings.Attach(child);
               //     _context.Entry(child).State = EntityState.Modified;
               // }
               // Spouse spo = _context.spouses.FirstOrDefault(s => s.ParentId == Descised.Id);
               // _context.Entry(spo).State = EntityState.Modified;
               // _context.SaveChanges();
            }
            long Type = Convert.ToInt64(LossType.SelectedIndex);
            if (Type == 1)
            {
                Child Descised = (Child)(AliveFamilyMembers.SelectedItem);
                 Loss.Description = Description.Text.Trim();
                 Member Selected = ((Member) MemGrid.SelectedItem);
                Loss.ParentId = Selected.Id;
                Loss.PaidMoney = PayChild;
                Edir.Capital -= PayChild;
                if(Edir.Capital < 0)
                {
                    ErrorMessage er = new ErrorMessage();
                    er.MessageText.Text = "Can not provide such amount";
                    er.Show();
                    Loss.PaidMoney = -1 * Edir.Capital;
                    Edir.Capital = 0;
                }
                Loss.Date = Convert.ToDateTime(DateOfDeath.Text);
                _context.Losses.Add(Loss);
                _context.Entry(Descised).State = System.Data.Entity.EntityState.Deleted;
                _context.Entry(Edir).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                Condolence();
            }
            else if (Type == 0)
            {
                
                Member Selected = ((Member)MemGrid.SelectedItem);
                Spouse Descised = _context.spouses.FirstOrDefault(s => s.ParentId == Selected.Id);
                 Loss.Description = Description.Text.Trim();
                if (Edir.Capital - PaySpou < 0)
                {
                    ErrorMessage er = new ErrorMessage();
                    er.MessageText.Text = "Can not provide such amount";
                    er.Show();
                    Loss.PaidMoney = Edir.Capital;
                    Edir.Capital = 0;
                }
                else
                {
                    Edir.Capital -= PaySpou;
                    Loss.PaidMoney = PaySpou;
                    

                }
                Loss.ParentId = Selected.Id;
                Loss.Date = Convert.ToDateTime(DateOfDeath.Text);
                _context.Losses.Add(Loss);
                _context.Entry(Descised).State = System.Data.Entity.EntityState.Deleted;
                _context.Entry(Edir).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                Condolence();

            }
            else if (Type == 2)
            {
                Sibling Descised = (Sibling)(AliveFamilyMembers.SelectedItem);
                Loss.Description = Description.Text.Trim();
                Member Selected = ((Member)MemGrid.SelectedItem);
                if(Edir.Capital - PaySib < 0)
                {
                    ErrorMessage er = new ErrorMessage();
                    er.MessageText.Text = "Can not provide such amount";
                    er.Show();
                    Loss.PaidMoney = Edir.Capital;
                    Edir.Capital = 0;
                }
                else
                {
                    Loss.PaidMoney = PaySib;
                    Edir.Capital -= PaySib;

                }

                Loss.ParentId = Selected.Id;
                Loss.Date = Convert.ToDateTime(DateOfDeath.Text);
                _context.Losses.Add(Loss);
                _context.Entry(Descised).State = System.Data.Entity.EntityState.Deleted;
                _context.Entry(Edir).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                Condolence();

            }
            else if (Type == 3)
            {

                SpouseSibling Descised = (SpouseSibling)(AliveFamilyMembers.SelectedItem);
                Loss.Description = Description.Text.Trim();
                Member Selected = ((Member)MemGrid.SelectedItem);
                if (Edir.Capital - PaySib < 0)
                {
                    ErrorMessage er = new ErrorMessage();
                    er.MessageText.Text = "Can not provide such amount";
                    er.Show();
                    Loss.PaidMoney = Edir.Capital;
                    Edir.Capital = 0;
                }
                else
                {
                    Loss.PaidMoney = PaySib;
                    Edir.Capital -= PaySib;

                }
              
                Loss.ParentId = Selected.Id;
                Loss.Date = Convert.ToDateTime(DateOfDeath.Text);
                _context.Losses.Add(Loss);
                _context.Entry(Edir).State = System.Data.Entity.EntityState.Modified;
                _context.Entry(Descised).State = System.Data.Entity.EntityState.Deleted;
                _context.SaveChanges();
                Condolence();

            }else if (Type == 4)
            {

                Loss.Description = Description.Text.Trim();
                Member Selected = ((Member)MemGrid.SelectedItem);
                if (Edir.Capital - PayParents < 0)
                {
                    ErrorMessage er = new ErrorMessage();
                    er.MessageText.Text = "Can not provide such amount";
                    er.Show();
                    Loss.PaidMoney = Edir.Capital;
                    Edir.Capital = 0;
                }
                else
                {
                    Edir.Capital -= PayParents;
                    Loss.PaidMoney = PayParents;

                }
                
                Loss.ParentId = Selected.Id;
                Loss.Date = Convert.ToDateTime(DateOfDeath.Text);
                _context.Entry(Edir).State = System.Data.Entity.EntityState.Modified;
                _context.Losses.Add(Loss);
                _context.SaveChanges();
                Condolence();

            }
        }

        

        private void MarriageStat_Checked(object sender, RoutedEventArgs e)
        {
            SpouName.IsEnabled = true;
            SpoMotherName.IsEnabled = true;
            SpoFatherName.IsEnabled = true;
        }

        private void MarriageStat_Unchecked(object sender, RoutedEventArgs e)
        {
            SpouName.IsEnabled = false;
            SpoMotherName.IsEnabled = false;
            SpoFatherName.IsEnabled = false;

        }

        private void LossType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (!Fundamental.IsChecked.GetValueOrDefault())
            {

                long Type = Convert.ToInt64(LossType.SelectedIndex);
            
                Member SelectedMember = ((Member)MemGrid.SelectedItem);
                    Console.WriteLine(Type);
                if (SelectedMember != null)
                {

                    var SelectedMemChildren = _context.Childs.Where(i => i.ParentId == SelectedMember.Id).ToList();
                    var SelectedMemSib = _context.Siblings.Where(i => i.ParentId == SelectedMember.Id).ToList();
                    var SelectedMemSpouSib = _context.SpouseSiblings.Where(i => i.ParentId == SelectedMember.Id).ToList();
                    var SelectedMemSpouse = _context.SpouseSiblings.FirstOrDefault(i => i.ParentId == SelectedMember.Id);

                
                    if(Type == 1)
                    {
                        AliveFamilyMembers.IsEnabled = true;

                        AliveFamilyMembers.ItemsSource = SelectedMemChildren;

                    }else if(Type == 0)
                    {

                        AliveFamilyMembers.IsEnabled = false;

                    }else if(Type == 2)
                    {
                        AliveFamilyMembers.IsEnabled = true;

                        AliveFamilyMembers.ItemsSource = SelectedMemSib;

                    }else if(Type == 3)
                    {
                        AliveFamilyMembers.IsEnabled = true;

                        AliveFamilyMembers.ItemsSource = SelectedMemSpouSib;

                    }
               }
                else
                {

                }
            }
        }

        private void UpdateSpo_Click(object sender, RoutedEventArgs e)
        {
            Member SelectedMember = ((Member)MemGrid.SelectedItem);
            if (SelectedMember != null)
            {
                Spouse Selected = ((Spouse) _context.spouses.FirstOrDefault(s => s.ParentId == SelectedMember.Id));
                if (Selected != null)
                {

                   Selected.Name = SpouName.Text.Trim();
                   Selected.FatherName = SpoFatherName.Text.Trim();
                   Selected.MotherName = SpoMotherName.Text.Trim();
                    
                    _context.Entry(Selected).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();
                    Clear_Spouse();
                }
                else
                {
                    ErrorMessage er = new ErrorMessage();
                    er.MessageText.Text = "Must Select a Member first";
                    er.Show();
                }
            }
        
        }

        private void DeleteSpo_Click(object sender, RoutedEventArgs e)
        {
            Member SelectedMember = ((Member)MemGrid.SelectedItem);
            if (SelectedMember != null)
            {
                Spouse Selected = ((Spouse)_context.spouses.FirstOrDefault(s => s.ParentId == SelectedMember.Id));
                if (Selected != null)
                {
                    DeleteConfirmation deleteConfirmation = new DeleteConfirmation();
                    deleteConfirmation.assigner(Selected);
                    deleteConfirmation.Show();
                    Clear_Spouse();
                    SelectedMember.MariageStatus = false;
                    _context.Entry(SelectedMember).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();
             

                }
                else
                {
                    ErrorMessage er = new ErrorMessage();
                    er.MessageText.Text = "Must Select a Member first";
                    er.Show();
                }
            }
        }

        private void Search_KeyUp(object sender, KeyEventArgs e)
        {
            List<Member> searched = new List<Member>();
            foreach(Member member in allMembers)
            {
               if(member.FirstName.ToLower().Contains(Search.Text.ToString().ToLower()))
                {
                    searched.Add(member);
                }
            }
            MemGrid.ItemsSource = searched;
        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            allMembers = _context.Members.ToList();
            MemGrid.ItemsSource = allMembers;
            if(ChildForm != null)
            {
                ChildForm.refreshBtn_Click();
            }if(SpouseForm != null)
            {
                SpouseForm.SpouceView();
            }
            if(SibForm != null)
            {
                SibForm.refreshBtn_Click();
            }
            if(SpouseSibForm != null)
            {
                SpouseSibForm.refreshBtn_Click();
            }
        }

        private void AddSpo_Click(object sender, RoutedEventArgs e)
        {
            Member SelectedMember = ((Member)MemGrid.SelectedItem);
            if (SelectedMember != null)
            {
                Spouse Selected = new Spouse();
                var Ex = _context.spouses.FirstOrDefault(m => m.ParentId == SelectedMember.Id);
                if(Ex != null)
                {
                    ErrorMessage Error = new ErrorMessage();
                    Error.MessageText.TextWrapping = TextWrapping.Wrap;
                    Error.MessageText.Text = "Spouce already registered!";
                    Error.Show();
                }
                else
                {

                 Selected.Name = SpouName.Text.Trim();
                 Selected.FatherName = SpoFatherName.Text.Trim();
                 Selected.MotherName = SpoMotherName.Text.Trim();
                 Selected.ParentId = SelectedMember.Id;
                     
                _context.spouses.Add(Selected);
                _context.SaveChanges();
                SelectedMember.MariageStatus = true;
                _context.Entry(SelectedMember).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                Clear_Spouse();


                }

            }
            else
            {
                ErrorMessage er = new ErrorMessage();
                er.MessageText.Text = "Must Select a Member first";
                er.Show();
            }
        }

     

        private void Fundamental_Unchecked(object sender, RoutedEventArgs e)
        {
            AliveFamilyMembers.IsEnabled = true;
            LossType.IsEnabled = true;

        }
        private void Fundamental_Checked(object sender, RoutedEventArgs e)
        {
            AliveFamilyMembers.IsEnabled = false;
            LossType.IsEnabled = false;

        }

    }
}







