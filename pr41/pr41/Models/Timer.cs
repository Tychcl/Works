using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using pr41.ViewModel;

namespace pr41.Models
{
    public class Timer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _timeLeft;
        private int _initialTime;
        private bool _isRunning;
        private string _textButton = "Старт";
        public Timer()
        {

        }

        public int TimeLeft
        {
            get => _timeLeft;
            set
            {
                _timeLeft = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TimeDisplay));
            }
        }

        public int InitialTime
        {
            get => _initialTime;
            set
            {
                _initialTime = value;
                OnPropertyChanged();
            }
        }

        public bool IsRunning
        {
            get => _isRunning;
            set
            {
                _isRunning = value;
                OnPropertyChanged();
            }
        }

        public string TextButton
        {
            get => _textButton;
            set
            {
                _textButton = value;
                OnPropertyChanged();
            }
        }

        public string TimeDisplay
        {
            get
            {
                int hours = TimeLeft / 3600;
                int minutes = (TimeLeft % 3600) / 60;
                int seconds = TimeLeft % 60;

                return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
            }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
