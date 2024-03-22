using Microsoft.IdentityModel.Tokens;

using practice.Database;
using practice.Models;

using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace practice.Forms
{
    /// <summary>
    /// Логика взаимодействия для Participant.xaml
    /// </summary>
    public partial class Participant : Window
    {
        private PracticeContext db;
        private User user = new User();

        public Participant()
        {
            db = new PracticeContext();
            InitializeComponent();
        }

        private void pass_check_Click(object sender, RoutedEventArgs e)
        {
            if (pass_check.IsChecked == true)
            {
                passBoxTxt.Text = passBox.Password;
                passBoxTxt.Visibility = Visibility.Visible;
                passBox.Visibility = Visibility.Hidden;

                passBoxTxt2.Text = passBox2.Password;
                passBoxTxt2.Visibility = Visibility.Visible;
                passBox2.Visibility = Visibility.Hidden;
            }
            else
            {
                passBox.Password = passBoxTxt.Text;
                passBox.Visibility = Visibility.Visible;
                passBoxTxt.Visibility = Visibility.Hidden;

                passBox2.Password = passBoxTxt2.Text;
                passBox2.Visibility = Visibility.Visible;
                passBoxTxt2.Visibility = Visibility.Hidden;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0))
            { e.Handled = true; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            user.Surname = SurnameTxt.Text;
            user.Name = NameTxt.Text;
            user.Patronomic = PatronomicTxt.Text;
            user.Phone = PhoneTxt.Text;
            user.Email = EmailTxt.Text;
            user.RoleId = 4;
            if (pass_check.IsChecked == true)
            {
                user.Password = passBoxTxt.Text;
            }
            else
            {
                user.Password = passBox.Password;
            }

            if (Check())
            {
                db.Users.Add(user);
                db.SaveChanges();
                MessageBox.Show("Добавлено", "Отлично", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool Check()
        {
            if (SurnameTxt.Text.IsNullOrEmpty() ||
                NameTxt.Text.IsNullOrEmpty() ||
                PatronomicTxt.Text.IsNullOrEmpty() ||
                PhoneTxt.Text.IsNullOrEmpty() ||
                EmailTxt.Text.IsNullOrEmpty() ||
                passBox.Password.IsNullOrEmpty() ||
                passBox.Password.Length < 6 &&
                passBox.Password != @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]).+$" ||
                passBoxTxt.Text.Length < 6 &&
                passBoxTxt.Text != @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]).+$" ||
                passBox.Password != passBox2.Password ||
                passBoxTxt.Text != passBoxTxt2.Text ||
                PhoneTxt.Text.Contains("_")
                )
            {
                MessageBox.Show("Проверьте заполненность полей", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (db.Users.Any(x => x.Email == EmailTxt.Text))
            {
                MessageBox.Show("Пользователь с такой почтой уже существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            var email = EmailTxt.Text;
            if (IsValidEmail(email))
                return true;
            else
            {
                MessageBox.Show("Некорректно введена почта", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return Regex.IsMatch(email, pattern);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (GenderCB.SelectedIndex)
            {
                case 0:
                    {
                        user.Gender = "мужской";
                        break;
                    }
                case 1:
                    {
                        user.Gender = "женский";
                        break;
                    }
            }
        }
    }
}