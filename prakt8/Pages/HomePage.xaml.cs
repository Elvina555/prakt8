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
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private List<Patient> allPatients = new List<Patient>();

        private Patient selectedPatient = new Patient();
        public HomePage()
        {
            InitializeComponent();
            LoadDoctorInfo();
            LoadPatients();
            Loaded += HomePage_Loaded;
        }

        private void HomePage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDoctorInfo();
            LoadPatients();
        }


        private void LoadDoctorInfo()
        {
            DoctorInfoText.Text = $"доктор: {MainWindow.CurrentDoctor.LastName} {MainWindow.CurrentDoctor.FirstName} {MainWindow.CurrentDoctor.MiddleName}";
        }

        private void LoadPatients()
        {
            allPatients = new List<Patient>();
            var files = System.IO.Directory.GetFiles(System.IO.Directory.GetCurrentDirectory(), "P_*.json");

            foreach (var file in files)
            {
                try
                {
                    string json = System.IO.File.ReadAllText(file);
                    Patient patient = System.Text.Json.JsonSerializer.Deserialize<Patient>(json);
                    if (patient != null)
                        allPatients.Add(patient);
                }
                catch { }
            }

            PatientsListView.ItemsSource = null;
            PatientsListView.ItemsSource = allPatients;
            StatusText.Text = $"Всего пациентов: {allPatients.Count}";
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.CurrentDoctor = new Doctor();
            NavigationService.Navigate(new LoginPage());
        }

        private void CreatePatientButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreatePatient());
        }

        private void StartAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPatient == null || selectedPatient.Id == 0)
            {
                MessageBox.Show("Выберите пациента из списка");
                return;
            }
            NavigationService.Navigate(new Reception(selectedPatient));
        }

        private void EditPatientButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPatient == null || selectedPatient.Id == 0)
            {
                MessageBox.Show("Выберите пациента из списка");
                return;
            }
            NavigationService.Navigate(new Edit(selectedPatient));
        }

        private void PatientsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedPatient = PatientsListView.SelectedItem as Patient;
        }

        private void DeletePatientButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

