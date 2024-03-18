using practice.Database;
using practice.Forms;
using practice.Models;

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace practice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PracticeContext db;
        private List<string> strings = new List<string>() { "A-Я", "Я-А", "Сначала старые", "Сначала новые" };
        private List<Ivent> ivents = new List<Ivent>();
        public User User { get; set; }

        public MainWindow()
        {
            db = new PracticeContext();
            InitializeComponent();
            ivents = db.Ivents.ToList();
            IC.ItemsSource = ivents;

            SortNameIvents.ItemsSource = strings;
        }
        public MainWindow(User user)
        {
            db = new PracticeContext();
            InitializeComponent();
            ivents = db.Ivents.ToList();
            IC.ItemsSource = ivents;
            User = user;
            SortNameIvents.ItemsSource = strings;
            if (user != null)
            {
                mainBtnAuth.Visibility = Visibility.Collapsed;
                mainBrdAuth.Visibility = Visibility.Collapsed;
                mainBrdProf.Visibility = Visibility.Visible;
                mainBtnProf.Visibility = Visibility.Visible;
                mainBtnExit.Visibility = Visibility.Visible;
                mainBrdExit.Visibility = Visibility.Visible;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Autorization autorization = new Autorization();
            autorization.ShowDialog();
            this.Close();
        }

        private void mainBtnAuth_MouseEnter(object sender, MouseEventArgs e)
        {
            mainBtnAuth.Foreground = new SolidColorBrush(Color.FromRgb(126, 180, 234));
        }

        private void mainBtnAuth_MouseLeave(object sender, MouseEventArgs e)
        {
            mainBtnAuth.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void mainBrdAuth_MouseEnter(object sender, MouseEventArgs e)
        {
            mainBrdAuth.BorderBrush = new SolidColorBrush(Color.FromRgb(126, 180, 234));
        }

        private void mainBrdAuth_MouseLeave(object sender, MouseEventArgs e)
        {
            mainBrdAuth.BorderBrush = new SolidColorBrush(Colors.Black);
        }

        private void SortNameIvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (SortNameIvents.SelectedItem)
            {
                case "A-Я":
                    {
                        ivents = db.Ivents.OrderBy(p => p.Name).ToList();
                        IC.ItemsSource = ivents;
                        break;
                    }
                case "Я-А":
                    {
                        ivents = db.Ivents.OrderByDescending(p => p.Name).ToList();
                        IC.ItemsSource = ivents;
                        break;
                    }
                case "Сначала старые":
                    {
                        ivents = db.Ivents.OrderBy(p => p.DateBegin).ToList();
                        IC.ItemsSource = ivents;
                        break;
                    }
                case "Сначала новые":
                    {
                        ivents = db.Ivents.OrderByDescending(p => p.DateBegin).ToList();
                        IC.ItemsSource = ivents;
                        break;
                    }
            }
        }

        private void mainBtnProf_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile(User);
            profile.ShowDialog();
        }

        private void mainBtnExit_Click(object sender, RoutedEventArgs e)
        {
            Autorization autorization = new Autorization();
            autorization.Show();
            this.Close();
        }
    }
}