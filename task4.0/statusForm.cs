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

namespace task4._0
{
    public partial class statusForm : Form
    {
        public statusForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        AddDb addDb = new AddDb();
        private void statusForm_Load(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `usertask`");
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = addDb.getStatus(command);
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[3];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AllowUserToAddRows = false;



        }
          
        private void updateDelForm_load(object sender, EventArgs e)
        {
            updateDelForm updateDelF = new updateDelForm();
            updateDelF.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            updateDelF.textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            updateDelF.textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            updateDelF.comboBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
           updateDelF.dateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[2].Value;

            byte[] pic;
            pic = (byte[])dataGridView1.CurrentRow.Cells[3].Value;
            MemoryStream picStream = new MemoryStream(pic);
            updateDelF.pictureBox1.Image = Image.FromStream(picStream);
            updateDelF.Show();
        }
    }
}
