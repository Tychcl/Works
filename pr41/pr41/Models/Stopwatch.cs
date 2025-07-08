using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using pr41.ViewModel;

namespace pr41.Models
{
    public class Stopwatch:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public ObservableCollection<string> Interval { get; set; }
        public Stopwatch()
        {
            Interval = new ObservableCollection<string>();
        }
        private int time;
        public int Time
        {
            get { return time; }
            set
            {
                time = value; OnPropertyChanged("Timer");
            }
        }
        public bool work;
        private string textButton = "Старт";
        public string TextButton
        {
            get { return textButton; }
            set
            {
                textButton = value; OnPropertyChanged("TextButton");
            }
        }
        public string Timer
        {
            get 
            {
                int hours = Time / 3600;
                int minutes = (Time % 3600) / 60;
                int seconds = Time % 60;

                return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
            }
        }

        private RelayCommand startTimer;
        public RelayCommand StartTimer
        {
            get
            {
                return startTimer ?? 
                    (startTimer = new RelayCommand(obj =>{
                        if (!work){
                            Interval.Clear(); Time = 0; work = true; TextButton = "Стоп";
                        }else{
                            work = false;TextButton = "Старт";
                        }
                    }));
            }
        }

        private RelayCommand intervalTimer;
        public RelayCommand IntervalTimer
        {
            get
            {
                return intervalTimer ??
                    (intervalTimer = new RelayCommand(obj =>{
                        if (work) Interval.Insert(0, Timer);
                    }));
            }
        }
    }
}
