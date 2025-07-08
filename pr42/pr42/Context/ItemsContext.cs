using Microsoft.Data.SqlClient;
using pr42.Modell;
using pr42.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr42.Context
{
    public class ItemsContext:Items
    {
        public ItemsContext(bool save = false)
        {
            if (save) Save(true);
            Category = new Categorys();
        }
        public static ObservableCollection<ItemsContext> AllItems()
        {
            ObservableCollection<ItemsContext> allItems = new ObservableCollection<ItemsContext>();
            ObservableCollection<CategorysContext> allCategorys = CategorysContext.AllCategorys();

            SqlConnection connection = Connection.OpenConnection();
            SqlDataReader dataItem = Connection.Query("SELECT * FROM [dbo].[Items]", connection);
            if (dataItem.HasRows)
                while (dataItem.Read())
                    allItems.Add(new ItemsContext()
                    {
                        Id = dataItem.GetInt32(0),
                        Name = dataItem.GetString(1),
                        Price = dataItem.GetInt32(2),
                        Descriprion = dataItem.GetString(3),
                        Category = dataItem.IsDBNull(4) ? null : allCategorys.Where(x=>x.Id == dataItem.GetInt32(4)).First()
                    });
            Connection.CloseConnection(connection);
            return allItems;

        }

        public void Save(bool isNew = false)
        {
            using (SqlConnection connection = Connection.OpenConnection())
            {
                if (isNew)
                {
                    this.Id = AllItems().Count != 0 ? AllItems().Max(x=> x.Id) + 1 : 1;
                    SqlDataReader dataItem = Connection.Query(
                        $"INSERT INTO " + 
                        $"[dbo].[Items](" +
                            $"Id, " +
                            $"Name, " +
                            $"Price, " +
                            $"Description) " +
                        $"VALUES (" +
                            $"'{this.Id}', " +
                            $"'{this.Name}', " +
                            $"{this.Price}, " +
                            $"'{this.Descriprion}')",connection);
                    dataItem.Close();
                }
                else
                {
                    Connection.Query(
                        $"UPDATE [dbo].[Items] " +
                        $"SET " +
                        $"Name = '{this.Name}', " +
                        $"Price = {this.Price}, " +
                        $"Description = '{this.Descriprion}', " +
                        $"IdCategory = {this.Category.Id} " +
                        $"WHERE Id = {this.Id}",
                        connection);
                }
            }
        }

        public void Delete()
        {
            SqlConnection connection = Connection.OpenConnection();
            Connection.Query($"DELETE FROM [dbo].[Items] WHERE Id = {this.Id}", connection);
            Connection.CloseConnection(connection);
        }

        public RelayCommand OnEdit
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    MainWindow.init.OpenPage(new View.AddItem(this));
                });
            }
        }

        public RelayCommand OnSave
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Category = CategorysContext.AllCategorys().Where(x => x.Id == this.Category.Id).First();
                    Save();
                    MainWindow.init.OpenPage(new View.Main());
                });
            }
        }

        public RelayCommand OnDelete
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Delete();
                    (MainWindow.init.Main.DataContext as ViewModell.VMItems).Items.Remove(this);
                    MainWindow.init.OpenPage(new View.Main());
                });
            }
        }
    }
}
