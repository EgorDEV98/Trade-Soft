using WinFormsApp1.Model;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;


namespace WinFormsApp1.Utils
{
    public class DataBase : DbContext
    {

        public DbSet<DatabaseModel> Products { get; set; } = null!;
        private MySqlConnection mySql { get; set; }

        private string connectionString =
            $"server={Properties.Settings.Default.Server};" +
            $"database={Properties.Settings.Default.Database};" +
            $"user={Properties.Settings.Default.User};" +
            $"password={Properties.Settings.Default.Password};";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                connectionString,
                new MySqlServerVersion(new Version(8, 0, 11))
            );
        }

        public void AddItem(DatabaseModel model)
        {
            this.Add(model);
        }

        public static bool TryConnection(string connectionString)
        {
            try
            {
                MySqlConnection mySql = new MySqlConnection(connectionString);
                mySql.Open();
                mySql.Close();
                return true;
            }
            catch 
            { 
                return false;
            }
        }
    }
}
