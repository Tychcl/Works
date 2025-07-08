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
    public class CategorysContext:Categorys
    {
        public CategorysContext(bool save = false)
        {
            if (save) Save(true);
        }
        public static ObservableCollection<CategorysContext> AllCategorys()
        {
            ObservableCollection<CategorysContext> allCategorys = new ObservableCollection<CategorysContext>();

            SqlConnection connection = Connection.OpenConnection();
            SqlDataReader dataCategorys = Connection.Query("SELECT * FROM [dbo].[Categorys]", connection);
            if (dataCategorys.HasRows)
                while (dataCategorys.Read())
                    allCategorys.Add(new CategorysContext()
                    {
                        Id = dataCategorys.GetInt32(0),
                        Name = dataCategorys.GetString(1)
                    });
            Connection.CloseConnection(connection);
            return allCategorys;

        }

        public void Save(bool isNew = false)
        {
            using (SqlConnection connection = Connection.OpenConnection())
            {
                if (isNew)
                {
                    this.Id = AllCategorys().Count != 0 ? AllCategorys().Max(x => x.Id) + 1 : 1;
                    SqlDataReader dataCategory = Connection.Query(
                        $"INSERT INTO " +
                        $"[dbo].[Categorys](" +
                        $"Id, " +
                            $"Name) " +
                        $"VALUES (" +
                        $"{this.Id}, " +
                            $"N'{this.Name}')", connection);
                    dataCategory.Close();
                }
                else
                {
                    Connection.Query(
                        $"UPDATE [dbo].[Categorys] " +
                        $"SET " +
                        $"Name = N'{this.Name}'" +
                        $"WHERE Id = {this.Id}",
                        connection);
                }
            }
        }

        public void Delete()
        {
            SqlConnection connection = Connection.OpenConnection();
            Connection.Query($"DELETE FROM [dbo].[Categorys] WHERE Id = {this.Id}", connection);
            Connection.CloseConnection(connection);
        }

        public RelayCommand OnEdit
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    MainWindow.init.OpenPage(new View.AddCategory(this));
                });
            }
        }

        public RelayCommand OnSave
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Save();
                    MainWindow.init.OpenPage(new View.CategoryList());
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
                    MainWindow.init.OpenPage(new View.CategoryList());
                });
            }
        }
    }
}
