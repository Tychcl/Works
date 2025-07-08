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
    public class VMCategorys : INotifyPropertyChanged
    {
        public ObservableCollection<Context.CategorysContext> Category{ get; set; }

        public RelayCommand NewCategory
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    CategorysContext newModell = new CategorysContext(true);
                    Category.Add(newModell);
                    MainWindow.init.frame.Navigate(new View.AddCategory(newModell));
                });
            }
        }
        public VMCategorys() =>
            Category = Context.CategorysContext.AllCategorys();

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
