using Microsoft.IdentityModel.Tokens;

using practice.Database;
using practice.Models;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;

using Activity = practice.Models.Activity;

namespace practice.Forms
{
    /// <summary>
    /// Логика взаимодействия для ActivitesAdd.xaml
    /// </summary>
    public partial class ActivitesAdd : Window
    {
        private PracticeContext db;
        private List<User> users;
        private List<Activity> activities;
        private Activity activity = new Activity();

        public ActivitesAdd()
        {
            db = new PracticeContext();
            InitializeComponent();
            CBIvent.ItemsSource = GetIvents();
            CBModer.ItemsSource = GetModers();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            activity.Name = TBName.Text;
            if (!(TBDur.Text.IsNullOrEmpty()) || !(DP.Text.IsNullOrEmpty()))
            {
                activity.DayNumber = Int32.Parse(TBDur.Text);
                activity.TimeBegin = DateTime.Parse(DP.Text);
            }
            activity.ModeratorId = CBModer.SelectedIndex;
            activity.IventId = CBIvent.SelectedIndex;
            if (Check())
            {
                db.Activites.Add(activity);
                db.SaveChanges();
                MessageBox.Show("Добавлено", "Отлично", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0))
            { e.Handled = true; }
        }

        public ObservableCollection<Ivent> GetIvents()
        {
            return new ObservableCollection<Ivent>(db.Ivents.ToList<Ivent>());
        }

        public ObservableCollection<User> GetModers()
        {
            return new ObservableCollection<User>(db.Users.Where(u => u.RoleId == 2).ToList<User>());
        }

        private bool Check()
        {
            if (TBName.Text.IsNullOrEmpty() ||
                CBIvent.Text.IsNullOrEmpty() ||
                CBModer.Text.IsNullOrEmpty()
                )
            {
                MessageBox.Show("Проверьте заполненность полей", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (db.Ivents.Any(i => i.Name == TBName.Text))
            {
                MessageBox.Show("Такая активность уже существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void DP_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = true;
        }

        private void TBDur_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            { e.Handled = true; }
        }
    }
}