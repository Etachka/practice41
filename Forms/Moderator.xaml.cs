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


        public Moderator()
        {
            db = new PracticeContext();
            InitializeComponent();
            users = db.Users.Where(x => x.RoleId == 4).ToList();
            IC.ItemsSource = users;
        }
    }
}