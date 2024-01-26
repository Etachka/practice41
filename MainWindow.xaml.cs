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
using practice.Parser;
using practice.Forms;
using practice.Database;

namespace practice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Pars.ParseCity();
            Pars.ParseCountry();
            Pars.ParseDirection();
            Pars.ParseAction();
            Pars.ParseEvent();
            Pars.ParseActivitiesInformationSecurity();
            Pars.ParseJury();
            Pars.ParseParticipant();
            Pars.ParseActionJury();
            Pars.ParseModerator();
            Pars.ParseOrganizers();
            using(var con = new PracticeContext())
            {
                IC.ItemsSource = con.Ivent.ToList();
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
    }
}
