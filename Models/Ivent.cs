using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace practice.Models
{
    public class Ivent : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateBegin { get; set; }

        public int AmountDays { get; set; }

        public string Photo { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public int? WinnerId { get; set; }
        public User? Winner { get; set; }

        public ObservableCollection<Activity> Activities { get; set; }


        [NotMapped]
        public int Hour
        {
            get { return DateBegin.Hour; }
            set
            {
                if (DateBegin.Hour != value)
                {
                    DateBegin = new DateTime(DateBegin.Year, DateBegin.Month, DateBegin.Day, value, DateBegin.Minute, DateBegin.Second);
                    OnPropertyChanged();
                }
            }
        }

        [NotMapped]
        public int Minute
        {
            get { return DateBegin.Minute; }
            set
            {
                if (DateBegin.Minute != value)
                {
                    DateBegin = new DateTime(DateBegin.Year, DateBegin.Month, DateBegin.Day, DateBegin.Hour, value, DateBegin.Second);
                    OnPropertyChanged();
                }
            }
        }

        [NotMapped]
        public DateTime DateOnly
        {
            get { return DateBegin.Date; }
            set
            {
                if (DateBegin.Date != value)
                {
                    DateBegin = new DateTime(
                        value.Year,
                        value.Month,
                        value.Day,
                        DateBegin.Hour,
                        DateBegin.Minute,
                        DateBegin.Second
                    );
                    OnPropertyChanged(nameof(DateOnly));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
