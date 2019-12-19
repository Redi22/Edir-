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
        Item item = new Item();
        List<Rental> rents;
        List<Rental> rentals;
        List<Item> allitems;
        public itemRegistrationForm()
        {
            InitializeComponent();

            _context = new EdirDbContext();
            allitems = _context.Items.ToList();
            ItemGrid.ItemsSource = allitems;
            AvailableItems_Loaded();
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

            item.Name = ItName.Text.Trim();
            item.PurchasedDate = Convert.ToDateTime(PurchasedDate.Text.ToString());
            item.DamageFee = Convert.ToDouble(DamageFee.Text);

            item.Quantity = Convert.ToInt32(Quantity.Text);
            item.DailyPayment = Convert.ToDouble(DayPayment.Text);

            _context.Items.Add(item);
            _context.SaveChanges();
            SucessMessage sm = new SucessMessage();
            sm.MessageText.Text = "Registered Successfully";
            sm.Show();




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
                    OneRent.Returned = true;
                    TimeSpan timespan = OneRent.ReturnDate - OneRent.RentedDate;
                    double daysRented = timespan.TotalDays;
                    double RentMoney = 0;
                    if (daysRented != 0)
                    {
                        RentMoney = daysRented * OneItem.DailyPayment;

                    }
                    else if(timespan.Hours > 2)
                    {
                        RentMoney = OneItem.DailyPayment;
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
        }

        private void Damaged_Unchecked(object sender, RoutedEventArgs e)
        {
            DamageType.IsEnabled = false;

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

    }
}