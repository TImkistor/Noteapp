using System;
using System.Data;
using System.Windows.Forms;

namespace Noteapp
{
    public partial class Form1 : Form
    {
        DataTable table;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.ReadOnly = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("Title", typeof(String));
            table.Columns.Add("Message", typeof(String));
            dataGridView1.DataSource = table;
            dataGridView1.Columns["Message"].Visible = false;
            dataGridView1.Columns["Title"].Width = 215;
        }

        private void New_Click(object sender, EventArgs e)
        {
            TextTitle.Clear();
            TextMessage.Clear();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            table.Rows.Add(TextTitle.Text,TextMessage.Text);
            TextTitle.Clear();
            TextMessage.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            if (index > -1)
            {
                TextTitle.Text = table.Rows[index].ItemArray[0].ToString();
                TextMessage.Text = table.Rows[index].ItemArray[1].ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            table.Rows[index].Delete();
        }
    }
}
