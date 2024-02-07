using System;
using EasyCaptcha.Wpf;
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

using ReCaptcha.Desktop.WPF.Client;
using ReCaptcha.Desktop.WPF.Client.Interfaces;
using ReCaptcha.Desktop.WPF.Configuration;
using ReCaptcha.Desktop.WPF.UI;
using System.Threading;

namespace practice.Forms
{
    public partial class Captcha : Window
    {
        public Captcha()
        {
            InitializeComponent();
            MyCaptcha.CreateCaptcha(EasyCaptcha.Wpf.Captcha.LetterOption.Alphanumeric, 4);         
        }

        private async Task<string> InitRecaptcha()
        {
            ReCaptchaConfig config = "6LeQelkpAAAAAJXVyaw3nBW7YIT61LGFPqU_wqlw".AsReCaptchaConfig("HOST_NAME", "en", "Token recieved: %token%", "Token recieved and sent to application.");


            WindowConfig uiConfig = new("WINDOW_TITLE"); // WPF
            IReCaptchaClient reCaptcha = new ReCaptchaClient(config, uiConfig);
            CancellationTokenSource cts = new(TimeSpan.FromMinutes(1));
            return await reCaptcha.VerifyAsync(cts.Token);
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            btnCapt.Foreground = new SolidColorBrush(Color.FromRgb(126, 180, 234));
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            btnCapt.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void brdCapt_MouseEnter(object sender, MouseEventArgs e)
        {
            brdCapt.BorderBrush = new SolidColorBrush(Color.FromRgb(126, 180, 234));
        }

        private void brdCapt_MouseLeave(object sender, MouseEventArgs e)
        {
            brdCapt.BorderBrush = new SolidColorBrush(Colors.Black);
        }

        private void btnCapt_Click(object sender, RoutedEventArgs e)
        {
            var answer = MyCaptcha.CaptchaText;
            if (txtCapt.Text == answer)
            {
                this.Close();
            }

            if (txtCapt.Text != answer)
            {
                MessageBox.Show("Неверно введена каптча!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                MyCaptcha.CreateCaptcha(EasyCaptcha.Wpf.Captcha.LetterOption.Alphanumeric, 4);
                return;
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void txtCapt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
        }

        private void cptUpdate_Click(object sender, RoutedEventArgs e)
        {
            MyCaptcha.CreateCaptcha(EasyCaptcha.Wpf.Captcha.LetterOption.Alphanumeric, 4);
        }
    }
}
