using practice.Database;
using practice.Models;

using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace practice.Forms
{
    /// <summary>
    /// Логика взаимодействия для PasswordChange.xaml
    /// </summary>
    public partial class PasswordChange : Window
    {
        public User User { get; set; }
        private PracticeContext db;

        public PasswordChange(User user)
        {
            db = new PracticeContext();
            User = user;
            this.DataContext = this;
            InitializeComponent();
        }

        // обводка кнопки авторизации
        private void brdAuth_MouseEnter(object sender, MouseEventArgs e)
        {
            brdChange.BorderBrush = new SolidColorBrush(Color.FromRgb(126, 180, 234));
        }

        private void brdAuth_MouseLeave(object sender, MouseEventArgs e)
        {
            brdChange.BorderBrush = new SolidColorBrush(Colors.Black);
        }

        // текст кнопки авторизации
        private void btnAuth_MouseEnter(object sender, MouseEventArgs e)
        {
            btnChange.Foreground = new SolidColorBrush(Color.FromRgb(126, 180, 234));
        }

        private void btnAuth_MouseLeave(object sender, MouseEventArgs e)
        {
            btnChange.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            string currentPassword = nowPass.Text;
            string newPassword = newPass.Text;

            if (string.IsNullOrEmpty(currentPassword))
            {
                MessageBox.Show("Пожалуйста, введите текущий пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Пожалуйста, введите новый пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (ValidateCurrentPassword(currentPassword))
            {
                ChangePassword(newPassword);
                MessageBox.Show("Пароль успешно изменен", "Успех", MessageBoxButton.OK, MessageBoxImage.Warning);
                this.Close();
            }
            else
            {
                MessageBox.Show("Текущий пароль введен неверно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidateCurrentPassword(string currentPassword)
        {
            var user = db.Users.FirstOrDefault(u => u.Password == currentPassword);
            return user != null;
        }

        private void ChangePassword(string newPassword)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == User.Id);

            if (user != null)
            {
                user.Password = newPassword;
                db.SaveChanges();
            }
        }
    }
}