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
    public class Patient : INotifyPropertyChanged
    {
        public List<Priem> AppointmentStories { get; set; } = new List<Priem>();
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

        private DateTime _birthDate = DateTime.Now;
        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                if (_birthDate != value)
                {
                    _birthDate = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime _lastAppointment = DateTime.Now;
        public DateTime LastAppointment
        {
            get => _lastAppointment;
            set
            {
                if (_lastAppointment != value)
                {
                    _lastAppointment = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _doctorId = 0;
        public int DoctorId
        {
            get => _doctorId;
            set
            {
                if (_doctorId != value)
                {
                    _doctorId = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _diagnos = "";
        public string Diagnosis
        {
            get => _diagnos;
            set
            {
                if (_diagnos != value)
                {
                    _diagnos = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _recommend = "";
        public string Recommendations
        {
            get => _recommend;
            set
            {
                if (_recommend != value)
                {
                    _recommend = value;
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

        public int GeneratePatientId()
        {
            Random rnd = new Random();
            int id;
            do
            {
                id = rnd.Next(1000000, 9999999);
            } while (File.Exists($"P_{id}.json"));

            return id;
        }

        public void SaveToFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(this, options);
            File.WriteAllText($"P_{Id}.json", json);
        }

        public Patient LoadFromFile(int id)
        {
            string path = $"P_{id}.json";
            if (File.Exists(path))
            {
                try
                {
                    string json = File.ReadAllText(path);
                    return JsonSerializer.Deserialize<Patient>(json);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке пациента: {ex.Message}");
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
