using practice.Database;
using practice.Models;

using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace practice.Forms
{
    /// <summary>
    /// Логика взаимодействия для Moderator.xaml
    /// </summary>
    public partial class Moderator : Window
    {
        private PracticeContext db;
        private List<User> users = new();
        public User User { get; set; }

        public Moderator(User user)
        {
            db = new PracticeContext();
            User = user;
            InitializeComponent();
            users = db.Users.Where(x => x.RoleId == 4).ToList();
            IC.ItemsSource = users;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindow autorization = new ();
            autorization.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile(User);
            profile.ShowDialog();
        }
    }
}