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
    /// Interaction logic for EventRegistrationForm.xaml
    /// </summary>
    public partial class EventRegistrationForm : UserControl
    {
        EdirEvent Eve = new EdirEvent();
        List<EdirEvent> allEvents;
        private EdirDbContext _context = null;
        public EventRegistrationForm()
        {
            InitializeComponent();
            _context = new EdirDbContext();
            allEvents = _context.EdirEvents.ToList();
            EventGrid.ItemsSource = allEvents;

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Eve.Name = EventName.Text.Trim();
            Eve.Place = EventPlace.Text.Trim();
            Eve.Fin = Convert.ToDouble(EventFin.Text);
            Eve.date = Convert.ToDateTime(EventDate.Text);
            //Eve.time = Convert.ToDateTime(EventTime.Text);
            Eve.Description = Description.Text.Trim();
            
            _context.EdirEvents.Add(Eve);
            _context.SaveChanges();
            SucessMessage sm = new SucessMessage();
            sm.MessageText.Text = "Registered Successfully";
            sm.Show();



        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            EdirEvent Selected = ((EdirEvent)EventGrid.SelectedItem);

            if (Selected != null)
            {

                Selected.Name = EventName.Text.Trim();
                Selected.Place = EventPlace.Text.Trim();
                Selected.Fin = Convert.ToDouble(EventFin.Text);
                Selected.date = Convert.ToDateTime(EventDate.Text);
                Selected.Description = Description.Text.Trim();
                
                _context.Entry(Selected).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                SucessMessage sm = new SucessMessage();
                sm.MessageText.Text = "Updated Successfully";
                sm.Show();




            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            EdirEvent Selected = ((EdirEvent)EventGrid.SelectedItem);
            if (Selected != null)
            {
                DeleteConfirmation Confirmation = new DeleteConfirmation();
                Confirmation.assigner(Selected);
                Confirmation.Show();
            }
        }

       

        private void EventGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EdirEvent Selected = ((EdirEvent)EventGrid.SelectedItem);
            Details.IsEnabled = true;
            
            if (Selected != null)
            {
                EventName.Text = Selected.Name;
                EventPlace.Text = Selected.Place;
                EventDate.Text = Selected.date.ToString();
                EventTime.Text = Selected.date.ToShortTimeString();
                EventFin.Text = Selected.Fin.ToString();
                Description.Text = Selected.Description;

            }

        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            EdirEvent Selected = ((EdirEvent)EventGrid.SelectedItem);

            if (Selected != null)
            {
                Attendace pre = _context.Attendances.FirstOrDefault(p => p.EventId == Selected.Id);
                if(pre == null)
                {
                    AttendanceForm at = new AttendanceForm();
                    at.GridInitializer(EventGrid);
                    AttendanceForm.Children.Clear();
                    AttendanceForm.Children.Add(at);
                }
                else
                {
                    ErrorMessage er = new ErrorMessage();
                    er.MessageText.Text = "Attendance already registered";
                    er.Show();
                }
                
            }
        }

        private void Search_KeyUp(object sender, KeyEventArgs e)
        {
            List<EdirEvent> searched = new List<EdirEvent>();
            foreach (EdirEvent edirEvent in allEvents)
            {
                if (edirEvent.Name.ToLower().Contains(Search.Text.ToString().ToLower()))
                {
                    searched.Add(edirEvent);
                }
            }
            EventGrid.ItemsSource = searched;

        }


        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            allEvents = _context.EdirEvents.ToList();
            EventGrid.ItemsSource = allEvents;
        }
    }
}
