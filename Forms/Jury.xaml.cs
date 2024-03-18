using practice.Database;
using practice.Models;

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace practice.Forms
{
    /// <summary>
    /// Логика взаимодействия для Jury.xaml
    /// </summary>
    public partial class Jury : Window
    {
        private PracticeContext db;
        private List<Activity> activities = new();
        public User User { get; set; }

        public Jury()
        {
            db = new PracticeContext();
            InitializeComponent();
            activities = db.Activites.ToList();
            IC.ItemsSource = activities;
        }
        public Jury(User user)
        {
            db = new PracticeContext();
            InitializeComponent();
            User = user;
            activities = db.Activites.ToList();
            IC.ItemsSource = activities;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow autorization = new ();
            autorization.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile(User);
            profile.ShowDialog();
        }
    }
}