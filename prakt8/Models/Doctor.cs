using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace prakt8.Models
{
    public class Doctor : INotifyPropertyChanged
    {
        private string _lastName = "";
        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _firstName = "";
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _middleName = "";
        public string MiddleName
        {
            get => _middleName;
            set
            {
                if (_middleName != value)
                {
                    _middleName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _specialty = "";
        public string Specialty
        {
            get => _specialty;
            set
            {
                if (_specialty != value)
                {
                    _specialty = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _password = "";
        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _id = 0;
        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }

        public int GenerateDoctorId()
        {
            Random rnd = new Random();
            int id;
            do
            {
                id = rnd.Next(1000000, 9999999);
            } while (File.Exists($"D_{id}.json"));

            return id;
        }

        public void SaveToFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(this, options);
            File.WriteAllText($"D_{Id}.json", json);
        }

        public Doctor LoadFromFile(int id)
        {
            string path = $"D_{id}.json";
            if (File.Exists(path))
            {
                try
                {
                    string json = File.ReadAllText(path);
                    return JsonSerializer.Deserialize<Doctor>(json);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке врача: {ex.Message}");
                }
            }
            return null;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
