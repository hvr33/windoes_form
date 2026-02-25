using codeFrist.Models;

namespace codeFrist
{
    public partial class Form1 : Form
    {
        AppDbContext context = new AppDbContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void button1_Click_1(object sender, EventArgs e)

        {
          var user = context.Users.FirstOrDefault(u => u.username == textBox1.Text && u.Password == textBox2.Text);
            if (user!=null&&user.Password==textBox2.Text )
            {
                MessageBox.Show("Login successful!");
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");

            }
        }
    }
}
