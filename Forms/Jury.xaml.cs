using practice.Database;
using practice.Models;

using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace practice.Forms
{
    /// <summary>
    /// Логика взаимодействия для Jury.xaml
    /// </summary>
    public partial class Jury : Window
    {
        private PracticeContext db;
        private List<Activity> activities = new();

        public Jury()
        {
            db = new PracticeContext();
            InitializeComponent();
            activities = db.Activites.ToList();
            IC.ItemsSource = activities;
        }
    }
}