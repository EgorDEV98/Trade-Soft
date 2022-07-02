using WinFormsApp1.ModalForms;
using WinFormsApp1.Utils;
using WinFormsApp1.Models;
using Microsoft.EntityFrameworkCore;
using WinFormsApp1.Model;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        DataBase db;
        DatabaseSettings settings = new DatabaseSettings();

        public Form1()
        {
            db = new DataBase();
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            bool resultConnection = DataBase.TryConnection(settings.GetStringConnection());
            if (resultConnection)
            {
                db.Products.Load();
                dataGridView1.DataSource = db.Products.Local.ToBindingList();
            }
        }

        private void openDataBaseSettings_Click(object sender, EventArgs e)
        {
            var settings = new SetDataBase();
            settings.ShowDialog();
            if (settings.IsConnect)
            {
                db.Products.Load();
                dataGridView1.DataSource = db.Products.Local.ToBindingList();
            }
            settings.Dispose();
        }

        private void exitProgram_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void addItemDatabase_Click(object sender, EventArgs e)
        {
            var addItem = new AddItemForm();
            addItem.ShowDialog();
            if (addItem.IsAdded)
            {
                db.Products.Add(addItem.newModel);
                db.SaveChanges();
            }
            addItem.Dispose();
        }

        private void deleteItemsDatabase_Click(object sender, EventArgs e)
        {
            var deletedItems = dataGridView1.SelectedRows;
            foreach(DataGridViewRow item in deletedItems)
            {
                int IdItem = (int)item.Cells[0].Value;
                var deleteModel = db.Products.Where(x => x.ID == IdItem).FirstOrDefault();
                db.Products.Remove(deleteModel);
                db.SaveChanges();
            }
        }

        private void searchRelation_Click(object sender, EventArgs e)
        {
            routing.Clear();
            dataGridView2.Rows.Clear();
            var searchRelation = new SearchRelationsForm();
            searchRelation.ShowDialog();
            if (!searchRelation.IsSearch)
                return;

            var searchSet = searchRelation.searchingModel;

            var resultSearch = db.Products.Local.Where(x =>
                x.Vendor == searchSet.MainProduct.Split("/")[0] &&
                x.Manufacturer == searchSet.MainProduct.Split("/")[1]
            ).First();


            Recourse(resultSearch);

            int itterator = 1;
            bool isFound = false;
            foreach(var item in routing)
            {
                if (item.to.Manufacturer2 == searchRelation.searchingModel.SearchingProduct)
                    isFound = true;
                dataGridView2.Rows.Add("Маршрут " + itterator, item.from.Vendor +" -> " + item.to.Vendor2);
                dataGridView2.DefaultCellStyle.BackColor = Color.White;
                itterator++;
            }
            if (isFound && !string.IsNullOrWhiteSpace(searchSet.SearchingProduct))
                MessageBox.Show($"Искомый элемент {searchSet.SearchingProduct} найден!");
            else
                MessageBox.Show($"Искомый элемент {searchSet.SearchingProduct} не обнаружен!");
        }

        List<EndpoindSearch> routing = new List<EndpoindSearch>();

        private void Recourse(DatabaseModel model)
        {
            string Vendor = model.Vendor2.Trim().ToLower();

            var resultSearch = db.Products.Local.Where(x => x.Vendor == Vendor);

            if (resultSearch.Count() != 0)
            {
                foreach(var item in resultSearch)
                {
                    routing.Add(new EndpoindSearch(model, item));
                    Recourse(item);
                }
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var IdItem = dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            var changeModel = db.Products.Where(x => x.ID == (int)IdItem).FirstOrDefault();
            db.Products.Update(changeModel);
            db.SaveChanges();
        }
    }

    class EndpoindSearch
    {
        public EndpoindSearch(DatabaseModel from, DatabaseModel to)
        {
            this.from = from;
            this.to = to;
        }
        public DatabaseModel? from { get; set; }
        public DatabaseModel? to { get; set; }
    }
}