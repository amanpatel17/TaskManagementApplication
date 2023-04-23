using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace task4._0
{
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DataBase db = new DataBase();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `username` = @usn AND `password` = @pass  ", db.getConnection);
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = Username.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = Password.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if(table.Rows.Count > 0) {

                this.DialogResult = DialogResult.OK;
                
            }
            else
            {
                MessageBox.Show("Invalid Username or Password" ," Login Error" , MessageBoxButtons.OK,MessageBoxIcon.Error);

            }

        }

       

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void accountLogin_text_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }
    }
}
