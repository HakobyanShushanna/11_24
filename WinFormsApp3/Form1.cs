using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {

        int n = 0;
        int[,] matrix;
        List<int> B = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }
        private void InitDataGridView()
        {
            dataGridView1.Columns.Clear();

            for (int i = 0; i < n; i++)
            {
                dataGridView1.Columns.Add(i.ToString(), "");
                dataGridView1.Columns[i].Width = dataGridView1.Width / (n + 1);
            }

            for (int i = 0; i < n; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Height = dataGridView1.Height / (n + 1);
            }

            dataGridView1.AllowUserToAddRows = false;
        }

        void GenerateMatrix()
        {
            matrix = new int[n, n];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rnd.Next(-20, 91);
                }
            }
        }

        void PrintMatrix()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = matrix[i, j];
                }
            }
        }

        void FindLastPositiveElements()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    if (matrix[i, j] > 0)
                    {
                        B.Add(matrix[i, j]);
                        break;
                    }
                }
            }
        }

        void AddItems()
        {
            for (int i = 0; i < B.Count; i++)
            {
                listBox1.Items.Add(B[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int.TryParse(textBox1.Text, out n);
            InitDataGridView();
            GenerateMatrix();
            PrintMatrix();
            FindLastPositiveElements();
            AddItems();
        }
    }
}
