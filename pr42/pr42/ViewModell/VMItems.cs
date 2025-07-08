using pr42.Classes;
using pr42.Context;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace pr42.ViewModell
{
    public class VMItems:INotifyPropertyChanged
    {
        public ObservableCollection<Context.ItemsContext> Items { get; set; } 

        public RelayCommand NewItem
        {
            get {
                return new RelayCommand(obj =>
                {
                    ItemsContext newModell = new ItemsContext(true);
                    Items.Add(newModell);
                    MainWindow.init.frame.Navigate(new View.AddItem(newModell));
                });
            }
        }
        public VMItems() =>
            Items = Context.ItemsContext.AllItems();

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
