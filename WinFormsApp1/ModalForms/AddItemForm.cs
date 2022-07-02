using WinFormsApp1.Model;

namespace WinFormsApp1.ModalForms
{
    public partial class AddItemForm : Form
    {
        public DatabaseModel newModel = new DatabaseModel();
        public bool IsAdded;

        public AddItemForm()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            IsAdded = true;
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) => newModel.Vendor = textBox1.Text;
        private void textBox2_TextChanged(object sender, EventArgs e) => newModel.Manufacturer = textBox2.Text;
        private void textBox3_TextChanged(object sender, EventArgs e) => newModel.Vendor2 = textBox3.Text;
        private void textBox4_TextChanged(object sender, EventArgs e) => newModel.Manufacturer2 = textBox4.Text;

        private void checkBox1_CheckedChanged(object sender, EventArgs e) => newModel.Trust = checkBox1.Checked == true ? 1 : 0;

        private void CheckNullable(object sender, EventArgs e)
        {
            if(textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }
    }
}
