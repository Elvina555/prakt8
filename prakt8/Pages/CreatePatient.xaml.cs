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
    /// Логика взаимодействия для CreatePatient.xaml
    /// </summary>
    public partial class CreatePatient : Page
    {
        private Patient newPatient = new Patient();
        public CreatePatient()
        {
            InitializeComponent();
            DataContext = newPatient;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(newPatient.LastName) || string.IsNullOrEmpty(newPatient.FirstName))
            {
                MessageBox.Show("Заполните фамилию и имя");
                return;
            }

            newPatient.Id = newPatient.GeneratePatientId();
            newPatient.DoctorId = MainWindow.CurrentDoctor.Id;
            newPatient.SaveToFile();

            MessageBox.Show($"Пациент создан! ID: {newPatient.Id}");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
