using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LogReg_Application
{
    public partial class sign_up : Form
    {
        DataBase database = new DataBase();

        public sign_up()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void sign_up_Load(object sender, EventArgs e)
        {
            textBox_password2.PasswordChar = '•';
            pictureBox4.Visible = false;

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            textBox_password2.UseSystemPasswordChar = false;
            pictureBox4.Visible = false;
            pictureBox2.Visible = true;
        }        

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            textBox_password2.UseSystemPasswordChar = true;
            pictureBox4.Visible = true;
            pictureBox2.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {

            var loginUser = textBox_login2.Text;
            var passUser = textBox_password2.Text;

            string querystring = $"INSERT INTO register (login_user, password_user) VALUES ('{loginUser}','{passUser}'";

            SqlCommand command = new SqlCommand(querystring, database.getConnection());

            database.openConnection();

            if(command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Account has been created!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sign_in signIn = new sign_in();
                this.Hide();
                signIn.ShowDialog();
            }
            else
            {
                MessageBox.Show("Account doen't created!", "Registration denied!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            database.closeConnection();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            textBox_login2.Text = "";
            textBox_password2.Text = "";
        }
    }
}
