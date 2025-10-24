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
        private Patient newPatient = new Patient();
        public Reception(Patient selectedPatient)
        {
            InitializeComponent();
            newPatient = selectedPatient;
            DataContext = newPatient;
            LoadPatientInfo();
        }

        private void LoadPatientInfo()
        {
            PatientInfoText.Text = $"Пациент: {newPatient.LastName} {newPatient.FirstName} {newPatient.MiddleName}";
        }

        private void SaveAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(newPatient.Diagnosis))
            {
                MessageBox.Show("Введите диагноз");
                return;
            }

            newPatient.LastAppointment = DateTime.Now;
            newPatient.DoctorId = MainWindow.CurrentDoctor.Id;

            newPatient.SaveToFile();

            MessageBox.Show("Прием сохранен!");
        }

        private void EditPatientButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Edit(newPatient));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}

