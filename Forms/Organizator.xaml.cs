using practice.Models;

using System;
using System.Windows;

namespace practice.Forms
{
    /// <summary>
    /// Логика взаимодействия для Organizator.xaml
    /// </summary>
    ///
    public partial class Organizator : Window
    {
        public User User { get; set; }

        public Organizator(User user)
        {
            this.DataContext = this;
            User = user;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            JuryModeratorRegistration registration = new JuryModeratorRegistration();
            registration.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile(User);
            profile.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Participant participant = new Participant();
            participant.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ActivitesAdd activitesAdd = new ActivitesAdd();
            activitesAdd.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindow autorization = new ();
            autorization.Show();
            this.Close();
        }

        public string MrMrs
        {
            get
            {
                if (User.Gender.Equals("женский"))
                {
                    return "Mrs.";
                }
                return "Mr.";
            }
        }

        public string WelcomDatePart
        {
            get
            {
                if (DateTime.Now.TimeOfDay > new TimeSpan(18, 0, 0))
                {
                    return "Добрый вечер";
                }
                if (DateTime.Now.TimeOfDay > new TimeSpan(11, 0, 0))
                {
                    return "Добрый день";
                }
                if (DateTime.Now.TimeOfDay > new TimeSpan(5, 0, 0))
                {
                    return "Доброе утро";
                }
                else
                {
                    return "Доброй ночи";
                }
            }
        }
    }
}