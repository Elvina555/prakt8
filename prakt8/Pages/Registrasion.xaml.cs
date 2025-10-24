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
    /// Логика взаимодействия для Registrasion.xaml
    /// </summary>
    public partial class Registrasion : Page
    {
        private Doctor newDoctor = new Doctor();
        public Registrasion()
        {
            InitializeComponent();
            DataContext = newDoctor;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(newDoctor.LastName) ||
               string.IsNullOrEmpty(newDoctor.FirstName) ||
               string.IsNullOrEmpty(newDoctor.Specialty) ||
               string.IsNullOrEmpty(PasswordTextBox.Text))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            if (PasswordTextBox.Text != ConfirmPasswordTextBox.Text)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }
            newDoctor.Password = PasswordTextBox.Text;
            newDoctor.Id = newDoctor.GenerateDoctorId();
            newDoctor.SaveToFile();

            MessageBox.Show($"Успешно! ID: {newDoctor.Id}");
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
