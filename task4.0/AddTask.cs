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

namespace task4._0
{
    public partial class AddTask : Form
    {
        public AddTask()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddTask_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }




        private void button1_Click(object sender, EventArgs e)
        {
            AddDb addDb = new AddDb();
            // string id = textBox1.;
            string task_name = textBox2.Text;
           DateTime date = dateTimePicker1.Value;
            string description = textBox3.Text;
            string category = comboBox1.Text;
            // string category = checkedListBox1.Text;




            MemoryStream pic = new MemoryStream();
            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = DateTime.Now;

            if ((date2>date1 ))
            {
                MessageBox.Show("You can't choose a preceeding date", "Invalid" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            else if (verif())
            {
                pictureBox1.Image.Save(pic, pictureBox1.Image.RawFormat);

                if(addDb.insertusertask(task_name,  date, pic, description, category))
                {
                    MessageBox.Show("New Task Added", "Add Task", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    MessageBox.Show("Error", "Add Task", MessageBoxButtons.OK, MessageBoxIcon.Error);
                


            }
            }
            else
            {
                MessageBox.Show("Empty Field", "Add Task", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        bool verif()
        {

            if ((textBox2.Text.Trim() == "") ||
  
                (textBox3.Text.Trim() == "")||
                (pictureBox1.Image == null)||
                (comboBox1.Text.Trim()==""))
            // (checkedListBox1.Text()=="")||      

            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {



        }

        private void button3_Click(object sender, EventArgs e)
        {
           // Image upload
           OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image (*.jpg,*.png; *.gif)|*.jpg;*.png;*.gif";

            if(opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);

            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
