using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using pr41.Models;

namespace pr41.ViewModel
{
    public class VMStopwatch:INotifyPropertyChanged
    {
        public Stopwatch Stopwatch { get; set; }
        private DispatcherTimer Timer = new DispatcherTimer()
        {
            Interval = new TimeSpan(0, 0, 1)
        };

        public VMStopwatch()
        {
            Stopwatch = new Stopwatch() { work = false , Time = 0};
            Timer.Tick += Timer_Tick;
            Timer.Start();
        }

        public void Timer_Tick(object sender, EventArgs e) 
        {
            if (Stopwatch.work)
                Stopwatch.Time++;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}
