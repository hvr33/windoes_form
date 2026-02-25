using codeFrist.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace codeFrist
{
    public partial class Form2 : Form
    {
        AppDbContext context = new AppDbContext();
        int id;
        public Form2()
        {


            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            refresh();

            dataGridView1.DataSource = context.Products.ToList();
            comboBox1.DataSource = context.Categories.ToList();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "id";
        }
        public void refresh()
        {
            dataGridView1.DataSource = context.Products.ToList();
        }
        public void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var porduct = new Product
            {
                Name = textBox1.Text,
                Description = textBox2.Text,
                Price = decimal.Parse(textBox3.Text),
                Quantity = int.Parse(textBox4.Text),
                CategoryID = Convert.ToInt32(comboBox1.SelectedValue)



            };
            context.Products.Add(porduct);
            context.SaveChanges();
            refresh();
            MessageBox.Show("Product Added Successfully");
            clear();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            id = Convert.ToInt32(row.Cells["Id"].Value);
            textBox1.Text = row.Cells["Name"].Value.ToString();
            textBox2.Text = row.Cells["Description"].Value.ToString();
            textBox3.Text = row.Cells["Price"].Value.ToString();
            textBox4.Text = row.Cells["Quantity"].Value.ToString();
            comboBox1.SelectedValue = row.Cells["CategoryID"].Value;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            var product = context.Products.Find(id);
            product.Name = textBox1.Text;
            product.Description = textBox2.Text;
            product.Price = decimal.Parse(textBox3.Text);
            product.Quantity = int.Parse(textBox4.Text);
            product.CategoryID = Convert.ToInt32(comboBox1.SelectedValue);
            context.SaveChanges();
            refresh();
            MessageBox.Show("Product Updated Successfully");
            clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var product = context.Products.Find(id);
            context.Products.Remove(product);
            context.SaveChanges();
            refresh();
            clear();    
            MessageBox.Show("Product Deleted Successfully");


        }
    }
}
