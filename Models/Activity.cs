using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace practice.Models
{
    public class Activity : INotifyPropertyChanged
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public int DayNumber { get; set; }

        public DateTime TimeBegin { get; set; }

        [NotMapped]
        public int Hour
        {
            get { return TimeBegin.Hour; }
            set
            {
                if (TimeBegin.Hour != value)
                {
                    TimeBegin = new DateTime(TimeBegin.Year, TimeBegin.Month, TimeBegin.Day, value, TimeBegin.Minute, TimeBegin.Second);
                    OnPropertyChanged();
                }
            }
        }

        [NotMapped]
        public int Minute
        {
            get { return TimeBegin.Minute; }
            set
            {
                if (TimeBegin.Minute != value)
                {
                    TimeBegin = new DateTime(TimeBegin.Year, TimeBegin.Month, TimeBegin.Day, TimeBegin.Hour, value, TimeBegin.Second);
                    OnPropertyChanged();
                }
            }
        }


        public int ModeratorId { get; set; }
        public User Moderator { get; set; }

        public int IventId { get; set; }
        public Ivent Ivent { get; set; }


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
