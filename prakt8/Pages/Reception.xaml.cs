using prakt8.Models;
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

namespace prakt8.Pages
{
    /// <summary>
    /// Логика взаимодействия для Reception.xaml
    /// </summary>
    public partial class Reception : Page
    {
        public Patient currentPatient = new Patient();
        public Reception(Patient selectedPatient)
        {
            InitializeComponent();
            currentPatient = selectedPatient;
            DataContext = currentPatient;
            LoadPatientInfo();
            Loaded += Reception_Loaded;
        }

       private void Reception_Loaded(object sender, RoutedEventArgs e)
        {
            LoadPatientInfo();
            LoadAppointmentHistory();
        }

        private void LoadPatientInfo()
        {
            PatientInfoText.Text = $"{currentPatient.LastName} {currentPatient.FirstName} {currentPatient.MiddleName} (ID: {currentPatient.Id})";
        }

        private void LoadAppointmentHistory()
        {
            AppointmentHistoryListView.ItemsSource = currentPatient.AppointmentStories
                .OrderByDescending(a => a.Date)
                .ToList();
        }

        private void SaveAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(currentPatient.Diagnosis))
            {
                MessageBox.Show("Введите диагноз");
                return;
            }

            var newAppointment = new Priem
            {
                Date = DateTime.Now,
                DoctorId = MainWindow.CurrentDoctor.Id,
                Diagnos = currentPatient.Diagnosis,
                Recommend = currentPatient.Recommendations
            };

            currentPatient.AppointmentStories.Add(newAppointment);
            currentPatient.SaveToFile();

            MessageBox.Show("Прием сохранен!");
            LoadAppointmentHistory();

            currentPatient.Diagnosis = "";
            currentPatient.Recommendations = "";
        }

        private void EditPatientButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Edit(currentPatient));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}

