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
using MySql.Data.MySqlClient;
using MySql.Web;

namespace SaintLucia
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public string strUsername;
        public string strPassword;
        string conn;
        MySqlConnection connect;

        public void db_connection()
        {

            try
            {
                conn = "Server=localhost;Database=saintlucia;Uid=root;Pwd=;";
                connect = new MySqlConnection(conn);
                connect.Open();
            }
            catch (MySqlException e)
            {
                throw;
            }
        }

        private bool validate_login(string strUsername, string strPassword)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from login where username=@user and password=@pass";
            cmd.Parameters.AddWithValue("@user", strUsername);
            cmd.Parameters.AddWithValue("@pass", strPassword);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            if (login.Read())
            {
                connect.Close();
                return true;
            }
            else
            {
                connect.Close();
                return false;
            }
        }




        private void LoginBtn_Click(object sender, EventArgs e)
        {
            strUsername = userTxt.Text;
            strPassword = passwordTxt.Text;
            db_connection();

            if (strUsername == "" || strPassword == "")
            {
                MessageBox.Show("Empty Fields Detected ! Please fill up all the fields");
                return;
            }
            bool r = validate_login(strUsername, strPassword);
            if (r)
            {
                MessageBox.Show("Correct Login Credentials");
                NextForm();
            }
            else
                MessageBox.Show("Incorrect Login Credentials");
        }

        private void NextForm()
        {
            MapForm MapForm = new MapForm();
            this.Hide();
            MapForm.ShowDialog();
            this.Close();

        }
        private bool PasswordBool = true;

        private void LoginForm_Load(object sender, EventArgs e)
        {
            passwordTxt.PasswordChar = '*';
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            userTxt.Text = "";
            passwordTxt.Text = "";
        }

        private void PasswordBtn_Click(object sender, EventArgs e)
        {
            if (PasswordBool == true)
            {
                passwordTxt.PasswordChar = '\0';
                PasswordBool = false;
            }
            else
            {
                passwordTxt.PasswordChar = '*';
                PasswordBool = true;
            }
        }


   


    }
}

