using DATABASEFRISTWF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DATABASEFRISTWF
{
    public partial class product : Form
    {
        DepiContext Context = new DepiContext();
        int id;
        public product()
        {
            InitializeComponent();
            LoadData();
        }

        public void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
        }
        public void LoadData()
        {
            var products = Context.Products.ToList();
            dataGridView1.DataSource = Context.Products.Include(e => e.Category)
            
               .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Description,
                    p.Price,
                    p.Quantity,
                    Category = p.Category.Name
                })
    .ToList();
        
            comboBox1.DataSource = Context.Categories.ToList();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
        }
        private void Add_Click(object sender, EventArgs e)
        {
            var product = new Product
            {
                Name = textBox1.Text,
                Description = textBox2.Text,
                Price = decimal.Parse(textBox3.Text),
                Quantity = int.Parse(textBox4.Text),


                CategoryId = (int)comboBox1.SelectedValue
            };
            Context.Products.Add(product);

            Context.SaveChanges();
            clear();
            LoadData();
            MessageBox.Show("Product added successfully!");
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
            var product = Context.Products.Find(id);
            product.Name = textBox1.Text;
            product.Description = textBox2.Text;
            product.Price = decimal.Parse(textBox3.Text);
            product.CategoryId = Convert.ToInt32(comboBox1.SelectedValue);
            Context.SaveChanges();
            clear();
            LoadData();
            MessageBox.Show("Product updated successfully!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var product = Context.Products.Find(id);
            Context.Products.Remove(product);
            Context.SaveChanges();
            MessageBox.Show("Product deleted successfully!");
        }
    }
}
