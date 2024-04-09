using practice.Database;
using practice.Models;

using System;
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
            var activities = db.Activites.ToList();
            IC.ItemsSource = activities;
        }

        public Jury(User user)
        {
            db = new PracticeContext();
            InitializeComponent();
            User = user;
            activities = db.Activites.ToList();

            var moderators = db.Users.ToDictionary(u => u.Id);

            foreach (var activity in activities)
            {
                if (moderators.ContainsKey(activity.ModeratorId))
                {
                    activity.Moderator = moderators[activity.ModeratorId];
                }
            }
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

        //public string HelloModerator()
        //{
        //    string ModeratorName = "";
        //    var moderator = db.Users.FirstOrDefault(u => u.Id == activity.ModeratorId);

        //    return ModeratorName = (moderator != null) ? $"{moderator.Surname} {moderator.Name} {moderator.Patronomic}" : "Unknown";
        //}

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            //if (TxtModN.Tag is int ModeratorID)
            //{
            //    // Здесь вы должны реализовать логику поиска пользователя по Id
            //    string userName = FindUserNameById(ModeratorID);

            //    // Устанавливаем имя пользователя как текст для TextBlock
            //    TxtModN.Text = userName;
            //}
        }

        private void TxtModN_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }
    }
}