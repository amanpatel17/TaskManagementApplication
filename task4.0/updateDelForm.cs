using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;

namespace task4._0
{
    public partial class updateDelForm : Form
    {
        public updateDelForm()
        {
            InitializeComponent();
        }
        AddDb addDb = new AddDb();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Image upload
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image (*.jpg,*.png; *.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);

            }
        }

      

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void updateDelForm_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        bool verif()
        {

            if ((textBox2.Text.Trim() == "") ||

                (textBox3.Text.Trim() == "") ||
                (pictureBox1.Image == null) ||
                (comboBox1.Text.Trim() == ""))
            // (checkedListBox1.Text()=="")||      

            {
                return false;
            }
            else
            {
                return true;
            }

        }



        //edit button-

        private void button1_Click(object sender, EventArgs e)
        {


           // AddDb addDb = new AddDb();
            
            int id = Convert.ToInt32(textBox1.Text);
            string task_name = textBox2.Text;
            DateTime date = dateTimePicker1.Value;
            string description = textBox3.Text;
            string category = comboBox1.Text;
            // string category = checkedListBox1.Text;

            MemoryStream pic = new MemoryStream();

            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = DateTime.Now;

            if ((date2 > date1))
            {
                MessageBox.Show("You can't choose a preceeding date", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (verif())
            {
                pictureBox1.Image.Save(pic, pictureBox1.Image.RawFormat);

                if (addDb.updateusertask(id, task_name, date, pic, description, category))
                {
                    MessageBox.Show("Task updated", "update Task", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    MessageBox.Show("Error", "update Task", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Empty Field", "update Task", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

           
        }
        //delete button-


        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            // string task_name = textBox2.Text;
            //DateTime date = dateTimePicker1.Value;
            //string description = textBox3.Text;
            //string category = comboBox1.Text;

            if (MessageBox.Show("are you sure", "delete task", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {



                if (addDb.deleteusertask(id))
                {
                    MessageBox.Show("task deleted", "delete task", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";

                    dateTimePicker1.Value = DateTime.Now;
                    pictureBox1.Image = null;



                }
                else
                {
                    MessageBox.Show("Task Not Deleted", "Delete Task", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }


        }










        private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            MySqlCommand command = new MySqlCommand("SELECT `id`, `task_name`, `date`, `picture`, `description`, `category` FROM `usertask` WHERE `id` = "+id );

            DataTable dt = addDb.getStatus(command);
            if (dt.Rows.Count>0) {

                textBox2.Text = dt.Rows[0]["task_name"].ToString();
                textBox3.Text = dt.Rows[0]["description"].ToString();
                // textBox2.Text = dt.Rows[0][""].ToString();
                // textBox2.Text = dt.Rows[0][""].ToString();
                dateTimePicker1.Value = (DateTime)dt.Rows[0]["date"];



            }



        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}