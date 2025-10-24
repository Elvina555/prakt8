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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(IdTextBox.Text) || string.IsNullOrEmpty(PasswordBox.Text))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            if (int.TryParse(IdTextBox.Text, out int doctorId))
            {
                Doctor doctorLoader = new Doctor();
                Doctor loadedDoctor = doctorLoader.LoadFromFile(doctorId);

                if (loadedDoctor != null && loadedDoctor.Password == PasswordBox.Text)
                {
                    MainWindow.CurrentDoctor = loadedDoctor;
                    NavigationService.Navigate(new HomePage());
                }
                else
                {
                    MessageBox.Show("Неверный ID или пароль");
                }
            }
            else
            {
                MessageBox.Show("ID должен быть числом");
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registrasion());
        }
    }
    
}
