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

namespace menyandKeyboard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                panelCentre.BackColor = colorDialog1.Color;
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                StreamWriter file = new StreamWriter(saveFileDialog1.FileName);
                file.WriteLine(panelCentre.BackColor.ToString());
                file.Close();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            /*StreamWriter file = new StreamWriter("setting.dat");
            file.WriteLine(panelCentre.BackColor.ToArgb().ToString());
            file.Close(); */
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*StreamReader file = new StreamReader("setting.dat");
            Color c = Color.FromArgb(Convert.ToInt32(file.ReadLine()));
            file.Close();
            panelCentre.BackColor = c; */

            dataGridView1.Rows.Add(3);
            dataGridView2.Rows.Add(3);
            dataGridView2.CurrentCell = this.dataGridView2[0, 2];
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                int col = dataGridView2.CurrentCell.ColumnIndex - 1;
                int row = dataGridView2.CurrentCell.RowIndex;
                dataGridView2.CurrentCell = dataGridView2[col, row];
            }
        }
    }
}
