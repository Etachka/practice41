using practice.Database;
using practice.Models;

using System.Data.Common;
using System.Linq;
using System.Windows;

namespace practice.Forms
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public User User { get; set; }
        private PracticeContext db;

        public Profile(User user)
        {
            db = new PracticeContext();
            User = user;
            this.DataContext = this;
            InitializeComponent();
        }

        public string CountryName
        {
            get
            {
                var userCountry = db.Countries.FirstOrDefault(c => c.Id == User.CountryID);
                return userCountry != null ? userCountry.Name : "Неизвестная страна";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PasswordChange pc = new PasswordChange(User);
            pc.ShowDialog();
        }
    }
}