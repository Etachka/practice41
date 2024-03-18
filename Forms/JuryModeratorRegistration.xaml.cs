using Microsoft.IdentityModel.Tokens;

using practice.Database;
using practice.Models;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace practice.Forms
{
    /// <summary>
    /// Логика взаимодействия для JuryModeratorRegistration.xaml
    /// </summary>
    public partial class JuryModeratorRegistration : Window
    {
        private PracticeContext db;
        private List<Role> roles = new();
        private List<string> strRoles;
        private User user = new User();

        public JuryModeratorRegistration()
        {
            db = new PracticeContext();
            roles = db.Roles.Where(x => x.Name == "Жюри" || x.Name == "Модератор").ToList();
            strRoles = new List<string>();
            foreach (Role role in roles)
            {
                strRoles.Add(role.Name);
            }
            InitializeComponent();
            RoleCB.ItemsSource = strRoles;
            IventCB.ItemsSource = GetIvents();
        }

        public ObservableCollection<Ivent> GetIvents()
        {
            return new ObservableCollection<Ivent>(
                    db.Ivents.ToList<Ivent>());
        }

        public ObservableCollection<Activity> GetActivites()
        {
            return new ObservableCollection<Activity>(
                    db.Activites.Where(p => p.IventId == IventCB.SelectedIndex + 1).ToList<Activity>());
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
                this.Close();
            }
            else
            {
                MessageBox.Show("Проверьте заполненность полей", "Сообщение");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RoleCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (RoleCB.SelectedIndex)
            {
                case 0:
                    {
                        user.RoleId = RoleCB.SelectedIndex + 1;
                        break;
                    }
                case 1:
                    {
                        user.RoleId = RoleCB.SelectedIndex + 1;
                        break;
                    }
                case 2:
                    {
                        user.RoleId = RoleCB.SelectedIndex + 1;
                        break;
                    }
                case 3:
                    {
                        user.RoleId = RoleCB.SelectedIndex + 1;

                        break;
                    }
            }
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
                return false;
            }
            return true;
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

        private void IventCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var activites = GetActivites();
            ActivityCB.ItemsSource = activites;
        }
    }
}