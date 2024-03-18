using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using practice.Database;
using practice.Models;

using System;
using System.Linq;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace practice.Forms
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        private PracticeContext db;

        public Autorization()
        {
            db = new PracticeContext();
            InitializeComponent();
        }

        // обводка кнопки авторизации
        private void brdAuth_MouseEnter(object sender, MouseEventArgs e)
        {
            brdAuth.BorderBrush = new SolidColorBrush(Color.FromRgb(126, 180, 234));
        }

        private void brdAuth_MouseLeave(object sender, MouseEventArgs e)
        {
            brdAuth.BorderBrush = new SolidColorBrush(Colors.Black);
        }

        // текст кнопки авторизации
        private void btnAuth_MouseEnter(object sender, MouseEventArgs e)
        {
            btnAuth.Foreground = new SolidColorBrush(Color.FromRgb(126, 180, 234));
        }

        private void btnAuth_MouseLeave(object sender, MouseEventArgs e)
        {
            btnAuth.Foreground = new SolidColorBrush(Colors.Black);
        }

        // авторизация
        private int count = 1;

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            if (count == 3)
            {
                count = 0;
                txtID.IsEnabled = false;
                password.IsEnabled = false;
                brdAuth.Visibility = Visibility.Hidden;

                MessageBox.Show("Слишком много запросов, повторите попытку через 10 секнуд", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                System.Timers.Timer timer = new System.Timers.Timer(10000);
                timer.Elapsed += Timer_Elapsed;
                timer.AutoReset = false;
                timer.Enabled = true;
                return;
            }

            Captcha captcha = new Captcha();
            captcha.ShowDialog();

            User user = SignUp();
            if (user == null)
            {
                count++;
                MessageBox.Show("Неверно введены ID или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            


            if (captcha.DialogResult == true)
            {
                Window windowToOpen;
                switch (user.Role.Name)
                {
                    case "Организатор":
                        {
                            windowToOpen = new Organizator(user);
                            break;
                        }
                    case "Модератор":
                        {
                            windowToOpen = new Moderator(user);
                            break;
                        }
                    case "Жюри":
                        {
                            windowToOpen = new Jury(user);
                            break;
                        }
                    default:
                        {
                            windowToOpen = new MainWindow(user);
                            break;
                        }
                }
                windowToOpen.Show();

                foreach (Window w in App.Current.Windows)
                {
                    if (w != windowToOpen)
                    {
                        w.Close();
                    }
                }
            }
            
        }

        // проверка на ввод чисел в поле ввода id
        private void txtID_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        // метод авторизации
        private User SignUp()
        {
            if (txtID.Text.IsNullOrEmpty() || password.Password.IsNullOrEmpty())
            {
                MessageBox.Show("Поля для авторизации пустые", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }

            User user = db.Users.Include(u => u.Role).Where(p => p.Id == Convert.ToInt32(txtID.Text) && p.Password == password.Password).FirstOrDefault();
            return user;
        }

        // таймер для блокировки авторизации при неверной каптче
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                txtID.IsEnabled = true;
                password.IsEnabled = true;
                brdAuth.Visibility = Visibility.Visible;
            });
        }
    }
}