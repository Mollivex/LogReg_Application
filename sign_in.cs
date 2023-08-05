using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogReg_Application
{
    public partial class sign_in : Form
    {
        DataBase database = new DataBase();

        public sign_in()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void sign_in_Load(object sender, EventArgs e)
        {
            textBox_password.PasswordChar = '•';
            pictureBox4.Visible = false;
            textBox_login.MaxLength = 50;
            textBox_password.MaxLength = 50;
        }

        private void button_LogIn_Click(object sender, EventArgs e)
        {
            var loginUser = textBox_login.Text;
            var passUser = textBox_password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"SELECT id_user, login_user, password_user FROM register WHERE login_user = '{loginUser}' AND password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(querystring, database.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count == 1 )
            {
                MessageBox.Show("Successfully authorization!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DatabaseView dataView = new DatabaseView();
                this.Hide();
                dataView.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Account doesn't exist!", "This account isn't found!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sign_up signUp  = new sign_up();
            signUp.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox_login.Text = "";
            textBox_password.Text = "";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox_password.UseSystemPasswordChar = true;
            pictureBox4.Visible = true;
            pictureBox3.Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            textBox_password.UseSystemPasswordChar = false;
            pictureBox4.Visible = false;
            pictureBox3.Visible = true;
        }

        private void textBox_login_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
