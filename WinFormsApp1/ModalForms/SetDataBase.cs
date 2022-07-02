using WinFormsApp1.Models;
using WinFormsApp1.Utils;

namespace WinFormsApp1.ModalForms
{
    public partial class SetDataBase : Form
    {
        private DatabaseSettings settings = new DatabaseSettings();
        public bool IsConnect { get; private set; }

        public SetDataBase()
        {
            InitializeComponent();
        }

        private void Server_TextChanged(object sender, EventArgs e) => settings.Server = Server.Text.ToLower();

        private void Database_TextChanged(object sender, EventArgs e) => settings.Database = Database.Text.ToLower();

        private void User_TextChanged(object sender, EventArgs e) => settings.User = User.Text.ToLower();

        private void Password_TextChanged(object sender, EventArgs e) => settings.Password = Password.Text.ToLower();

        private void button1_Click(object sender, EventArgs e)
        {
            bool resultConnection = DataBase.TryConnection(settings.GetStringConnection());
            if (resultConnection)
            {
                settings.Save();
                this.Close();
            }
            else
                button1.BackColor = Color.Red;
        }

        private void SetDataBase_Load(object sender, EventArgs e)
        {
            Server.Text = settings.Server;
            Database.Text = settings.Database;
            User.Text = settings.User;
            Password.Text = settings.Password;
        }
    }
}
