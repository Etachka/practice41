using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using practice.Forms;
using practice.Database;
using practice.Models;

namespace practice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PracticeContext db;
        List<string> strings = new List<string>() { "A-Я", "Я-А", "По возрастанию", "По убыванию" };
        List<Ivent> ivents = new List<Ivent>();
        public MainWindow()
        {
            db = new PracticeContext();
            InitializeComponent();
            ivents = db.Ivents.ToList();
            IC.ItemsSource = ivents;


            SortNameIvents.ItemsSource = strings;
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
                case "По возрастанию":
                    {
                        ivents = db.Ivents.OrderBy(p => p.DateBegin).ToList();
                        IC.ItemsSource = ivents;
                        break;
                    }
                case "По убыванию":
                    {
                        ivents = db.Ivents.OrderByDescending(p => p.DateBegin).ToList();
                        IC.ItemsSource = ivents;
                        break;
                    }

            }

        }
    }
}
