using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace prack14zad3_4
{
    public partial class Form1 : Form
    {
        private Queue queue;

        public Form1()
        {
            InitializeComponent();
            
            button2.Enabled = false;
            button3.Enabled = false;        
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
        }
        private void button1_click(object sender, EventArgs e)
        {
           
            try
            {
                int n = int.Parse(textBox1.Text);
                if (n < 1)
                { MessageBox.Show("Ошибка, число не может быть меньше 1", "Ошибка"); }
                else
                {
                    queue = new Queue(n);
                    button2.Enabled = true;
                    button3.Enabled = true;
                    MessageBox.Show($"Очередь с числами от 1 до {n} создана");
                }
            }
            catch { MessageBox.Show("Ошибка, можно вписывать только цифры", "Ошибка"); }
        }

        private void button2_click(object sender, EventArgs e)
        {
            if (textBox1 == null)
            {
                MessageBox.Show("Вы не ввели число");
            }
            else
            {
                timer1.Start();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            timer1.Stop();
            button2.Enabled = false;
            button3.Enabled = false;
            MessageBox.Show("Колллекция успешна очищенна", "Очистка");
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            
            if (queue == null || queue.IsEmpty())
            {   
                timer1.Stop();
                MessageBox.Show("Завершено, очередь пуста","Успешно");
            }
            
            else
            {
                int item = queue.Dequeue();
                listBox1.Items.Add(item);
            }       
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            { 
                panel1.Visible = true;
                MessageBox.Show("Запущено задание 3", "Запуск");
            }
            else
            {
                panel1.Visible = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {


            if (checkBox2.Checked)
            {
                panel2.Visible = true;
                MessageBox.Show("Запущено задание 4", "Запуск");
            }
            else
            {
                panel2.Visible = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {


            if (checkBox3.Checked)
            {
                panel3.Visible = true;
                MessageBox.Show("Запущено задание 5","Запуск");
            }
            else
            {
                panel3.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Имя файла (*.txt)|*.txt";
            file.Title = "Выбирите ваш файл";

            if (file.ShowDialog() == DialogResult.OK)
            {
                List<person> people = new List<person>();
                StreamReader reader = new StreamReader(file.FileName);

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(' ');

                    if (parts.Length != 5)
                    {
                        MessageBox.Show("Неверные входные данные в строке: " + line);
                        continue;
                    }

                    string name = parts[0];
                    string familiya = parts[1];
                    string otchestvo = parts[2];
                    int age;
                    if (!int.TryParse(parts[3], out age))
                    {
                        MessageBox.Show("Недопустимый возраст в строке: " + line);
                        continue;
                    }

                    double ves;
                    if (!double.TryParse(parts[4], out ves))
                    {
                        MessageBox.Show("Недопустимый вес в строке " + line);
                        continue;
                    }
                    person person = new person(name, familiya, otchestvo, age, ves);
                    people.Add(person);
                }
                reader.Close();
                List<person> molodiePeople = new List<person>();
                List<person> olderPeople = new List<person>();

                foreach (person person in people)
                {
                    if (person.Age < 40)
                    {
                        molodiePeople.Add(person);
                    }
                    else
                    {
                        olderPeople.Add(person);
                    }
                }
                listBox3.Items.Clear();
                listBox3.Items.Add("Люди младше 40 лет:");
                foreach (person person in molodiePeople)
                {
                    listBox3.Items.Add(person.Name + " " + person.Familiya + " " + person.Otchestvo + " " + person.Age + " года, " + person.Ves + " кг ");
                }
                listBox3.Items.Add("Остальные люди:");
                foreach (person person in olderPeople)
                {
                    listBox3.Items.Add(person.Name + " " + person.Familiya + " " + person.Otchestvo + " " + person.Age + " года, " + person.Ves + " кг ");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog file2 = new OpenFileDialog();
            file2.Filter = "Имя файла (*.txt)|*.txt";
            file2.Title = "Выбирите ваш файл";

            if (file2.ShowDialog() == DialogResult.OK)
            {
                List<person> people = new List<person>();
                StreamReader reader = new StreamReader(file2.FileName);
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(' ');

                    if (parts.Length != 5)
                    {
                        MessageBox.Show("Неверные входные данные в строке: " + line);
                        continue;
                    }

                    string name = parts[0];
                    string familiya = parts[1];
                    string otchestvo = parts[2];
                    int age;
                    if (!int.TryParse(parts[3], out age))
                    {
                        MessageBox.Show("Недопустимый возраст в строке: " + line);
                        continue;
                    }

                    double ves;
                    if (!double.TryParse(parts[4], out ves))
                    {

                        MessageBox.Show("Недопустимый вес в строке " + line);
                        continue;
                    }

                    person person = new person(name, familiya, otchestvo, age, ves);
                    people.Add(person);
                }
                reader.Close();
                Queue<person> queue = new Queue<person>(people);
                queue = new Queue<person>(queue.OrderBy(x => x.Age));
                listBox2.Items.Clear();
                foreach (person person in queue)
                {
                    listBox2.Items.Add(person.Name + " " + person.Familiya + " " + person.Otchestvo + " " + person.Age + " года, " + person.Ves + " кг ");
                }
            }
        }
    }
    }
















































