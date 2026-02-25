using DATABASEFRISTWF.Models;
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
    public partial class Register : Form
    {
        DepiContext context = new DepiContext();
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var user = new User
            {
                Username = textBox1.Text,
                Password = textBox2.Text
            };
            context.Users.Add(user);
            context.SaveChanges();
            MessageBox.Show("Registration Successful");
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();

        }
    }
}