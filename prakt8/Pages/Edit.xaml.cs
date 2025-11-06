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
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Page
    {
        private Patient newPatient = new Patient();
        public Edit(Patient selectedPatient)
        {
            InitializeComponent();
            newPatient = selectedPatient;
            DataContext = newPatient;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(newPatient.LastName) || string.IsNullOrEmpty(newPatient.FirstName))
            {
                MessageBox.Show("Заполните фамилию и имя");
                return;
            }

            newPatient.SaveToFile();
            MessageBox.Show("Информация обновлена!");

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}

