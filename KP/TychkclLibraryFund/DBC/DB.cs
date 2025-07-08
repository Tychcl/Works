using Microsoft.EntityFrameworkCore;

namespace DBC
{
    static class DB
    {
        readonly public static string con = "server=localhost;user=root;password=;database=LibraryFund;";
        readonly public static MySqlServerVersion MySQL = new MySqlServerVersion(new Version(8, 0, 30));
    }
}
