using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace SE_FinalProject
{
    public partial class loginForm : Form
    {
        private void login()
        {
            SqlConnection conn = new SqlConnection(Program.connectionString);
            conn.Open();
            String sSQL = "SELECT username, password FROM Users WHERE " +
            "username='" + tbUsername.Text + "' and password='" +
            tbPassword.Text + "'";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Login. Please check userID or Password!");
            }
        }
        public loginForm()
        {
            InitializeComponent();
            tbUsername.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tbUsername.ForeColor = Color.White;
            }
            catch { }
           
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.White;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.White;
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tbPassword.ForeColor = Color.White;
                tbPassword.UseSystemPasswordChar = true;
            }
            catch { }
        }

        private void tbUsername_Click(object sender, EventArgs e)
        {
            tbUsername.SelectAll();
        }

        private void tbPassword_Click(object sender, EventArgs e)
        {
            tbPassword.SelectAll();
        }
    }
}
