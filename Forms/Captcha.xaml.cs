using ReCaptcha.Desktop.WPF.Client;
using ReCaptcha.Desktop.WPF.Client.Interfaces;
using ReCaptcha.Desktop.WPF.Configuration;

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace practice.Forms
{
    public partial class Captcha : Window
    {
        public Captcha()
        {
            InitializeComponent();
            MyCaptcha.CreateCaptcha(EasyCaptcha.Wpf.Captcha.LetterOption.Alphanumeric, 4);
        }

        // каптча
        private async Task<string> InitRecaptcha()
        {
            ReCaptchaConfig config = "6LeQelkpAAAAAJXVyaw3nBW7YIT61LGFPqU_wqlw".AsReCaptchaConfig("HOST_NAME", "en", "Token recieved: %token%", "Token recieved and sent to application.");
            WindowConfig uiConfig = new("WINDOW_TITLE"); // WPF
            IReCaptchaClient reCaptcha = new ReCaptchaClient(config, uiConfig);
            CancellationTokenSource cts = new(TimeSpan.FromMinutes(1));
            return await reCaptcha.VerifyAsync(cts.Token);
        }

        // обводка кнопки каптчи
        private void brdCapt_MouseEnter(object sender, MouseEventArgs e)
        {
            brdCapt.BorderBrush = new SolidColorBrush(Color.FromRgb(126, 180, 234));
        }

        private void brdCapt_MouseLeave(object sender, MouseEventArgs e)
        {
            brdCapt.BorderBrush = new SolidColorBrush(Colors.Black);
        }

        // текст кнопки каптчи
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            btnCapt.Foreground = new SolidColorBrush(Color.FromRgb(126, 180, 234));
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            btnCapt.Foreground = new SolidColorBrush(Colors.Black);
        }

        private int count = 0;

        // метод кнопки каптчи
        private void btnCapt_Click(object sender, RoutedEventArgs e)
        {
            if (count >= 3)
            {
                count = 0;
                txtCapt.IsEnabled = false;
                btnCapt.Visibility = Visibility.Hidden;
                cptUpdate.Visibility = Visibility.Hidden;

                MessageBox.Show("Слишком много запросов, повторите попытку через 10 секнуд", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                System.Timers.Timer timer = new System.Timers.Timer(10000);
                timer.Elapsed += Timer_Elapsed;
                timer.AutoReset = false;
                timer.Enabled = true;
                return;
            }

            var answer = MyCaptcha.CaptchaText;
            if (txtCapt.Text == answer)
            {
                this.Close();
            }

            if (txtCapt.Text != answer)
            {
                MessageBox.Show("Неверно введена каптча!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                MyCaptcha.CreateCaptcha(EasyCaptcha.Wpf.Captcha.LetterOption.Alphanumeric, 4);
                count++;
                return;
            }
        }

        // нажатие на кнопку каптчи
        private void cptUpdate_Click(object sender, RoutedEventArgs e)
        {
            MyCaptcha.CreateCaptcha(EasyCaptcha.Wpf.Captcha.LetterOption.Alphanumeric, 4);
        }

        // таймер для блокировки авторизации при неверной каптче
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                txtCapt.IsEnabled = false;
                btnCapt.Visibility = Visibility.Hidden;
                cptUpdate.Visibility = Visibility.Hidden;
            });
        }
    }
}