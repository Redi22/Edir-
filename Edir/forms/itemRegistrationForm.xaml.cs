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
using Edir.notification;

namespace Edir.forms
{
    /// <summary>
    /// Interaction logic for itemRegistrationForm.xaml
    /// </summary>
    public partial class itemRegistrationForm : UserControl
    {
        private EdirDbContext _context = null;
        Item item;
        About edir;
        List<Rental> rents;
        double totPrice, quan;
        List<Rental> rentals;
        List<Item> allitems;
      
        private double damageFee;

        public itemRegistrationForm()
        {
            InitializeComponent();

            _context = new EdirDbContext();
            edir = _context.Abouts.FirstOrDefault();
            allitems = _context.Items.ToList();
            ItemGrid.ItemsSource = allitems;
            AvailableItems_Loaded();
            item = new Item();
            RentedItems_Loaded();
        }

        public List<Item> ItemsList { get; set; }
        private void AvailableItems_Loaded()
        {
            var AllItems = _context.Items.ToList();
            AvailableItems.ItemsSource = AllItems;
        }

        private void RentedItems_Loaded()
        {
            var AllItem = _context.Items.ToList();
            var AllItems = new List<Item>();
            foreach (Item OneItem in AllItem)
            {
                if (OneItem.RentedQuantity >= 1)
                {
                    AllItems.Add(OneItem);
                }


            }
            ItemsList = AllItems;
            RentedItems.ItemsSource = ItemsList;

        }

        private void ItemGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var grid = sender as DataGrid;

            grid.ItemsSource = _context.Items.ToList();
        }

        private void ItemGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Item Selected = ((Item)ItemGrid.SelectedItem);
            if (Selected != null)
            {
                ItName.Text = Selected.Name.ToString();
                DayPayment.Text = Selected.DailyPayment.ToString();
                DamageFee.Text = Selected.DamageFee.ToString();
                Quantity.Text = Selected.DamageFee.ToString();
                PurchasedDate.Text = Selected.PurchasedDate.Date.ToString();
            }


        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            totPrice = Convert.ToInt64(SinglePrice.Text.ToString());
            quan = Convert.ToInt32(Quantity.Text);
            totPrice = quan * totPrice;
            if(edir.Capital >= totPrice)
            {
                item.Name = ItName.Text.Trim();
                item.PurchasedDate = Convert.ToDateTime(PurchasedDate.Text.ToString());
                item.DamageFee = Convert.ToDouble(DamageFee.Text);
                item.Quantity = Convert.ToInt32(quan);
                item.DailyPayment = Convert.ToDouble(DayPayment.Text);
                edir.Capital -= totPrice;
                _context.Items.Add(item);
                _context.SaveChanges();
                _context.Entry(edir).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                SucessMessage sm = new SucessMessage();
                sm.MessageText.Text = "Registered Successfully";
                sm.Show();
            }
            else
            {
                ErrorMessage er = new ErrorMessage();
                er.MessageText.Text = "No Balance For This Amount";
                er.Show();
            }
            




        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Item Selected = ((Item)ItemGrid.SelectedItem);

            if (Selected != null)
            {
                Selected.Name = ItName.Text.Trim();
                Selected.PurchasedDate = Convert.ToDateTime(PurchasedDate.Text);
                Selected.DamageFee = Convert.ToDouble(DamageFee.Text);
                _context.Entry(Selected).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
            SucessMessage sm = new SucessMessage();
            sm.MessageText.Text = "Updated Successfully";
            sm.Show();

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Item Selected = ((Item)ItemGrid.SelectedItem);

            if (Selected != null)
            {
                DeleteConfirmation Confirmation = new DeleteConfirmation();
                Confirmation.assigner(Selected);
                Confirmation.Show();
            }

        }
        public long GetItemId()
        {
            var Av = AvailableItems.SelectedItem;

            long i = 0;
            return i;
        }



        private void RentBtn_Click(object sender, RoutedEventArgs e)
        {
            long SelId = GetItemId();
            //Item OneItem = ((Item) _context.Items.FirstOrDefault(i => i.Id == SelId));
            var OneIte = AvailableItems.SelectedItem;
            Item OneItem = ((Item)OneIte);
            Rental rent = new Rental();
            int RequestedQuantity = Convert.ToInt32(RQuantity.Text);
            if (OneItem != null)
            {

                string ItemName = OneItem.Name.ToString();
                int Quantity = OneItem.Quantity;
                int Quant = Quantity - RequestedQuantity;
                if (Quant >= 0)
                {

                    rent.RentedDate = DateTime.Now.Date;
                    rent.ReturnDate = DateTime.Now.Date;
                    rent.ItemId = OneItem.Id;
                    rent.Quantity = RequestedQuantity;
                    rent.Returned = false;

                    OneItem.RentedQuantity += RequestedQuantity;
                    _context.Rentals.Add(rent);
                    _context.Entry(OneItem).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();
                    
                }
                else
                {
                    ErrorMessage er = new ErrorMessage();
                    er.MessageText.Text = "Quantity unavailable";
                    er.Show();
                }


            }
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {

            var OneIte = RetQuantity.SelectedItem;
            Rental OneRent = ((Rental)OneIte);
            Item OneItem = OneRent.Item;
            int RequestedQuantity = Convert.ToInt32(OneRent.Quantity);
            if (OneItem != null)
            {

                int Quantity = OneItem.RentedQuantity;
                Quantity -= RequestedQuantity;
                if (Quantity >= 0)
                {

                    OneItem.RentedQuantity = Quantity;
                    OneRent.ReturnDate = DateTime.Now.Date;
                    _context.Entry(OneRent).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();
                    OneRent.Returned = true;
                    TimeSpan timespan = OneRent.ReturnDate - OneRent.RentedDate;
                    double daysRented = timespan.TotalDays;
                    double RentMoney = 0;
                    if (daysRented == 0)
                    {
                        RentMoney = (daysRented) * OneItem.DailyPayment;
                        if (Damaged.IsChecked.GetValueOrDefault())
                        {
                            damageFee = 0;
                            int  type = DamageType.SelectedIndex ;
                            if(type == 0)
                            {
                                damageFee = OneItem.SmallDamageFee;
                                DamagedGood damagedGood = new DamagedGood();
                                damagedGood.ItemId = OneItem.Id;
                                damagedGood.RepairType = "Slight damage";
                                damagedGood.Quantity = RequestedQuantity;
                                damagedGood.Description = Description.Text.ToString();
                                _context.DamagedGoods.Add(damagedGood);
                                _context.SaveChanges();

                            }
                            else if(type == 1)
                            {
                                damageFee = OneItem.DamageFee;
                                DamagedGood damagedGood = new DamagedGood();
                                damagedGood.ItemId = OneItem.Id;
                                damagedGood.RepairType = "Moderate damage";
                                damagedGood.Quantity = RequestedQuantity;
                                damagedGood.Description = Description.Text.ToString();
                                _context.DamagedGoods.Add(damagedGood);
                                _context.SaveChanges();

                            }
                            else if(type == 2)
                            {
                                DamagedGood damagedGood = new DamagedGood();
                                damagedGood.ItemId = OneItem.Id;
                                damagedGood.RepairType = "strong damage";
                                OneItem.Quantity -= RequestedQuantity;
                                damagedGood.Quantity = RequestedQuantity;
                                damagedGood.IsRepaired = false;
                                damagedGood.Description = Description.Text.ToString();
                                _context.DamagedGoods.Add(damagedGood);
                                _context.SaveChanges();

                                _context.Entry(OneItem).State = System.Data.Entity.EntityState.Modified;
                                _context.SaveChanges();

                            }
                           
                            RentMoney += damageFee;
                        }
                       
                        

                    }
                    else
                    {
                        RentMoney = 0;
                    }
                    _context.Entry(OneRent).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();
                    _context.Entry(OneItem).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();
                    SucessMessage sm = new SucessMessage();
                    sm.MessageText.Text = "Total Price: " + RentMoney;
                    sm.Show();


                }
                else
                {
                    ErrorMessage er = new ErrorMessage();
                    er.MessageText.Text = "Quantity unavailable";
                    er.Show();
                }
            }
        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            allitems = _context.Items.ToList();
            ItemGrid.ItemsSource = allitems;
        }

        private void Search_KeyUp(object sender, KeyEventArgs e)
        {

            List<Item> searched = new List<Item>();
            foreach (Item item in allitems)
            {
                if (item.Name.ToLower().Contains(Search.Text.ToString().ToLower()))
                {
                    searched.Add(item);
                }
            }
            ItemGrid.ItemsSource = searched;

        }

        private void RentedItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var OneIte = RentedItems.SelectedItem;
            Item OneItem = ((Item)OneIte);
            Rental r = _context.Rentals.FirstOrDefault(f => f.ItemId == OneItem.Id);
            List<Rental> dates = new List<Rental>();

            if (OneItem != null)
            {
                rents = _context.Rentals.Where(g => g.ItemId == OneItem.Id && g.Returned == false).ToList();
                RentedDates.ItemsSource = rents;

            }
        }


        private void Damaged_Checked(object sender, RoutedEventArgs e)
        {
            DamageType.IsEnabled = true;
            Description.IsEnabled = true;

        }

        private void Damaged_Unchecked(object sender, RoutedEventArgs e)
        {
            DamageType.IsEnabled = false;
            Description.IsEnabled = false;

        }


        private void RentedDates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var OneDate = RentedDates.SelectedItem;
            Rental Date = ((Rental)OneDate);
            DateTime ReDate = Date.RentedDate;
            if (Date != null)
            {
                rentals  = _context.Rentals.Where(r => r.RentedDate == ReDate && r.Returned == false).ToList();
                RetQuantity.ItemsSource = rentals;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DamagedGood Selected = ((DamagedGood)damagedGrid.SelectedItem);
            Selected.IsRepaired = true;
            _context.Entry(Selected).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var grid = sender as DataGrid;
            grid.ItemsSource = _context.DamagedGoods.ToList();
        }
    }
}