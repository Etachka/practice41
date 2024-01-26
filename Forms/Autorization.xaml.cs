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
using System.Windows.Shapes;

namespace practice.Forms
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        public Autorization()
        {
            InitializeComponent();
        }

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void brdAuth_MouseEnter(object sender, MouseEventArgs e)
        {
            brdAuth.BorderBrush = new SolidColorBrush(Color.FromRgb(126, 180, 234));

        }

        private void brdAuth_MouseLeave(object sender, MouseEventArgs e)
        {
            brdAuth.BorderBrush = new SolidColorBrush(Colors.Black);
        }

        private void btnAuth_MouseEnter(object sender, MouseEventArgs e)
        {
            btnAuth.Foreground = new SolidColorBrush(Color.FromRgb(126, 180, 234));

        }

        private void btnAuth_MouseLeave(object sender, MouseEventArgs e)
        {
            btnAuth.Foreground = new SolidColorBrush(Colors.Black);

        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            Captcha captcha = new Captcha();
            captcha.ShowDialog();
            switch (password.Text)
            {
                case "1":
                    Organizator organizator = new Organizator();
                    organizator.Show();
                    this.Close();
                    break;
                case "2":
                    Jury jury = new Jury();
                    jury.Show();
                    this.Close();
                    break;
                case "3":
                    Moderator mod = new Moderator();
                    mod.Show();
                    this.Close();
                    break;
                case "4":
                    ParticipantWindow participant = new ParticipantWindow();
                    participant.Show();
                    this.Close();
                    break;
            }
        }


        private void password_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void password_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
