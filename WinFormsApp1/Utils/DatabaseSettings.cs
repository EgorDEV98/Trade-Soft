namespace WinFormsApp1.Models
{
    public class DatabaseSettings
    {
        public DatabaseSettings()
        {
            Server = Properties.Settings.Default.Server;
            Database = Properties.Settings.Default.Database;
            User = Properties.Settings.Default.User;
            Password = Properties.Settings.Default.Password;
        }

        public void Save()
        {
            Properties.Settings.Default.Server = Server;
            Properties.Settings.Default.Database = Database;
            Properties.Settings.Default.User = User;
            Properties.Settings.Default.Password = Password;
            Properties.Settings.Default.Save();
        }

        public string GetStringConnection()
        {
            return $"server={Server};database={Database};user={User};password={Password};";
        }

        public string? Server { get; set; }
        public string? Database { get; set; }
        public string? User { get; set; }
        public string? Password { get; set; }
    }
}
