using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms_TestVSE_Server.Clases;

namespace WindowsForms_TestVSE_Server.Forms
{
    public partial class Work : Form
    {
        public string filename;
        public Work()
        {
            InitializeComponent();
        }

        private void Work_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testVCE_Server3DataSet2.TestResults' table. You can move, or remove it, as needed.
            this.testResultsTableAdapter.Fill(this.testVCE_Server3DataSet2.TestResults);
            // TODO: This line of code loads data into the 'testVCE_Server3DataSet1.Tests' table. You can move, or remove it, as needed.
            this.testsTableAdapter.Fill(this.testVCE_Server3DataSet1.Tests);
            // TODO: This line of code loads data into the 'testVCE_Server3DataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.testVCE_Server3DataSet.Users);

        }
        //delete dataGridView1
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            using (MyContext context = new MyContext())
            {
                int v = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                User u = context.Users.Where(x => x.Id == v).SingleOrDefault();
                context.Users.Remove(u);
                context.SaveChanges();
                MessageBox.Show("Delete Ok");
            }
            this.usersTableAdapter.Fill(this.testVCE_Server3DataSet.Users);
        }
        // Add1
        private void button3_Click(object sender, EventArgs e)
        {
            button3.Visible = false;//add 1
            button4.Visible = true;//add fin
            button8.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            button13.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (MyContext context = new MyContext())
            {
                User u = new User()
                {
                    Name = textBox1.Text,
                    Password = textBox2.Text,
                    StatusId = Convert.ToInt32(textBox3.Text)

                };
                context.Users.Add(u);
                context.SaveChanges();

            }
            this.usersTableAdapter.Fill(this.testVCE_Server3DataSet.Users);
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            button13.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button3.Visible = true;
            button2.Visible = true;
            button4.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            button1.Visible = false;
            button2.Visible = false;//work file
            button3.Visible = true;//add 1
            dataGridView2.Visible = false;
            button5.Visible = false;
            button8.Visible = true;
            button10.Visible = false;
        }
        //work with file
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            dataGridView3.Visible = false;
            button1.Visible = false;
            button2.Visible = false;//work file
            button3.Visible = false;//add 1
            button5.Visible = true;
            button9.Visible = true;
            button10.Visible = false;
        }
        //Take file
        private void button7_Click(object sender, EventArgs e)
        {
            // открытие файла
           
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                // получаем выбранный файл
                string filename = openFileDialog1.FileName;
                textBox5.Text = filename;
                // читаем файл в строку
                string fileText = System.IO.File.ReadAllText(filename);
                //textBox1.Text = fileText;
                MessageBox.Show("I Have File!");
            
        }
        //delete in dataGridView2
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            using (MyContext context = new MyContext())
            {
                int v = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value);
                Test t = context.Tests.Where(x => x.Id == v).SingleOrDefault();
                context.Tests.Remove(t);
                context.SaveChanges();
                MessageBox.Show("Delete Ok");
            }
            this.testsTableAdapter.Fill(this.testVCE_Server3DataSet1.Tests);
        }
        //Add 
        private void button5_Click(object sender, EventArgs e)
        {
            label5.Visible = true;
            button14.Visible = true;
            label7.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button9.Visible = true;
        }
        //Add fin file to db
        private void button6_Click(object sender, EventArgs e)
        {
            using (MyContext context = new MyContext())
            {
                Test test = new Test()
                {
                    Name = textBox4.Text,
                    PathToFile = textBox5.Text,
                    SubjectId  = Convert.ToInt32(textBox6.Text)

                };
                context.Tests.Add(test);
                context.SaveChanges();

            }
            this.testsTableAdapter.Fill(this.testVCE_Server3DataSet1.Tests);
            label5.Visible = false;
            button13.Visible = false;
            label7.Visible = false;
            
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button9.Visible = false;
            button5.Visible = true;
            button1.Visible = true;
        }
        //cancel user
        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            button13.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button3.Visible = false;
            button2.Visible = true;
            button4.Visible = false;
            button8.Visible = false;
            button10.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
        }
        //cancel file
        private void button9_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            button14.Visible = false;
            label7.Visible = false;

            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;

            button6.Visible = false;
            button7.Visible = false;
            button5.Visible = false;
            
            button9.Visible = false;
            
            dataGridView2.Visible = false;
            button10.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button10.Visible = false;
            dataGridView3.Visible = true;
            button11.Visible = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
            button10.Visible = true;
            button11.Visible = false;
            dataGridView3.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ViewStatus v=new ViewStatus();
            v.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ViewSubject s=new ViewSubject();
            s.Show();
        }
    }
}
