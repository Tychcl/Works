using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using pr41.Models;

namespace pr41.ViewModel
{
    public class VMTimer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Models.Timer Timer { get; set; }
        private DispatcherTimer _dispatcherTimer = new DispatcherTimer()
        {
            Interval = TimeSpan.FromSeconds(1)
        };

        public VMTimer()
        {
            Timer = new Models.Timer();
            _dispatcherTimer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Timer.IsRunning && Timer.TimeLeft > 0)
            {
                Timer.TimeLeft--;

                if (Timer.TimeLeft == 0)
                {
                    Timer.IsRunning = false;
                    Timer.TextButton = "Старт";
                    _dispatcherTimer.Stop();
                    MessageBox.Show("Время вышло");
                }
            }
        }

        private RelayCommand _startCommand;
        public RelayCommand StartCommand
        {
            get
            {
                return _startCommand ?? (_startCommand = new RelayCommand(obj =>
                {
                    if (!Timer.IsRunning)
                    {
                        if (Timer.TimeLeft == 0 && Timer.InitialTime > 0)
                        {
                            Timer.TimeLeft = Timer.InitialTime;
                        }

                        if (Timer.TimeLeft > 0)
                        {
                            Timer.IsRunning = true;
                            Timer.TextButton = "Стоп";
                            _dispatcherTimer.Start();
                        }
                    }
                    else
                    {
                        Timer.IsRunning = false;
                        Timer.TextButton = "Старт";
                        _dispatcherTimer.Stop();
                    }
                }));
            }
        }

        private RelayCommand _resetCommand;
        public RelayCommand ResetCommand
        {
            get
            {
                return _resetCommand ?? (_resetCommand = new RelayCommand(obj =>
                {
                    Timer.IsRunning = false;
                    Timer.TextButton = "Старт";
                    Timer.TimeLeft = 0;
                    _dispatcherTimer.Stop();

                }));
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
