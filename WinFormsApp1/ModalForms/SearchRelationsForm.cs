using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1.ModalForms
{
    public partial class SearchRelationsForm : Form
    {
        public SearchingModel searchingModel;
        public bool IsSearch;
        public SearchRelationsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            searchingModel = new SearchingModel()
            {
                MainProduct = textBox1.Text,
                SearchingProduct = textBox2.Text,
                SearchDepth = (int)numericUpDown1.Value
            };
            IsSearch = true;
            this.Close();
        }

        private void CheckNullable(object sender, EventArgs e)
        {
            button1.Enabled = 
                textBox1.Text.Length > 0 ||
                textBox2.Text.Length > 0;
        }
    }

    public class SearchingModel
    {
        public string? MainProduct { get; set; }
        public string? SearchingProduct { get; set; }
        public int? SearchDepth { get; set; }
    }
}
